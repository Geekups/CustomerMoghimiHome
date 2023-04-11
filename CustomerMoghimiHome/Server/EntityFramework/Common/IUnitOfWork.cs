using CustomerMoghimiHome.Server.EntityFramework.Repositories.Shop;

namespace CustomerMoghimiHome.Server.EntityFramework.Common;
public interface IUnitOfWork : IDisposable
{
    IProductCategoryRepository ProductCategories { get; }
    Task<bool> CommitAsync();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    public IProductCategoryRepository ProductCategories { get; }

    public async Task<bool> CommitAsync() => await _context.SaveChangesAsync() > 0;
    public void Dispose() => _context.Dispose();

    public UnitOfWork(DataContext context)
    {
        _context = context;
        ProductCategories = new ProductCategoryRepository(_context);
    }
}
