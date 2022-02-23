using Catalyte.Apparel.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for product repository methods.
    /// </summary>
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int productId);

        Task<IEnumerable<string>> GetProductsCategoriesAsync();

        Task<IEnumerable<string>> GetProductsTypesAsync();
        Task<IEnumerable<Product>> FilterProductsAsync(string[] demographic, string[] category, string[] brand, string[] material, string[] primarycolorcode, string[] secondarycolorcode, decimal minprice, decimal maxprice);
    }
}
