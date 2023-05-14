using CustomerMoghimiHome.Server.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Customer;

public class CustomerDetailEntity : BaseEntity
{
    public string UserId { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string PhoneNumber { get; set; }
}

public class CustomerDetailEntityConfiguration : IEntityTypeConfiguration<CustomerDetailEntity>
{
    public void Configure(EntityTypeBuilder<CustomerDetailEntity> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.Address).IsRequired();
        builder.Property(e => e.PostalCode).IsRequired();

        #endregion
    }
}