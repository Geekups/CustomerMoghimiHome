using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Customer;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.Customer;

public interface ICustomerDetailRepository : IRepository<CustomerDetailEntity>
{
    Task<CustomerDetailEntity> GetByUserIdAsync(string userId);
}

public class CustomerDetailRepository : Repository<CustomerDetailEntity>, ICustomerDetailRepository
{
    private readonly IQueryable<CustomerDetailEntity> _queryable;

    public CustomerDetailRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<CustomerDetailEntity>();
    }

    public async Task<CustomerDetailEntity> GetByUserIdAsync(string userId)
    {
        return await _queryable.SingleOrDefaultAsync(x => x.UserId == userId);
    }
}