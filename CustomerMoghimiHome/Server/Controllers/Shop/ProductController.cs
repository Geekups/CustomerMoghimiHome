using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CustomerMoghimiHome.Server.Controllers.Shop;
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpPost(ShopRoutes.Product + CRUDRouts.Create)]
    public async Task Create([FromBody] string data)
    {
        await _unitOfWork.Products.AddAsync(
            await Task.Run(() => _mapper.Map<ProductEntity>(async () =>
            await Task.Run(() => JsonSerializer.Deserialize<ProductDto>(data))
            )));
        await _unitOfWork.CommitAsync();
    }

    [HttpPut(ShopRoutes.Product + CRUDRouts.Update)]
    public async Task Update([FromBody] string data)
    {
        await Task.Run(async () => _unitOfWork.Products.Update(
           await Task.Run(() => _mapper.Map<ProductEntity>(async () =>
           await Task.Run(() => JsonSerializer.Deserialize<ProductDto>(data))
           ))));
        await _unitOfWork.CommitAsync();
    }

    [HttpDelete(ShopRoutes.Product + CRUDRouts.Delete + "/{data:long}")]
    public async Task Delete([FromRoute] long data)
    {
        await Task.Run(async () => _unitOfWork.Products.Remove
        (await _unitOfWork.Products.GetByIdAsync(data)));
        await _unitOfWork.CommitAsync();
    }

    [HttpGet(ShopRoutes.Product + CRUDRouts.ReadAll)]
    public async Task<List<ProductDto>> GetAll() =>
        _mapper.Map<List<ProductDto>>(await _unitOfWork.Products.GetAllAsync());

    [HttpGet(ShopRoutes.Product + CRUDRouts.ReadAll + "/{data:long}")]
    public async Task<ProductDto> GetById([FromRoute] long data) =>
        _mapper.Map<ProductDto>(await _unitOfWork.Products.GetByIdAsync(data));

    [HttpPost(ShopRoutes.Product + CRUDRouts.ReadListByFilter)]
    public async Task<PaginatedList<ProductEntity>> GetListByFilter([FromBody] string data) =>
        await _unitOfWork.Products.GetListByFilterAsync(await Task.Run(() => JsonSerializer.Deserialize<DefaultPaginationFilter>(data) ?? new()));

}