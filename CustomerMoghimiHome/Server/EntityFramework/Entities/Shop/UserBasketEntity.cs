using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;

public class UserBasketEntity : BaseEntity
{
    public string UserId { get; set; }

    public long CustomerDetailId { get; set; }
    public CustomerDetailEntity CustomerDetail { get; set; }

    public long? UserOrderId { get; set; }
    public UserOrderEntity UserOrder { get; set; }

    public List<ProductEntity> ProductEntities { get; set; }
}


public class UserBasketEntityConfiguration : IEntityTypeConfiguration<UserBasketEntity>
{
    public void Configure(EntityTypeBuilder<UserBasketEntity> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);
        builder.Property(e => e.UserId).IsRequired();

        #endregion
        builder.HasOne(s => s.CustomerDetail)
        .WithOne(ad => ad.UserBasket).
        HasForeignKey<UserBasketEntity>(ad => ad.CustomerDetailId);
        builder.HasOne(s => s.UserOrder)
      .WithOne(ad => ad.UserBasket).
      HasForeignKey<UserBasketEntity>(ad => ad.UserOrderId);
    }
}