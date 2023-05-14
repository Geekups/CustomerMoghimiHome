using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Customer;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Server.EntityFramework.HelperServices;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CustomerMoghimiHome.Server.Controllers.Shop;

[ApiController]
public class OrderController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IShopHelperService _shopHelperService;
    private readonly UserManager<IdentityUser> _userManager;
    public OrderController(IUnitOfWork unitOfWork, IShopHelperService shopHelperService, IMapper mapper, UserManager<IdentityUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
        _shopHelperService = shopHelperService;
    }
    [HttpPost(ShopRoutes.UserOrder + CRUDRouts.Create)]
    public async Task Create([FromBody] string data)
    {

        var dto = await Task.Run(() => JsonSerializer.Deserialize<CustomerDetailDto>(data));
        if (dto != null)
        {
            var user = await _userManager.FindByEmailAsync(dto.UserName);
            var basketDetailDtoList = await _shopHelperService.PrepareBasketDetailsByUserId(user.Id);
            dto.CreateDate = DateTime.Now; dto.ModifiedDate = DateTime.Now;
            var userBasket = await _unitOfWork.Baskets.GetByUserIdAsync(user.Id);
            foreach (var basketDetailDto in basketDetailDtoList)
            {
                var orderEntity = new UserOrderEntity()
                {
                    UserId = user.Id,
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    ProductId = basketDetailDto.Id,
                    ProductName = basketDetailDto.ProductName,
                    UserBasketId = userBasket.Id,
                    ProductCount = basketDetailDto.Quantity,
                    ProductTotalPrice = (long)(basketDetailDto.Price * basketDetailDto.Quantity)

                };
                await _unitOfWork.UserOrders.AddAsync(orderEntity);
                await _unitOfWork.CommitAsync();
            }

            var customerEntity = await Task.Run(() => _mapper.Map<CustomerDetailEntity>(dto));
            await _unitOfWork.CustomerDetails.AddAsync(customerEntity);
            await _unitOfWork.CommitAsync();
        }
    }

    [HttpPost(ShopRoutes.UserOrder + CRUDRouts.CustomReadList + "/{userEmail}")]
    public async Task<List<UserOrderDto>> Get([FromBody] string userEmail)
    {
        var user = await _userManager.FindByEmailAsync(userEmail);
        var entityList = await _unitOfWork.UserOrders.GetByUserId(user.Id);
        return await Task.Run(()=> _mapper.Map<List<UserOrderDto>>(entityList));
    }
}