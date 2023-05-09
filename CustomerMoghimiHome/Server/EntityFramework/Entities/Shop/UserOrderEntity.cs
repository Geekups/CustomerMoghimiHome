using CustomerMoghimiHome.Server.EntityFramework.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;

public class UserOrderEntity:BaseEntity
{
    public string UserId { get; set; }
    public UserBasketEntity UserBasket { get; set; }
}

public class UserOrderEntityConfiguration : IEntityTypeConfiguration<UserOrderEntity>
{
    public void Configure(EntityTypeBuilder<UserOrderEntity> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);
        builder.Property(e => e.UserId).IsRequired();

        #endregion
    }
}