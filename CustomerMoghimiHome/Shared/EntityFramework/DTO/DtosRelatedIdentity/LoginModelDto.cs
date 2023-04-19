using System.ComponentModel.DataAnnotations;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.DtosRelatedIdentity
{
    public class LoginModelDto
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
