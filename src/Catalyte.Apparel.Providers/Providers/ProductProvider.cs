using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Providers
{
    /// <summary>
    /// This class provides the implementation of the IProductProvider interface, providing service methods for products.
    /// </summary>
    public class ProductProvider : IProductProvider
    {
        private readonly ILogger<ProductProvider> _logger;
        private readonly IProductRepository _productRepository;

        public ProductProvider(IProductRepository productRepository, ILogger<ProductProvider> logger)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        /// <summary>
        /// Asynchronously retrieves the product with the provided id from the database.
        /// </summary>
        /// <param name="productId">The id of the product to retrieve.</param>
        /// <returns>The product.</returns>
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            Product product;

            try
            {
                product = await _productRepository.GetProductByIdAsync(productId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (product == null || product == default)
            {
                _logger.LogInformation($"Product with id: {productId} could not be found.");
                throw new NotFoundException($"Product with id: {productId} could not be found.");

            }

            return product;
        }

        /// <summary>
        /// Asynchronously retrieves the product or products with the provided field parameters from the database.
        /// </summary>
        /// <param name="demographic">demographic of the product to retrieve</param>
        /// <param name="category">category of the product to retrieve</param>
        /// <param name="brand">brand of the product to retrieve</param>
        /// <param name="material">material of the product to retrieve</param>
        /// <param name="primarycolorcode">primary of the product to retrieve</param>
        /// <param name="secondarycolorcode">secondary color of the product to retrieve</param>
        /// <param name="minprice">minimum price of the product to retrieve</param>
        /// <param name="maxprice">maximum price of the product to retrieve</param>
        /// <returns>the product or products</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="NotFoundException"></exception>
        public async Task <IEnumerable<Product>> FilterProductsAsync(
            string[] demographic,
            string[] category,
            string[] brand,
            string[] material,
            string[] primarycolorcode,
            string[] secondarycolorcode,
            decimal minprice, decimal maxprice)
        {
            IEnumerable<Product> products;

            try
            {
                products = await _productRepository.FilterProductsAsync(
                    demographic,
                    category,
                    brand,
                    material,
                    primarycolorcode,
                    secondarycolorcode,
                    minprice,
                    maxprice);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
               // throw new Exception(ex.Message);
            }
            
            return products;
        }

        /// <summary>
        /// Asynchronously retrieves all product categories from the database.
        /// </summary>
        /// <returns>All categories in the database.</returns>
        public async Task<IEnumerable<string>> GetProductsCategoriesAsync()
        {
            IEnumerable<string> categories;

            try
            {
                categories = await _productRepository.GetProductsCategoriesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return categories;
        }
        /// <summary>
        /// Asynchronously retrieves all product types from the database.
        /// </summary>
        /// <returns>All types in the database.</returns>
        public async Task<IEnumerable<string>> GetProductsTypesAsync()
        {
            IEnumerable<string> types;

            try
            {
                types = await _productRepository.GetProductsTypesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return types;
        }
    }
}
