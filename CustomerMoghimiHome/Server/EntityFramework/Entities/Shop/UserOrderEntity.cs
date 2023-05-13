using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;

public class UserOrderEntity : BaseEntity
{
    public string UserId { get; set; }

    public CustomerDetailEntity? CustomerDetailEntity { get; set; }

    public long? UserBasketId { get; set; }
    public UserBasketEntity? UserBasket { get; set; }
}

public class UserOrderEntityConfiguration : IEntityTypeConfiguration<UserOrderEntity>
{
    public void Configure(EntityTypeBuilder<UserOrderEntity> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);
        builder.Property(e => e.UserId).IsRequired();

        #endregion

        builder.HasOne(s => s.UserBasket)
        .WithOne(ad => ad.UserOrder).
        HasForeignKey<UserOrderEntity>(ad => ad.UserBasketId);
    }
}