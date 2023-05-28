using System.ComponentModel.DataAnnotations;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Identity
{
    public class LoginModelDto
    {
        [Required(ErrorMessage = "لطفا ایمیلتان را وارد کنید.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "لطفا پسوردتان را وارد کنید.")]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
