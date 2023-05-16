using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Server.EntityFramework.HelperServices;
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
    private readonly IShopHelperService _shopHelperService;
    private readonly UserManager<IdentityUser> _userManager;
    public UserBasketController(IUnitOfWork unitOfWork, IShopHelperService shopHelperService, IMapper mapper, UserManager<IdentityUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
        _shopHelperService = shopHelperService;
    }
    [HttpPost(ShopRoutes.UserBasket + CRUDRouts.Create)]
    public async Task AddToBasket([FromBody] string data)
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
        return await _shopHelperService.PrepareBasketDetailsByUserId(user.Id);
    }

    [HttpPut(ShopRoutes.UserBasket + CRUDRouts.Update)]
    public async Task UserBasketProductQuantityChange([FromBody] string data)
    {
        var dto = await Task.Run(() => JsonSerializer.Deserialize<BasketDetailDto>(data));
        if (dto != null)
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
