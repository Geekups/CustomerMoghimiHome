using CustomerMoghimiHome.Shared.EntityFramework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;
public class ContactFormDto: BaseDto
{
    public string UserId { get; set; }
    public string Subject { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Message { get; set; }
}
