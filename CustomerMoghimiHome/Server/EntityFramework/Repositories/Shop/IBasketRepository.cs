﻿using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.Shop;

public interface IBasketRepository : IRepository<BasketEntity>
{
    Task<List<BasketEntity>> GetAllUserBasketAsync(string UserName);
}


public class BasketRepository : Repository<BasketEntity>, IBasketRepository
{
    private readonly IQueryable<BasketEntity> _queryable;

    public BasketRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<BasketEntity>();
    }

    public async Task<List<BasketEntity>> GetAllUserBasketAsync(string UserName) =>
        await _queryable.Where(x => x.UserName == UserName).ToListAsync();
  
}