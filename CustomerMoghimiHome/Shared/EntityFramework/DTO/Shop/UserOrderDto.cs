using CustomerMoghimiHome.Shared.EntityFramework.Common;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class UserOrderDto : BaseDto
{
    public string UserId { get; set; }

    public CustomerDetailDto CustomerDetail { get; set; }

    public long UserBasketId { get; set; }
    public UserBasketDto UserBasket { get; set; }
}
