using CustomerMoghimiHome.Server.EntityFramework.Common;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;

public class BasketEntity : BaseEntity
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public int Quantity { get; set; }
    public long ProductId { get; set; }
}
