using CustomerMoghimiHome.Shared.EntityFramework.Common;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class ProductDto : BaseDto
{
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string BuilderCompany { get; set; } = "Microlab";
    public string ProductDescription { get; set; } = string.Empty;
    
    public long ProductCategoryEnityId { get; set; }
    public long PhotoEnityId { get; set; }
    public ProductCategoryDto ProductCategory { get; set; }
}
