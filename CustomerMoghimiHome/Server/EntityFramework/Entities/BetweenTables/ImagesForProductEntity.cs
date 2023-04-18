using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.File;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.BetweenTables;

public class ImagesForProductEntity : BaseEntity
{
    public long ImageId { get; set; }
    public long ProductId { get; set; }

    public ProductEntity Product { get; set; }
    public ImageEntity Image { get; set; }
}


public class ImagesForProductEntityConfiguration : IEntityTypeConfiguration<ImagesForProductEntity>
{
    public void Configure(EntityTypeBuilder<ImagesForProductEntity> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);
        builder.Property(e => e.ImageId).IsRequired();
        builder.Property(e => e.ProductId).IsRequired();

        builder.HasOne(x => x.Product).WithMany(x => x.ImageForProductList).HasForeignKey(x => x.ProductId);
        builder.HasOne(x => x.Image).WithMany(x => x.ImageForProductList).HasForeignKey(x => x.ImageId);
        #endregion
    }
}
