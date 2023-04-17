using CustomerMoghimiHome.Shared.EntityFramework.Common;
using System.ComponentModel.DataAnnotations;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Seo;
public class TagDto : BaseDto
{
    [Required(ErrorMessage = "لطفا Tag را وارد کنید.")]
    public string Tag { get; set; }
}
