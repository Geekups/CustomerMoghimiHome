using CustomerMoghimiHome.Server.EntityFramework.Entities.Seo;
using CustomerMoghimiHome.Shared.Basic.Classes;

namespace CustomerMoghimiHome.Server.EntityFramework.Extensions.Seo;

public static class AltEntityQueryableExtension
{
    public static IQueryable<AltEntity> ApplyFilter(this IQueryable<AltEntity> query, DefaultPaginationFilter filter)
    {

        if (!string.IsNullOrEmpty(filter.StringValue))
            query = query.Where(x => x.Alt.ToLower().Contains(filter.StringValue.ToLower().Trim()));

        return query;
    }

    public static IQueryable<AltEntity> ApplySort(this IQueryable<AltEntity> query, SortByEnum? sortBy)
    {
        return sortBy switch
        {
            SortByEnum.CreationDate => query.OrderBy(x => x.CreateDate),
            SortByEnum.CreationDateDescending => query.OrderByDescending(x => x.CreateDate),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}
