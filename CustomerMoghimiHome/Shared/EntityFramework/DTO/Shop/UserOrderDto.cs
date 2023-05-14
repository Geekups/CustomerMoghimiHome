using CustomerMoghimiHome.Shared.EntityFramework.Common;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class UserOrderDto : BaseDto
{
    public string UserId { get; set; }
    public long ProductId { get; set; }
    public string ProductName { get; set; } 
    public int ProductCount { get; set; }
    public long ProductTotalPrice { get; set; }

    public long UserBasketId { get; set; }
    public UserBasketDto UserBasket { get; set; }
}
