using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Shared.Basic.Classes;

namespace CustomerMoghimiHome.Server.EntityFramework.Extensions.Shop;

public static class ProductCategoryEntityQueryableExtension
{
    public static IQueryable<ProductCategoryEntity> ApplyFilter(this IQueryable<ProductCategoryEntity> query, DefaultPaginationFilter filter)
    {

        if (!string.IsNullOrEmpty(filter.Keyword))
            query = query.Where(x => x.CategoryName.ToLower().Contains(filter.Keyword.ToLower().Trim())
            || x.CategoryDescription.ToLower().Contains(filter.Keyword.ToLower().Trim()));
        return query;
    }

    public static IQueryable<ProductCategoryEntity> ApplySort(this IQueryable<ProductCategoryEntity> query, SortByEnum? sortBy)
    {
        return sortBy switch
        {
            SortByEnum.CreationDate => query.OrderBy(x => x.CreateDate),
            SortByEnum.CreationDateDescending => query.OrderByDescending(x => x.CreateDate),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}