using Catalyte.Apparel.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace Catalyte.Apparel.Data.Filters
{
    public static class ProductFiltersBase
    {
        public static IQueryable<Product> ProductDistinctCategories(this IEnumerable<Product> products)
        {
            var QueryCategories = products.Select(i => i.Category);
            return (IQueryable<Product>)QueryCategories.Distinct();
        }
        public static IQueryable<Product> WhereProductIdEquals(this IEnumerable<Product> products, int productId)
        {
            return products.Where(i => i.Id == productId).AsQueryable();
        }
    }
}
