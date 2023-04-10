using CustomerMoghimiHome.Shared.EntityFramework.Common;

namespace CustomerMoghimiHome.Shared.EntityFramework.Entities.Shop;
public class ProductCategoryEntity : BaseEntity
{
    public string CategoryName { get; set; } = string.Empty;
    public string CategoryDescription { get; set; } = string.Empty;

    public List<ProductEntity> ProductEntities { get; set; } = new();
}
