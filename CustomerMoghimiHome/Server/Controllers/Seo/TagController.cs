using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Seo;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Seo;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CustomerMoghimiHome.Server.Controllers.Seo;

[ApiController]
public class TagController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public TagController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpPost(SeoRoutes.Tag + CRUDRouts.Create)]
    public async Task Create([FromBody] string data)
    {
        var dto = await Task.Run(() => JsonSerializer.Deserialize<TagDto>(data));
        if (dto != null)
        {
            dto.CreateDate = DateTime.Now; dto.ModifiedDate = DateTime.Now;
            var entity = await Task.Run(() => _mapper.Map<TagEntity>(dto));
            await _unitOfWork.Tags.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }
    }

    [HttpPut(SeoRoutes.Tag + CRUDRouts.Update)]
    public async Task Update([FromBody] string data)
    {

        var dto = await Task.Run(() => JsonSerializer.Deserialize<TagDto>(data));
        if (dto != null)
        {
            dto.ModifiedDate = DateTime.Now;
            var entity = await Task.Run(() => _mapper.Map<TagEntity>(dto));
            await Task.Run(() => _unitOfWork.Tags.Update(entity));
            await _unitOfWork.CommitAsync();
        }
    }

    [HttpDelete(SeoRoutes.Tag + CRUDRouts.Delete + "/{data:long}")]
    public async Task Delete([FromRoute] long data)
    {
        var entity = await _unitOfWork.Tags.GetByIdAsync(data);
        await Task.Run(() => _unitOfWork.Tags.Remove(entity));
        await _unitOfWork.CommitAsync();
    }

    [HttpGet(SeoRoutes.Tag + CRUDRouts.ReadAll)]
    public async Task<List<TagDto>> GetAll() =>
        _mapper.Map<List<TagDto>>(await _unitOfWork.Tags.GetAllAsync());

    [HttpGet(SeoRoutes.Tag + CRUDRouts.ReadOneById + "/{data:long}")]
    public async Task<TagDto> GetById([FromRoute] long data) =>
        _mapper.Map<TagDto>(await _unitOfWork.Tags.GetByIdAsync(data));

    [HttpPost(SeoRoutes.Tag + CRUDRouts.ReadListByFilter)]
    public async Task<PaginatedList<TagDto>> GetListByFilter([FromBody] string data)
    {
        var filter = await Task.Run(() => JsonSerializer.Deserialize<DefaultPaginationFilter>(data) ?? new());
        var entityList = await _unitOfWork.Tags.GetListByFilterAsync(filter);
        return await Task.Run(() => _mapper.Map<PaginatedList<TagDto>>(entityList));
    }
}