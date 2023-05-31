using CustomerMoghimiHome.Server.EntityFramework.Entities.Customer;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Seo;
using CustomerMoghimiHome.Shared.Basic.Classes;

namespace CustomerMoghimiHome.Server.EntityFramework.Extensions.Customer;
public static class ContactFormEntityQueryableExtension
{
    public static IQueryable<ContactFormEntity> ApplyFilter(this IQueryable<ContactFormEntity> query, DefaultPaginationFilter filter)
    {

        if (!string.IsNullOrEmpty(filter.StringValue))
            query = query.Where(x => x.Subject.ToLower().Contains(filter.StringValue.ToLower().Trim()));

        return query;
    }

    public static IQueryable<ContactFormEntity> ApplySort(this IQueryable<ContactFormEntity> query, SortByEnum? sortBy)
    {
        return sortBy switch
        {
            SortByEnum.CreationDate => query.OrderBy(x => x.CreateDate),
            SortByEnum.CreationDateDescending => query.OrderByDescending(x => x.CreateDate),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}
