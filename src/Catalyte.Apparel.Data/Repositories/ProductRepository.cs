using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Filters;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the product repository.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly IApparelCtx _ctx;

        public ProductRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _ctx.Products.AsNoTracking().Include(p => p.Reviews).FirstOrDefaultAsync(i => i.Id == productId);
        }

        /// <summary>
        /// method to filter products in the backend and return a list of products
        /// </summary>
        /// <param name="demographic">demographic of the product to retrieve</param>
        /// <param name="category">category of the product to retrieve</param>
        /// <param name="brand">brand of the product to retrieve</param>
        /// <param name="material">material of the product to retrieve</param>
        /// <param name="primarycolorcode">primary of the product to retrieve</param>
        /// <param name="secondarycolorcode">secondary color of the product to retrieve</param>
        /// <param name="minprice">minimum price of the product to retrieve</param>
        /// <param name="maxprice">maximum price of the product to retrieve</param>
        /// <returns>a list of products</returns>
        public async Task<IEnumerable<Product>> FilterProductsAsync(
            string[] demographic,
            string[] category,
            string[] brand, 
            string[] material, 
            string[] primarycolorcode, 
            string[] secondarycolorcode, 
            decimal minprice, 
            decimal maxprice)

        {

            return await _ctx.Products.AsNoTracking().AsQueryable().FilterProductsAsync(
             demographic,
             category,
             brand,
             material,
             primarycolorcode,
             secondarycolorcode,
             minprice,
             maxprice).Include(p => p.Reviews).ToListAsync(); 
        }
        public async Task<IEnumerable<string>> GetProductsCategoriesAsync()
        {
            var categories = await _ctx.Products.AsNoTracking().Select(p => p.Category).ToListAsync();
            return categories.Distinct();
        }
        public async Task<IEnumerable<string>> GetProductsTypesAsync()
        {
            var types = await _ctx.Products.AsNoTracking().Select(p => p.Type).ToListAsync();
            return types.Distinct();
        }
    }

}
