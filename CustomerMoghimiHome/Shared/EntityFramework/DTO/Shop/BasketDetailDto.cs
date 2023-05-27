using CustomerMoghimiHome.Shared.EntityFramework.Common;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class BasketDetailDto : BaseDto
{
    public string? UserEmail { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public string BuilderCompany { get; set; }
    public string ImagePath { get; set; }
    public string ImageAlt { get; set; }
    public decimal ProductTotalPrice { get; set; }
    public int Quantity { get; set; }
}