using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.Shop;

public interface IUserOrderRepository : IRepository<UserOrderEntity>
{
}
public class UserOrderRepository : Repository<UserOrderEntity>, IUserOrderRepository
{
    private readonly IQueryable<UserOrderEntity> _queryable;

    public UserOrderRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<UserOrderEntity>();
    }
}