using CustomerMoghimiHome.Server.EntityFramework.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
public class ProductCategoryEntity : BaseEntity
{
    public string CategoryName { get; set; } = string.Empty;
    public string CategoryDescription { get; set; } = string.Empty;
    public string CategoryPictureAddress { get; set; } = string.Empty;

    public List<ProductEntity> ProductEntities { get; set; } = new();
}

public class ProductCategoryEntityConfiguration : IEntityTypeConfiguration<ProductCategoryEntity>
{
    public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);
        builder.Property(e => e.CategoryName).IsRequired();
        builder.Property(e => e.CategoryName).IsRequired();
        builder.Property(e => e.CategoryPictureAddress).IsRequired();
        #endregion
    }
}