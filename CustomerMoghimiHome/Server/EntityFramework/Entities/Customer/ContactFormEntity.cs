using CustomerMoghimiHome.Server.EntityFramework.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Customer;

public class ContactFormEntity: BaseEntity
{
    public string UserId { get; set; }
    public string Subject { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Massage { get; set; }
}
public class ContactFormEntityConfiguration : IEntityTypeConfiguration<ContactFormEntity>
{
    public void Configure(EntityTypeBuilder<ContactFormEntity> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.Email).IsRequired();
        builder.Property(e => e.Massage).IsRequired();

        #endregion
    }
}