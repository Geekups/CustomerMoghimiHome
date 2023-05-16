using CustomerMoghimiHome.Server.EntityFramework.Repositories.Customer;
using CustomerMoghimiHome.Server.EntityFramework.Repositories.Seo;
using CustomerMoghimiHome.Server.EntityFramework.Repositories.Shop;

namespace CustomerMoghimiHome.Server.EntityFramework.Common;
public interface IUnitOfWork : IDisposable
{
    IProductCategoryRepository ProductCategories { get; }
    IProductRepository Products { get; }
    IAltRepository Alts { get; }
    ITagRepository Tags { get; }
    IBasketRepository Baskets { get; }
    IBasketProductRepository BasketProducts { get; }
    ICustomerDetailRepository CustomerDetails { get; }
    Task<bool> CommitAsync();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    public IProductCategoryRepository ProductCategories { get; }
    public IProductRepository Products { get; }
    public IAltRepository Alts { get; }
    public ITagRepository Tags { get; }
    public IBasketRepository Baskets { get; }
    public IBasketProductRepository BasketProducts { get; }
    public ICustomerDetailRepository CustomerDetails { get; }
    public async Task<bool> CommitAsync() => await _context.SaveChangesAsync() > 0;
    public void Dispose() => _context.Dispose();

    public UnitOfWork(DataContext context)
    {
        _context = context;
        ProductCategories = new ProductCategoryRepository(_context);
        Products = new ProductRepository(_context);
        Alts = new AltRepository(_context);
        Tags = new TagRepository(_context);
        Baskets = new BasketRepository(_context);
        BasketProducts = new BasketProductRepository(_context);
        CustomerDetails = new CustomerDetailRepository(_context);
    }
}
