using CustomerMoghimiHome.Server.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
public class ProductEntity : BaseEntity
{
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string BuilderCompany { get; set; } = "Microlab";
    public string ProductDescription { get; set; } = string.Empty;
    public string ImagePath { get; set; }

    public long ProductCategoryEnityId { get; set; }
    public ProductCategoryEntity ProductCategory { get; set; }
}

public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);
        builder.Property(e => e.ProductName).IsRequired();
        builder.Property(e => e.Price).IsRequired().HasColumnType("decimal(24,4)");
        builder.Property(e => e.ProductDescription).IsRequired();
        builder.Property(e => e.BuilderCompany).IsRequired();
        #endregion
    }
}