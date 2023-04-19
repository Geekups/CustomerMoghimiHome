using System.Reflection;
using System.Text;

namespace CustomerMoghimiHome.Shared.Basic.Services
{
    public static class BlogPostQueryableExtensions
    {
        public static IQueryable<BlogPostDmo> Search(this IQueryable<BlogPostDmo> data, string searchTearm)
        {
            if (string.IsNullOrWhiteSpace(searchTearm))
                return data;
            var lowerCaseSearchTerm = searchTearm.Trim().ToLower();
            return data.Where(p => p.PostName.ToLower().Contains(lowerCaseSearchTerm));
        }

        public static IQueryable<BlogPostDmo> Sort(this IQueryable<BlogPostDmo> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return data.OrderBy(e => e.PostName);

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(BlogPostDmo).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name
                .Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
                return data.OrderBy(e => e.PostName);

            return data.OrderBy(orderQuery);
        }
    }


    public static class ProductQueryableExtensions
    {
        public static IQueryable<ProductDmo> Search(this IQueryable<ProductDmo> data, string searchTearm)
        {
            if (string.IsNullOrWhiteSpace(searchTearm))
                return data;
            var lowerCaseSearchTerm = searchTearm.Trim().ToLower();
            return data.Where(p => p.Name.ToLower().Contains(lowerCaseSearchTerm));
        }

        public static IQueryable<ProductDmo> Sort(this IQueryable<ProductDmo> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return data.OrderBy(e => e.Name);

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(ProductDmo).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name
                .Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
                return data.OrderBy(e => e.Name);

            return data.OrderBy(orderQuery);
        }
    }
}
