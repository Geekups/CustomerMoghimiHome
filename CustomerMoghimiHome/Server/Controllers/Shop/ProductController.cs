using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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
        var dto = await Task.Run(() => JsonSerializer.Deserialize<ProductDto>(data));
        if (dto != null)
        {
            var imageDto = await _unitOfWork.Images.GetImageByPathAsync(dto.ImagePath);
            dto.ImageAlt = imageDto.Alt;
            dto.CreateDate = DateTime.Now; dto.ModifiedDate = DateTime.Now;
            var entity = await Task.Run(() => _mapper.Map<ProductEntity>(dto));
            await _unitOfWork.Products.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }
    }

    [HttpPut(ShopRoutes.Product + CRUDRouts.Update)]
    public async Task Update([FromBody] string data)
    {
        var dto = await Task.Run(() => JsonSerializer.Deserialize<ProductDto>(data));
        if (dto != null)
        {
            var imageDto = await _unitOfWork.Images.GetImageByPathAsync(dto.ImagePath);
            dto.ImageAlt = imageDto.Alt;
            dto.ModifiedDate = DateTime.Now;
            var entity = await Task.Run(() => _mapper.Map<ProductEntity>(dto));
            await Task.Run(() => _unitOfWork.Products.Update(entity));
            await _unitOfWork.CommitAsync();
        }
    }

    [HttpDelete(ShopRoutes.Product + CRUDRouts.Delete + "/{data:long}")]
    public async Task Delete([FromRoute] long data)
    {
        var entity = await _unitOfWork.Products.GetByIdAsync(data);
        await Task.Run(() => _unitOfWork.Products.Remove(entity));
        await _unitOfWork.CommitAsync();
    }

    [HttpGet(ShopRoutes.Product + CRUDRouts.ReadAll)]
    public async Task<List<ProductDto>> GetAll() =>
        _mapper.Map<List<ProductDto>>(await _unitOfWork.Products.GetAllAsync());

    [HttpGet(ShopRoutes.Product + CRUDRouts.ReadOneById + "/{data:long}")]
    public async Task<ProductDto> GetById([FromRoute] long data) =>
        _mapper.Map<ProductDto>(await _unitOfWork.Products.GetByIdAsync(data));

    [HttpPost(ShopRoutes.Product + CRUDRouts.ReadListByFilter)]
    public async Task<PaginatedList<ProductDto>> GetListByFilter([FromBody] string data)
    {
        var filter = await Task.Run(() => JsonSerializer.Deserialize<DefaultPaginationFilter>(data) ?? new());
        var entityList = await _unitOfWork.Products.GetListByFilterAsync(filter);
        return await Task.Run(() => _mapper.Map<PaginatedList<ProductDto>>(entityList));
    }
}