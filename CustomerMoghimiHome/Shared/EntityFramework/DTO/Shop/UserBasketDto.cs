using CustomerMoghimiHome.Shared.EntityFramework.Common;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class UserBasketDto : BaseDto
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public long SelectedProductId { get; set; }
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductCount { get; set; }
    public decimal ProductTotalPrice { get; set; }
    public List<ProductDto> Products { get; set; }
}
