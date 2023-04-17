using CustomerMoghimiHome.Server.Basic.Classes;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Seo;
using CustomerMoghimiHome.Server.EntityFramework.Extensions.Seo;
using CustomerMoghimiHome.Shared.Basic.Classes;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.Seo;

public interface IAltRepository : IRepository<AltEntity>
{
    Task<AltEntity> GetByIdAsync(long id);
    Task<PaginatedList<AltEntity>> GetListByFilterAsync(DefaultPaginationFilter filter);
    Task<List<AltEntity>> GetAllAsync();
}

public class AltRepository : Repository<AltEntity>, IAltRepository
{
    private readonly IQueryable<AltEntity> _queryable;

    public AltRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<AltEntity>();
    }

    public async Task<AltEntity> GetByIdAsync(long id) =>
         await _queryable.SingleOrDefaultAsync(x => x.Id == id) ?? throw new NullReferenceException();

    public async Task<List<AltEntity>> GetAllAsync() => await _queryable.ToListAsync();

    public async Task<PaginatedList<AltEntity>> GetListByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable.AsNoTracking().ApplyFilter(filter).ApplySort(filter.SortBy);
        var dataTotalCount = _queryable.Count();

        return new PaginatedList<AltEntity>()
        {
            Data = await query.Paginate(filter.Page, filter.PageSize).ToListAsync(),
            TotalCount = dataTotalCount,
            TotalPages = (int)Math.Ceiling((decimal)dataTotalCount / (decimal)filter.PageSize),
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }
}