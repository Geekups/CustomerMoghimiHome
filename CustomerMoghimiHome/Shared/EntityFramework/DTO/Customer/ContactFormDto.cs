using CustomerMoghimiHome.Shared.EntityFramework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;
public class ContactFormDto: BaseDto
{
    public string UserName { get; set; }
    public string UserId { get; set; }
    [Required(ErrorMessage = "لطفا موضوع پیام را وارد کنید.")]
    public string Subject { get; set; }
    [EmailAddress]
    [Required(ErrorMessage = "لطفا ایمیلتان را وارد کنید.")]
    public string Email { get; set; }
    [Phone]
    [Required(ErrorMessage = "لطفا شماره تماستان را وارد کنید.")]
    public string Phone { get; set; }
    [Required(ErrorMessage = "لطفا پیام مد نظر را وارد کنید.")]
    public string Message { get; set; }
}
