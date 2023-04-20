using AutoMapper;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
    }
}
