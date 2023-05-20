using AutoMapper;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Identity;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CustomerMoghimiHome.Server.Controllers.Identity
{
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        public AccountsController(UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpPost(AuthRoutes.Register)]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();
            var user = new IdentityUser
            {
                UserName = userForRegistration.UserName,
                Email = userForRegistration.Email,
                PhoneNumber = userForRegistration.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }
            //await _userManager.AddToRoleAsync(user, "Viewer");
            return StatusCode(201);
        }

        //[HttpGet]
        //[Route("GetAllSiteUsers")]
        //public async Task<IActionResult> GetUsers([FromQuery] PagingParameters pagingParameters)
        //{
        //    var userDetailDtoList = _mapper.Map<List<UserDetailDto>>(await _userManager.Users.AsNoTracking().ToListAsync());
        //    var pagedData = PagedList<UserDetailDto>.ToPagedList(userDetailDtoList, pagingParameters.PageNumber, pagingParameters.PageSize);
        //    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagedData.MetaData));
        //    return Ok(pagedData);
        //}

        [HttpGet(AuthRoutes.Account + CRUDRouts.ReadOneById + "/{userEmail}")]
        public async Task<UserDetailDto> GetUserDetail([FromRoute]string UserEmail)
        {
            var user = await _userManager.FindByEmailAsync(UserEmail);
            return new UserDetailDto
            {
                Email = UserEmail,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                AccessFaildCount = user.AccessFailedCount,
                EmailConfimed = user.EmailConfirmed,
                PhoneNumberConfimed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled
            };
        }

        [HttpGet(AuthRoutes.Account + CRUDRouts.Update)]
        public async Task Update([FromBody] string data)
        {
            var dto = await Task.Run(() => JsonSerializer.Deserialize<UserDetailDto>(data));
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (dto != null)
            {
                IdentityUser identityUser = new()
                {
                    Id = user.Id,
                    Email = dto.Email,
                    UserName = dto.UserName,
                    AccessFailedCount = (int)dto.AccessFaildCount,
                    TwoFactorEnabled = dto.TwoFactorEnabled,
                    EmailConfirmed = dto.EmailConfimed,
                    PhoneNumberConfirmed = dto.PhoneNumberConfimed,
                    ConcurrencyStamp = user.ConcurrencyStamp,
                    LockoutEnabled = user.LockoutEnabled,
                    LockoutEnd = user.LockoutEnd,
                    NormalizedEmail = user.NormalizedEmail,
                    NormalizedUserName = user.NormalizedEmail,
                    PasswordHash = user.PasswordHash,
                    PhoneNumber = dto.PhoneNumber,
                    SecurityStamp = user.SecurityStamp,
                };
                await _userManager.UpdateAsync(identityUser);
            };
        }
    }
}
