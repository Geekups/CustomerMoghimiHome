using System.ComponentModel.DataAnnotations;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Identity
{
    public class UserForRegistrationDto
    {
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید.")]
        public string UserName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "لطفا ایمیلتان را وارد کنید.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا شماره تماستان را وارد کنید.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "لطفا پسوردتان را وارد کنید.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا پسوردتان را مجددا وارد کنید.")]
        [Compare("Password", ErrorMessage = "پسورد های وارد شده با یکدیگر همخوانی ندارند.")]
        public string ConfirmPassword { get; set; }
    }
}
