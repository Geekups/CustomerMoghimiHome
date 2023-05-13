using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CustomerMoghimiHome.Server.Controllers.Shop;

[ApiController]
public class UserBasketController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserManager<IdentityUser> _userManager;
    public UserBasketController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<IdentityUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
    }
    [HttpPost(ShopRoutes.UserBasket + CRUDRouts.Create)]
    public async Task Create([FromBody] string data)
    {
        var dto = await Task.Run(() => JsonSerializer.Deserialize<UserBasketDto>(data));
        if (dto != null)
        {
            var user = await _userManager.FindByEmailAsync(dto.UserName);
            dto.CreateDate = DateTime.Now; dto.ModifiedDate = DateTime.Now;
            var userBasket = await _unitOfWork.Baskets.GetByUserIdAsync(user.Id);
            if (userBasket == null)
            {
                var entity = await Task.Run(() => _mapper.Map<UserBasketEntity>(dto));
                entity.UserId = user.Id;
                var basket = await _unitOfWork.Baskets.AddAsyncReturnId(entity);
                await _unitOfWork.CommitAsync();
                await _unitOfWork.BasketProducts.AddAsync(new BasketProductEntity
                {
                    ProductId = dto.SelectedProductId,
                    BasketId = basket.Id
                });
                await _unitOfWork.CommitAsync();
            }
            else
            {
                await _unitOfWork.BasketProducts.AddAsync(new BasketProductEntity
                {
                    ProductId = dto.SelectedProductId,
                    BasketId = userBasket.Id
                });
                await _unitOfWork.CommitAsync();
            }
        }
    }

    [HttpGet(ShopRoutes.UserBasket + CRUDRouts.ReadOneById + "/{data}")]
    public async Task<List<BasketDetailDto>> GetByUserId([FromRoute] string data)
    {
        var user = await _userManager.FindByEmailAsync(data);
        var userBasket = await _unitOfWork.Baskets.GetByUserIdAsync(user.Id);
        var userBasketDto = await Task.Run(() => _mapper.Map<UserBasketDto>(userBasket));
        var BasketProductList = await _unitOfWork.BasketProducts.
            GetByUserBasketIdAsync(userBasket.Id);
        //get all related products
        List<ProductDto> productList = new();
        foreach (var item in BasketProductList)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);
            var productDto = await Task.Run(() => _mapper.Map<ProductDto>(product));
            productList.Add(productDto);
        }

        // prepare data for basket detail in front
        List<BasketDetailDto> results = new();
        var groupedByIdProducts = productList.GroupBy(x => x.Id);
        foreach (var item in groupedByIdProducts)
        {
            results.Add(new BasketDetailDto()
            {
                Id = item.Key,
                ProductName = item.Select(x => x.ProductName).ToList()[0],
                BuilderCompany = item.Select(x => x.BuilderCompany).ToList()[0],
                ImagePath = item.Select(x => x.ImagePath).ToList()[0],
                Price = item.Select(x => x.Price).ToList()[0],
                Quantity = item.Count(),

            }) ;
        }
        return results;
    }

    [HttpPut(ShopRoutes.UserBasket + CRUDRouts.Update)]
    public async Task UserBasketProductQuantityChange([FromBody] string data)
    {
        var dto = await Task.Run(() => JsonSerializer.Deserialize<BasketDetailDto>(data));
        if (dto != null ) 
        {
            var user = await _userManager.FindByEmailAsync(dto.UserEmail);
            var currentUserBasket = await _unitOfWork.Baskets.GetByUserIdAsync(user.Id);
            var quantityOfProduct = await Task.Run(() => _unitOfWork.BasketProducts.GetCountByProductId(dto.Id));

            if (dto.Quantity < quantityOfProduct)
            {
                var difference = quantityOfProduct - dto.Quantity;
                var productList = await _unitOfWork.BasketProducts.
                    TakeSpecificCountWithCondition(difference, dto.Id);
                _unitOfWork.BasketProducts.RemoveRange(productList);

            }
            else if (dto.Quantity > quantityOfProduct)
            {
                var difference = dto.Quantity - quantityOfProduct;

                for (int i = 0; i < difference; i++)
                {
                    await _unitOfWork.BasketProducts.AddAsync(new BasketProductEntity()
                    {
                        BasketId = currentUserBasket.Id,
                        CreateDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        ProductId = dto.Id,
                    });
                }
            }
            await _unitOfWork.CommitAsync();
        }
    }
}