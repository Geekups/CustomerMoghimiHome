using System.ComponentModel.DataAnnotations;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Identity
{
    public class UserDetailDto
    {
        [Required(ErrorMessage ="لطفا مقدار نام کاربری را پر کنید")]
        public string? UserName { get; set; }
        [EmailAddress(ErrorMessage = "لطفا مقدار ایمیل را با فرمت درست پر کنید")]
        [Required(ErrorMessage = "لطفا مقدار ایمیل را پر کنید")]
        public string? Email { get; set; }
        public bool EmailConfimed { get; set; }
        [Required(ErrorMessage = "لطفا مقدار شماره تلفن را پر کنید")]
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfimed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public long AccessFaildCount { get; set; }

    }
}
