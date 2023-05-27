using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Customer;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.Customer;

public interface IContactFormRepository: IRepository<ContactFormEntity>
{
}

public class ContactFormRepository : Repository<ContactFormEntity>, IContactFormRepository
{
    private readonly IQueryable<CustomerDetailEntity> _queryable;

    public ContactFormRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<CustomerDetailEntity>();
    }
}