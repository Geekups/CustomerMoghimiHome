using CustomerMoghimiHome.Server.Basic.Classes;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Seo;
using CustomerMoghimiHome.Server.EntityFramework.Extensions.Seo;
using CustomerMoghimiHome.Shared.Basic.Classes;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.Seo;

public interface ITagRepository : IRepository<TagEntity>
{
    Task<TagEntity> GetByIdAsync(long id);
    Task<PaginatedList<TagEntity>> GetListByFilterAsync(DefaultPaginationFilter filter);
    Task<List<TagEntity>> GetAllAsync();
}

public class TagRepository : Repository<TagEntity>, ITagRepository
{
    private readonly IQueryable<TagEntity> _queryable;

    public TagRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<TagEntity>();
    }

    public async Task<TagEntity> GetByIdAsync(long id) =>
         await _queryable.SingleOrDefaultAsync(x => x.Id == id) ?? throw new NullReferenceException();

    public async Task<List<TagEntity>> GetAllAsync() => await _queryable.ToListAsync();

    public async Task<PaginatedList<TagEntity>> GetListByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable.AsNoTracking().ApplyFilter(filter).ApplySort(filter.SortBy);
        var dataTotalCount = _queryable.Count();

        return new PaginatedList<TagEntity>()
        {
            Data = await query.Paginate(filter.Page, filter.PageSize).ToListAsync(),
            TotalCount = dataTotalCount,
            TotalPages = (int)Math.Ceiling((decimal)dataTotalCount / (decimal)filter.PageSize),
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }
}