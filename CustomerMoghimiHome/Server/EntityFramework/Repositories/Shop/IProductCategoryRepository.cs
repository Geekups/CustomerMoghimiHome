using CustomerMoghimiHome.Server.Basic.Classes;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Server.EntityFramework.Extensions.Shop;
using CustomerMoghimiHome.Shared.Basic.Classes;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.Shop;

public interface IProductCategoryRepository : IRepository<ProductCategoryEntity>
{
    Task<ProductCategoryEntity> GetProductCategoryByIdAsync(long id);
    Task<PaginatedList<ProductCategoryEntity>> GetProductCategoriesByFilterAsync(DefaultPaginationFilter filter);
    Task<List<ProductCategoryEntity>> GetProductCategoriesAsync();
}


public class ProductCategoryRepository : Repository<ProductCategoryEntity>, IProductCategoryRepository
{
    private readonly IQueryable<ProductCategoryEntity> _queryable;

    public ProductCategoryRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<ProductCategoryEntity>();
    }

    public async Task<ProductCategoryEntity> GetProductCategoryByIdAsync(long id) =>
         await _queryable.SingleOrDefaultAsync(x => x.Id == id) ?? throw new NullReferenceException();

    public async Task<List<ProductCategoryEntity>> GetProductCategoriesAsync() => await _queryable.ToListAsync();

    public async Task<PaginatedList<ProductCategoryEntity>> GetProductCategoriesByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable.AsNoTracking().ApplyFilter(filter).ApplySort(filter.SortBy);
        var dataTotalCount = _queryable.Count();

        return new PaginatedList<ProductCategoryEntity>()
        {
            Data = await query.Paginate(filter.Page, filter.PageSize).ToListAsync(),
            TotalCount = dataTotalCount,
            TotalPages = (int)Math.Ceiling((decimal)dataTotalCount / (decimal)filter.PageSize),
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }
}