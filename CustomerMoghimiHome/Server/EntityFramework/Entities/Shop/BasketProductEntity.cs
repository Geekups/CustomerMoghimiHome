using CustomerMoghimiHome.Server.EntityFramework.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;

public class BasketProductEntity:BaseEntity
{
    public long BasketId { get; set; }
    public long ProductId { get; set; }
}

public class BasketProductEntityConfiguration : IEntityTypeConfiguration<BasketProductEntity>
{
    public void Configure(EntityTypeBuilder<BasketProductEntity> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);
        builder.Property(e => e.BasketId).IsRequired();
        builder.Property(e => e.ProductId).IsRequired();
        #endregion
        builder.HasKey(sc => new { sc.BasketId, sc.ProductId });
    }
}