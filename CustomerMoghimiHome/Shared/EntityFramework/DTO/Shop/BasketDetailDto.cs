using CustomerMoghimiHome.Shared.EntityFramework.Common;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class BasketDetailDto : BaseDto
{
    public string? UserEmail { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string BuilderCompany { get; set; } = "Microlab";
    public string ImagePath { get; set; }
    public decimal ProductTotalPrice { get; set; }
    public int Quantity { get; set; }
}