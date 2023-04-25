using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.BetweenTables;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Server.EntityFramework.Repositories.Shop;
using CustomerMoghimiHome.Shared.Basic.Classes;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.BetweenTables;

public interface IImageForProductRepository : IRepository<ImagesForProductEntity>
{
    Task<ImagesForProductEntity> GetByIdAsync(long id);
    // maybe this will solve the paginate product main page data bitch
   //Task<PaginatedList<ProductEntity>> GetListByFilterAsync(DefaultPaginationFilter filter);
    Task<List<ImagesForProductEntity>> GetAllAsync();
}


public class ImagesForProductRepository : Repository<ImagesForProductEntity>, IImageForProductRepository
{
    private readonly IQueryable<ImagesForProductEntity> _queryable;

    public ImagesForProductRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<ImagesForProductEntity>();
    }

    public async Task<ImagesForProductEntity> GetByIdAsync(long id) =>
         await _queryable.SingleOrDefaultAsync(x => x.Id == id) ?? throw new NullReferenceException();

    public async Task<List<ImagesForProductEntity>> GetAllAsync() => await _queryable.ToListAsync();

}