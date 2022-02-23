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
    /// This class provides the implementation of the IPurchaseProvider interface, providing service methods for purchases.
    /// </summary>
    public class PurchaseProvider : IPurchaseProvider
    {
        private readonly ILogger<PurchaseProvider> _logger;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IProductRepository _productRepository;

        public PurchaseProvider(IPurchaseRepository purchaseRepository, ILogger<PurchaseProvider> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
        }


        /// <summary>
        /// Retrieves all purchases from the database.
        /// </summary>
        /// <param name="email">Email of the endpoint.</param>
        /// <returns>All purchases with said email</returns>
        public async Task<IEnumerable<Purchase>> GetPurchasesByEmailAsync(string email)
        {
            List<Purchase> purchases;

            try
            {
                purchases = (List<Purchase>) await _purchaseRepository.GetPurchasesByEmailAsync(email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new NotFoundException($"Could not find purchases with email: {email}");
            }

            return purchases;
        }

        /// <summary>
        /// Retrieves all purchases from the database.
        /// </summary>
        /// <returns>All purchases.</returns>
        public Task<IEnumerable<Purchase>> GetAllPurchasesAsync()
        {
            throw new NotFoundException("Page Unavailable purchases endpoint");
        }

        /// <summary>
        /// Persists a purchase to the database.
        /// </summary>
        /// <param name="model">PurchaseDTO used to build the purchase.</param>
        /// <returns>The persisted purchase with IDs.</returns>
        public async Task<Purchase> CreatePurchasesAsync(Purchase newPurchase)
        {
            Product activeProduct;

            foreach (LineItem lineItem in newPurchase.LineItems)
            {
                try
                {
                    activeProduct = await _productRepository.GetProductByIdAsync(lineItem.ProductId);
                }

                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new ServiceUnavailableException("There was a problem connecting to the database.");
                }
                if (activeProduct.Active == false)
                {
                    throw new UnprocessableEntityException("Unprocessable Entity");
                }
            }

            
            Purchase savedPurchase;
            try
            {
                savedPurchase = await _purchaseRepository.CreatePurchaseAsync(newPurchase);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            
            return savedPurchase;
            
        }
        
    } 
}
