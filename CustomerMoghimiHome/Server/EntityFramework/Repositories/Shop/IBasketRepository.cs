using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.Shop;

public interface IBasketRepository : IRepository<BasketEntity>
{
    Task<List<BasketEntity>> GetAllUserBasketAsync(string userId);
    Task<bool> IsExistWithUserIdAndProductIdAsync(string userId, long productId);
    Task<BasketEntity> GetBasketWithUserIdAndProductIdAsync(string userId, long productId);
}


public class BasketRepository : Repository<BasketEntity>, IBasketRepository
{
    private readonly IQueryable<BasketEntity> _queryable;

    public BasketRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<BasketEntity>();
    }

    public async Task<List<BasketEntity>> GetAllUserBasketAsync(string userId) =>
        await _queryable.Where(x => x.UserId == userId).ToListAsync();

    public async Task<BasketEntity> GetBasketWithUserIdAndProductIdAsync(string userId, long productId)
    {
        return await _queryable.FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);
    }

    public async Task<bool> IsExistWithUserIdAndProductIdAsync(string userId, long productId)
    {
       return await _queryable.AnyAsync(x=> x.UserId == userId && x.ProductId == productId);
    }
}