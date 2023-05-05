using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.Shop;

public interface IBasketRepository : IRepository<BasketEntity>
{
    Task<BasketEntity> GetByUserIdAsync(string id);
}


public class BasketRepository : Repository<BasketEntity>, IBasketRepository
{
    private readonly IQueryable<BasketEntity> _queryable;

    public BasketRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<BasketEntity>();
    }

    public async Task<BasketEntity> GetByUserIdAsync(string id) =>
         await _queryable.SingleOrDefaultAsync(x => x.UserId == id) ?? throw new NullReferenceException();

}