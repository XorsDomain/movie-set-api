using Catalyte.Apparel.Data.Model;
using System.Linq;

namespace Catalyte.Apparel.Data.Filters
{
    /// <summary>
    /// Filter collection for product context queries.
    /// </summary>
    public static class ProductFilters
    {
        public static IQueryable<Product> WhereProductIdEquals(this IQueryable<Product> products, int productId)
        {
            return products.Where(p => p.Id == productId).AsQueryable();
        }

        public static IQueryable<Product> FilterProductsAsync(
            this IQueryable<Product> query,
            string[] demographic,
            string[] category,
            string[] brand,
            string[] material,
            string[] primarycolorcode,
            string[] secondarycolorcode,
            decimal minprice,
            decimal maxprice)
        {
           
            //if demographic field has a value
            if (demographic != null && demographic.Length != 0)
            {
                query = query.Where(e => demographic.Contains(e.Demographic)); //find products that match any of the demographic values contained in the parameter array
            }

            if (category != null && category.Length != 0)
            {
                query = query.Where(e => category.Contains(e.Category));
            }

            if (brand != null && brand.Length != 0)
            {
                query = query.Where(e => brand.Contains(e.Brand));
            }

            if (material != null && material.Length != 0)
            {
                query = query.Where(e => material.Contains(e.Material));
            }



            if (primarycolorcode != null && primarycolorcode.Length != 0)
            {
                query = query.Where(e => primarycolorcode.Contains(e.PrimaryColorCode));
            }

            if (primarycolorcode != null && secondarycolorcode.Length != 0)
            {
                query = query.Where(e => secondarycolorcode.Contains(e.SecondaryColorCode));
            }



            //if a price range is entered
            if (minprice != 0 && maxprice != 0)
            {
                query = query.Where(e => e.Price >= minprice && e.Price <= maxprice); //find all products within the min-max price range


            }
            //if only minprice is entered
            if (minprice != 0 && maxprice == 0)
            {
                query = query.Where(e => e.Price > minprice); //find all products above the min price value
            }

            if (minprice == 0 && maxprice != 0)
            {
                query = query.Where(e => e.Price < maxprice);
            }
            return query;
        }
    }
}


