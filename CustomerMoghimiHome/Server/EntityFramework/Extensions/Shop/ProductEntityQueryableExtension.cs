using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Shared.Basic.Classes;

namespace CustomerMoghimiHome.Server.EntityFramework.Extensions.Shop;

public static class ProductEntityQueryableExtension
{
    public static IQueryable<ProductEntity> ApplyFilter(this IQueryable<ProductEntity> query, DefaultPaginationFilter filter)
    {
        string categoryStringId = filter.StringValue != null ? filter.StringValue : "0";
        long CategoryLongId = long.Parse(categoryStringId);
        if (CategoryLongId != 0)
            query = query.Where(x => x.ProductCategoryEntityId == CategoryLongId);

        if (!string.IsNullOrEmpty(filter.Title))
            query = query.Where(x => x.ProductName.ToLower().Contains(filter.Title.ToLower().Trim()));

        return query;
    }

    public static IQueryable<ProductEntity> ApplySort(this IQueryable<ProductEntity> query, SortByEnum? sortBy)
    {
        return sortBy switch
        {
            SortByEnum.CreationDate => query.OrderBy(x => x.CreateDate),
            SortByEnum.CreationDateDescending => query.OrderByDescending(x => x.CreateDate),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}