using CustomerMoghimiHome.Server.EntityFramework.Entities.Seo;
using CustomerMoghimiHome.Shared.Basic.Classes;

namespace CustomerMoghimiHome.Server.EntityFramework.Extensions.Seo;

public static class TagEntityQueryableExtension
{
    public static IQueryable<TagEntity> ApplyFilter(this IQueryable<TagEntity> query, DefaultPaginationFilter filter)
    {

        if (!string.IsNullOrEmpty(filter.StringValue))
            query = query.Where(x => x.Tag.ToLower().Contains(filter.StringValue.ToLower().Trim()));

        return query;
    }

    public static IQueryable<TagEntity> ApplySort(this IQueryable<TagEntity> query, SortByEnum? sortBy)
    {
        return sortBy switch
        {
            SortByEnum.CreationDate => query.OrderBy(x => x.CreateDate),
            SortByEnum.CreationDateDescending => query.OrderByDescending(x => x.CreateDate),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}
