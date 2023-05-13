using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Customer;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Server.EntityFramework.Repositories.Shop;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.Customer;

public interface ICustomerDetailRepository : IRepository<CustomerDetailEntity>
{
}

public class CustomerDetailRepository : Repository<CustomerDetailEntity>, ICustomerDetailRepository
{
    private readonly IQueryable<CustomerDetailEntity> _queryable;

    public CustomerDetailRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<CustomerDetailEntity>();
    }
}