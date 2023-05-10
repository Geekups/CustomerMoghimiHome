﻿using AutoMapper;
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
            var aa = (await _userManager.FindByEmailAsync(dto.UserName));
            var bb = aa.Id;
            dto.CreateDate = DateTime.Now; dto.ModifiedDate = DateTime.Now;
            var entity = await Task.Run(() => _mapper.Map<UserBasketEntity>(dto));
            await _unitOfWork.Baskets.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }
    }

    //[HttpPut(ShopRoutes.ProductCategory + CRUDRouts.Update)]
    //public async Task Update([FromBody] string data)
    //{
    //    var dto = await Task.Run(() => JsonSerializer.Deserialize<ProductCategoryDto>(data));
    //    if (dto != null)
    //    {
    //        dto.ModifiedDate = DateTime.Now;
    //        var entity = await Task.Run(() => _mapper.Map<ProductCategoryEntity>(dto));
    //        await Task.Run(() => _unitOfWork.ProductCategories.Update(entity));
    //        await _unitOfWork.CommitAsync();
    //    }
    //}

    //[HttpDelete(ShopRoutes.ProductCategory + CRUDRouts.Delete + "/{data:long}")]
    //public async Task Delete([FromRoute] long data)
    //{
    //    var entity = await _unitOfWork.ProductCategories.GetByIdAsync(data);
    //    await Task.Run(() => _unitOfWork.ProductCategories.Remove(entity));
    //    await _unitOfWork.CommitAsync();
    //}

    //[HttpGet(ShopRoutes.ProductCategory + CRUDRouts.ReadAll)]
    //public async Task<List<ProductCategoryDto>> GetAll() =>
    //    _mapper.Map<List<ProductCategoryDto>>(await _unitOfWork.ProductCategories.GetAllAsync());

    //[HttpGet(ShopRoutes.ProductCategory + CRUDRouts.ReadOneById + "/{data}")]
    //public async Task<ProductCategoryDto> GetById([FromRoute] long data) =>
    //    _mapper.Map<ProductCategoryDto>(await _unitOfWork.ProductCategories.GetByIdAsync(data));

    //[HttpPost(ShopRoutes.ProductCategory + CRUDRouts.ReadListByFilter)]
    //public async Task<PaginatedList<ProductCategoryDto>> GetListByFilter([FromBody] string data)
    //{
    //    var filter = await Task.Run(() => JsonSerializer.Deserialize<DefaultPaginationFilter>(data) ?? new());
    //    var entityList = await _unitOfWork.ProductCategories.GetListByFilterAsync(filter);
    //    return await Task.Run(() => _mapper.Map<PaginatedList<ProductCategoryDto>>(entityList));
    //}
}