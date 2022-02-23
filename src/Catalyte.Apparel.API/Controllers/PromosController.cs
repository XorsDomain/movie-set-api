using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs.Promos;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalyte.Apparel.API.Controllers
{
    [ApiController]
    [Route("/promos")]
    public class PromoController : ControllerBase
    {
        private readonly ILogger<PromoController> _logger;
        private readonly IPromoProvider _promoProvider;
        private readonly IMapper _mapper;

        public PromoController(
            ILogger<PromoController> logger,
            IPromoProvider promoProvider,
            IMapper mapper
        )
        {
            _logger = logger;
            _promoProvider = promoProvider;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<PromoDTO>> CreatePromoAsync([FromBody] Promo promoToCreate)
        {
            _logger.LogInformation("Request received for CreatePromoAsync");

            var newPromo = await _promoProvider.CreatePromoAsync(promoToCreate);
            var promoDTO = _mapper.Map<PromoDTO>(newPromo);
            return Created("/promos", promoDTO);
        }

    }
}
