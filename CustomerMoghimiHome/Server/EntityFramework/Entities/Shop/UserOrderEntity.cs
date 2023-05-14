using CustomerMoghimiHome.Server.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;

public class UserOrderEntity : BaseEntity
{
    public string UserId { get; set; }
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public int ProductCount { get; set; }
    public long ProductTotalPrice { get; set; }
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