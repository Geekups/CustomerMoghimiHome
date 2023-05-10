using CustomerMoghimiHome.Shared.EntityFramework.Common;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class UserBasketDto : BaseDto
{
    public string UserId { get; set; }

    public long? CustomerDetailId { get; set; }
    public CustomerDetailDto CustomerDetail { get; set; }

    public long? UserOrderId { get; set; }
    public UserOrderDto UserOrder { get; set; }

    public List<ProductDto> ProductEntities { get; set; }
}
