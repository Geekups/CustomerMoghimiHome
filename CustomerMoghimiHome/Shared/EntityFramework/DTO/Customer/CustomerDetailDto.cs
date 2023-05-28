using CustomerMoghimiHome.Shared.EntityFramework.Common;
using System.ComponentModel.DataAnnotations;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;
public class CustomerDetailDto : BaseDto
{
    public string UserId { get; set; }
    [Required(ErrorMessage = "لطفا مقدار نام کاربری را پر کنید")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "لطفا مقدار نام کامل را پر کنید")]
    public string FullName { get; set; }
    [Required(ErrorMessage = "لطفا مقدار آدرس را پر کنید")]
    public string Address { get; set; }
    [Required(ErrorMessage = "لطفا مقدار کد پستی را پر کنید")]
    public string PostalCode { get; set; }
    public string PhoneNumber { get; set; }

}
