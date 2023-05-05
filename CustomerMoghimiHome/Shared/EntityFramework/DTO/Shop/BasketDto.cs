using CustomerMoghimiHome.Shared.EntityFramework.Common;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class BasketDto : BaseDto
{
    public string UserId { get; set; }
    public int Quantity { get; set; }
    public long ProductId { get; set; }
}
