using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CustomerMoghimiHome.Server.Controllers.Shop;
[ApiController]
public class ProductCategoryController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProductCategoryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [Route(ShopRoutes.ProductCategory + CRUDRouts.Create)]
    [HttpPost]
    public async Task Create([FromBody] string data)
    {
        await _unitOfWork.ProductCategories.AddAsync(
            await Task.Run(() => _mapper.Map<ProductCategoryEntity>(async () =>
            await Task.Run(() => JsonSerializer.Deserialize<ProductCategoryDto>(data))
            )));
        await _unitOfWork.CommitAsync();
    }

    [HttpPut(ShopRoutes.ProductCategory + CRUDRouts.Update)]
    public async Task Update([FromBody] string data)
    {
        await Task.Run(async () => _unitOfWork.ProductCategories.Update(
           await Task.Run(() => _mapper.Map<ProductCategoryEntity>(async () =>
           await Task.Run(() => JsonSerializer.Deserialize<ProductCategoryDto>(data))
           ))));
        await _unitOfWork.CommitAsync();
    }

    [HttpDelete(ShopRoutes.ProductCategory + CRUDRouts.Delete + "/{data:long}")]
    public async Task Delete([FromRoute] long data)
    {
        await Task.Run(async () => _unitOfWork.ProductCategories.Remove
        (await _unitOfWork.ProductCategories.GetByIdAsync(data)));
        await _unitOfWork.CommitAsync();
    }

    [HttpGet(ShopRoutes.ProductCategory + CRUDRouts.ReadAll)]
    public async Task<List<ProductCategoryDto>> GetAll() =>
        _mapper.Map<List<ProductCategoryDto>>(await _unitOfWork.ProductCategories.GetAllAsync());

    [HttpGet(ShopRoutes.ProductCategory + CRUDRouts.ReadAll + "/{data:long}")]
    public async Task<ProductCategoryDto> GetById([FromRoute] long data) =>
        _mapper.Map<ProductCategoryDto>(await _unitOfWork.ProductCategories.GetByIdAsync(data));

    [HttpPost(ShopRoutes.ProductCategory + CRUDRouts.ReadListByFilter)]
    public async Task<PaginatedList<ProductCategoryEntity>> GetListByFilter([FromBody] string data) =>
        await _unitOfWork.ProductCategories.GetListByFilterAsync(await Task.Run(() => JsonSerializer.Deserialize<DefaultPaginationFilter>(data) ?? new()));

}