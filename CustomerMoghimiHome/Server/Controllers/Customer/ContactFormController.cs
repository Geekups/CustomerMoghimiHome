using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Seo;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Seo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CustomerMoghimiHome.Server.Controllers.Customer;
[ApiController]
public class ContactFormController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserManager<IdentityUser> _userManager;

    public ContactFormController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<IdentityUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost(CustomerRoute.ContactForm + CRUDRouts.Create)]
    public async Task Create([FromBody] string data)
    {
        var dto = await Task.Run(() => JsonSerializer.Deserialize<AltDto>(data));
        if (dto != null)
        {
            dto.CreateDate = DateTime.Now; dto.ModifiedDate = DateTime.Now;
            var entity = await Task.Run(() => _mapper.Map<AltEntity>(dto));
            await _unitOfWork.Alts.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }
    }

    [HttpDelete(CustomerRoute.ContactForm + CRUDRouts.Delete + "/{data:long}")]
    public async Task Delete([FromRoute] long data)
    {
        var entity = await _unitOfWork.Alts.GetByIdAsync(data);
        await Task.Run(() => _unitOfWork.Alts.Remove(entity));
        await _unitOfWork.CommitAsync();
    }

    [HttpGet(CustomerRoute.ContactForm + CRUDRouts.ReadOneById + "/{data:long}")]
    public async Task<AltDto> GetById([FromRoute] long data) =>
        _mapper.Map<AltDto>(await _unitOfWork.Alts.GetByIdAsync(data));

    [HttpPost(CustomerRoute.ContactForm + CRUDRouts.ReadListByFilter)]
    public async Task<PaginatedList<AltDto>> GetListByFilter([FromBody] string data)
    {
        var filter = await Task.Run(() => JsonSerializer.Deserialize<DefaultPaginationFilter>(data) ?? new());
        var entityList = await _unitOfWork.Alts.GetListByFilterAsync(filter);
        return await Task.Run(() => _mapper.Map<PaginatedList<AltDto>>(entityList));
    }
}
