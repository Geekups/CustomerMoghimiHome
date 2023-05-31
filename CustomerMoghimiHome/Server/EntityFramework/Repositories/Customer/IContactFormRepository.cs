using CustomerMoghimiHome.Server.Basic.Classes;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Customer;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Server.EntityFramework.Extensions.Customer;
using CustomerMoghimiHome.Shared.Basic.Classes;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.Customer;

public interface IContactFormRepository: IRepository<ContactFormEntity>
{
    Task<ContactFormEntity> GetByIdAsync(long id);
    Task<PaginatedList<ContactFormEntity>> GetListByFilterAsync(DefaultPaginationFilter filter);
}

public class ContactFormRepository : Repository<ContactFormEntity>, IContactFormRepository
{
    private readonly IQueryable<ContactFormEntity> _queryable;

    public ContactFormRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<ContactFormEntity>();
    }

    public async Task<ContactFormEntity> GetByIdAsync(long id) =>
         await _queryable.SingleOrDefaultAsync(x => x.Id == id);

    public async Task<PaginatedList<ContactFormEntity>> GetListByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable.AsNoTracking().ApplyFilter(filter).ApplySort(filter.SortBy);
        var dataTotalCount = _queryable.Count();

        return new PaginatedList<ContactFormEntity>()
        {
            Data = await query.Paginate(filter.Page, filter.PageSize).ToListAsync(),
            TotalCount = dataTotalCount,
            TotalPages = (int)Math.Ceiling((decimal)dataTotalCount / (decimal)filter.PageSize),
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }
}