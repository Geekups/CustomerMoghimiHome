using CustomerMoghimiHome.Server.Basic.Services;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace CustomerMoghimiHome.Server.Controllers.Identity
{

    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenExtension _tokenExtension;
        public LoginController(UserManager<IdentityUser> userManager, ITokenExtension tokenExtension)
        {
            _userManager = userManager;
            _tokenExtension = tokenExtension;
        }

        [HttpPost(AuthRoutes.LoginUser)]
        public async Task<IActionResult> LoginUser([FromBody] LoginModelDto loginModelDto)
        {
            var user = await _userManager.FindByEmailAsync(loginModelDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginModelDto.Password))
                return Unauthorized(new LoginResultDto { Error = "Invalid Authentication" });
            var signingCredentials = _tokenExtension.GetSigningCredentials();
            var claims = await _tokenExtension.GetClaimsAsync(user);
            var tokenOptions = _tokenExtension.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new LoginResultDto { IsAuthSuccessful = true, Token = token });
        }
    }
}
