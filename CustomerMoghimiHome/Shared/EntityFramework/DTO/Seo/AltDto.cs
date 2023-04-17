using CustomerMoghimiHome.Shared.EntityFramework.Common;
using System.ComponentModel.DataAnnotations;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Seo;
public class AltDto : BaseDto
{
    [Required(ErrorMessage = "لطفا ALT را وارد کنید.")]
    public string Alt { get; set; }
}
