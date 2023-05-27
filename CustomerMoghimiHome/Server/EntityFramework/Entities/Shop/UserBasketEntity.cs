using CustomerMoghimiHome.Server.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;

public class UserBasketEntity : BaseEntity
{
    public string UserId { get; set; }
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductCount { get; set; }
    public decimal ProductTotalPrice { get; set; }
    public bool IsOrdered { get; set; }
    public List<ProductEntity> ProductEntities { get; set; }
}


public class UserBasketEntityConfiguration : IEntityTypeConfiguration<UserBasketEntity>
{
    public void Configure(EntityTypeBuilder<UserBasketEntity> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.ProductTotalPrice).IsRequired().HasColumnType("decimal(24,4)");
        builder.Property(e => e.ProductPrice).IsRequired().HasColumnType("decimal(24,4)");
        #endregion
    }
}