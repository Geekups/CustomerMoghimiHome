using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CustomerMoghimiHome.Server.Controllers.Shop;

public class BasketController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public BasketController(UserManager<IdentityUser> userManager, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    // todo: must refactor
    [HttpPost(BasketRoutes.Basket + CRUDRouts.Create)]
    public async Task Create([FromBody] string data)
    {
        var dto = await Task.Run(() => JsonSerializer.Deserialize<BasketDto>(data));
        if (dto != null)
        {
            var user = await _userManager.FindByEmailAsync(dto.UserName);
            dto.UserId = user.Id;
            dto.CreateDate = DateTime.Now; dto.ModifiedDate = DateTime.Now;
            var entity = await Task.Run(() => _mapper.Map<BasketEntity>(dto));
            var isProductExist = await _unitOfWork.Baskets.IsExistWithUserIdAndProductIdAsync(user.Id, entity.ProductId);
            if (isProductExist) 
            {
                entity = await _unitOfWork.Baskets.GetBasketWithUserIdAndProductIdAsync(user.Id, entity.ProductId);
                entity.Quantity += 1;
                 _unitOfWork.Baskets.Update(entity);
            }
            else 
            {
                await _unitOfWork.Baskets.AddAsync(entity);
            }
            
            await _unitOfWork.CommitAsync();
        }
    }

    [HttpGet(BasketRoutes.Basket + CRUDRouts.ReadAll + "/{data}")]
    public async Task<List<BasketDto>> GetBasketByUserName(string data)
    {
        var user = await _userManager.FindByEmailAsync(data);
        var entities = await _unitOfWork.Baskets.GetAllUserBasketAsync(user.Id);
        var entityList = await Task.Run(() => _mapper.Map<List<BasketDto>>(entities));
        return entityList;
    }
}