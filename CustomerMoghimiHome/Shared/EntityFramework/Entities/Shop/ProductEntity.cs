using CustomerMoghimiHome.Shared.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerMoghimiHome.Shared.EntityFramework.Entities.Shop;
public class ProductEntity : BaseEntity
{
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string BuilderCompany { get; set; } = "Microlab";
    public string ProductDescription { get; set; } = string.Empty;

    public long ProductCategoryEnityId { get; set; }
    public ProductCategoryEntity ProductCategory { get; set; }
}

public class vConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);
        builder.Property(e => e.ProductName).IsRequired();
        builder.Property(e => e.Price).IsRequired();
        builder.Property(e => e.ProductDescription).IsRequired();
        builder.Property(e => e.BuilderCompany).IsRequired();
        #endregion

        builder.HasOne(x => x.ProductCategory).WithMany(x => x.ProductEntities)
            .HasForeignKey(x => x.ProductCategoryEnityId).OnDelete(DeleteBehavior.Cascade);
    }
}