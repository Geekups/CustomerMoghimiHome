using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Customer;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Seo;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;
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
        var dto = await Task.Run(() => JsonSerializer.Deserialize<ContactFormDto>(data));
        if (dto != null)
        {
            var user = await _userManager.FindByEmailAsync(dto.UserName);
            dto.UserId = user.Id;
            dto.CreateDate = DateTime.Now; dto.ModifiedDate = DateTime.Now;
            var entity = await Task.Run(() => _mapper.Map<ContactFormEntity>(dto));
            await _unitOfWork.ContactForms.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }
    }

    //[HttpDelete(CustomerRoute.ContactForm + CRUDRouts.Delete + "/{data:long}")]
    //public async Task Delete([FromRoute] long data)
    //{
    //    var entity = await _unitOfWork.ContactForms.GetByIdAsync(data);
    //    await Task.Run(() => _unitOfWork.ContactForms.Remove(entity));
    //    await _unitOfWork.CommitAsync();
    //}

    //[HttpGet(CustomerRoute.ContactForm + CRUDRouts.ReadOneById + "/{data:long}")]
    //public async Task<AltDto> GetById([FromRoute] long data) =>
    //    _mapper.Map<AltDto>(await _unitOfWork.Alts.GetByIdAsync(data));

    //[HttpPost(CustomerRoute.ContactForm + CRUDRouts.ReadListByFilter)]
    //public async Task<PaginatedList<AltDto>> GetListByFilter([FromBody] string data)
    //{
    //    var filter = await Task.Run(() => JsonSerializer.Deserialize<DefaultPaginationFilter>(data) ?? new());
    //    var entityList = await _unitOfWork.Alts.GetListByFilterAsync(filter);
    //    return await Task.Run(() => _mapper.Map<PaginatedList<AltDto>>(entityList));
    //}
}
