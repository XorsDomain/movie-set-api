using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Data.Repositories;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Providers
{
    public class PromoProvider : IPromoProvider 
    {

        private readonly ILogger<PromoProvider> _logger;
        private readonly IPromoRepository _promoRepository;

        public PromoProvider(IPromoRepository promoRepository, ILogger<PromoProvider> logger)
        {
            _logger = logger;
            _promoRepository = promoRepository;
        }

        public async Task<Promo> CreatePromoAsync(Promo newPromo)
        {
            Promo savedPromo;

            try
            {
                savedPromo = await _promoRepository.CreatePromoAsync(newPromo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return savedPromo;
        }
    }
}
