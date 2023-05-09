using CustomerMoghimiHome.Shared.EntityFramework.Common;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;
public class CustomerDetailDto: BaseDto
{
    public string UserId { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string PhoneNumber { get; set; }

    public UserBasketDto UserBasket { get; set; }
}
