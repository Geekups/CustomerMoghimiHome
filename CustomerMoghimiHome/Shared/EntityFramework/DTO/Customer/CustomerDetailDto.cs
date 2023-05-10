using CustomerMoghimiHome.Shared.EntityFramework.Common;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;
public class CustomerDetailDto : BaseDto
{
    public string UserId { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string PhoneNumber { get; set; }

    public long UserOrderId { get; set; }
    public UserOrderDto UserOrder { get; set; }
}
