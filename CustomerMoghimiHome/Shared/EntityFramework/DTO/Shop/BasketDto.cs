using CustomerMoghimiHome.Shared.EntityFramework.Common;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class BasketDto : BaseDto
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public int Quantity { get; set; } = 1;
    public long ProductId { get; set; }
}
