using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.Shop;

public interface IBasketProductRepository : IRepository<BasketProductEntity>
{
    Task<List<BasketProductEntity>> GetByUserBasketIdAsync(long id);
    int GetCountByProductId(long id);
    Task<List<BasketProductEntity>> TakeSpecificCountWithCondition(int count, long id);
}

public class BasketProductRepository : Repository<BasketProductEntity>, IBasketProductRepository
{
    private readonly IQueryable<BasketProductEntity> _queryable;

    public BasketProductRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<BasketProductEntity>();
    }

    public async Task<List<BasketProductEntity>> GetByUserBasketIdAsync(long id) =>
         await _queryable.Where(x => x.BasketId == id).ToListAsync();

    public int GetCountByProductId(long id)
    {
        return _queryable.Where((x) => x.ProductId == id).Count();
    }

    public Task<List<BasketProductEntity>> TakeSpecificCountWithCondition(int count, long id)
    {
        return _queryable.Where(x => x.ProductId == id).Take(count).ToListAsync();
    }
}
