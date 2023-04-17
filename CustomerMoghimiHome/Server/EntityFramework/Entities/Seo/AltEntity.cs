using CustomerMoghimiHome.Server.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Seo;

public class AltEntity : BaseEntity
{
    public string Alt { get; set; }
}

public class AltEntityConfiguration : IEntityTypeConfiguration<AltEntity>
{
    public void Configure(EntityTypeBuilder<AltEntity> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Alt).IsRequired();
        #endregion
    }
}
