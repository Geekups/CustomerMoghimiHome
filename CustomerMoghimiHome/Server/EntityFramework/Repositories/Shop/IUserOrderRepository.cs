using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.Shop;

public interface IUserOrderRepository : IRepository<UserOrderEntity>
{
    Task<List<UserOrderEntity>> GetByUserId(string userId);
}
public class UserOrderRepository : Repository<UserOrderEntity>, IUserOrderRepository
{
    private readonly IQueryable<UserOrderEntity> _queryable;

    public UserOrderRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<UserOrderEntity>();
    }

    public async Task<List<UserOrderEntity>> GetByUserId(string userId)
    {
        return await _queryable.Where(x=>x.UserId == userId).ToListAsync();
    }
}