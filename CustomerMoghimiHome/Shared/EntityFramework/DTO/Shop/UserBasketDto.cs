using CustomerMoghimiHome.Shared.EntityFramework.Common;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class UserBasketDto : BaseDto
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public long SelectedProductId { get; set; }
    public UserOrderDto UserOrder { get; set; }
    public List<ProductDto> Products { get; set; }
}
