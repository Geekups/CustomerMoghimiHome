using CustomerMoghimiHome.Server.Basic.Classes;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Server.EntityFramework.Extensions.Shop;
using CustomerMoghimiHome.Shared.Basic.Classes;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.Shop;

public interface IProductRepository : IRepository<ProductEntity>
{
    Task<ProductEntity> GetByIdAsync(long id);
    Task<PaginatedList<ProductEntity>> GetListByFilterAsync(DefaultPaginationFilter filter);
    Task<List<ProductEntity>> GetAllAsync();
}


public class ProductRepository : Repository<ProductEntity>, IProductRepository
{
    private readonly IQueryable<ProductEntity> _queryable;

    public ProductRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<ProductEntity>();
    }

    public async Task<ProductEntity> GetByIdAsync(long id) =>
         await _queryable.SingleOrDefaultAsync(x => x.Id == id);

    public async Task<List<ProductEntity>> GetAllAsync() => await _queryable.ToListAsync();

    public async Task<PaginatedList<ProductEntity>> GetListByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable.AsNoTracking().ApplyFilter(filter).ApplySort(filter.SortBy);
        var dataTotalCount = _queryable.Count();

        return new PaginatedList<ProductEntity>()
        {
            Data = await query.Paginate(filter.Page, filter.PageSize).ToListAsync(),
            TotalCount = dataTotalCount,
            TotalPages = (int)Math.Ceiling((decimal)dataTotalCount / (decimal)filter.PageSize),
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }
    // pg
    public IEnumerable<ProductEntity> GetProductCategoriesAsyncd()
    {
        foreach (var item in _queryable.ToList())
        {
            yield return item;
        }
    }
}