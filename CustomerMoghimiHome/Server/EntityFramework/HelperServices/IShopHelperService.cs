using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;

namespace CustomerMoghimiHome.Server.EntityFramework.HelperServices;

public interface IShopHelperService
{
    Task<List<BasketDetailDto>> PrepareBasketDetailsByUserId(string userId);
}


public class ShopHelperService : IShopHelperService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ShopHelperService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<BasketDetailDto>> PrepareBasketDetailsByUserId(string userId)
    {
        var userBasket = await _unitOfWork.Baskets.GetByUserIdAsync(userId);
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

            });
        }
        return results;
    }
}