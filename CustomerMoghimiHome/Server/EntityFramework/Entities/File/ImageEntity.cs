using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.BetweenTables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.File;

public class ImageEntity : BaseEntity
{
    public string Path { get; set; }
    // we put multiple alts (pre-defined alts) seprated with comma
    public string Alt { get; set; }

    public List<ImagesForProductEntity> ImageForProductList { get; set; }
}

public class ImageEntityConfiguration : IEntityTypeConfiguration<ImageEntity>
{
    public void Configure(EntityTypeBuilder<ImageEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(x => x.Path).IsRequired();
        builder.Property(x => x.Alt).IsRequired();
    }
}