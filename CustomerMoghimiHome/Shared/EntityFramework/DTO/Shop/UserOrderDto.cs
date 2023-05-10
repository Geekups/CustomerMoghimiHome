using CustomerMoghimiHome.Shared.EntityFramework.Common;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class UserOrderDto : BaseDto
{
    public string UserId { get; set; }
    public UserBasketDto UserBasket { get; set; }
}
