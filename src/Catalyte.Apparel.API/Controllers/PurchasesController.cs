﻿using AutoMapper;
using Catalyte.Apparel.API.DTOMappings;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalyte.Apparel.DTOs.Purchases;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalyte.Apparel.API.Controllers
{

    [ApiController]
    [Route("/purchases")]
    public class PurchasesController : ControllerBase
    {
        private readonly ILogger<PurchasesController> _logger;
        private readonly IPurchaseProvider _purchaseProvider;
        private readonly IMapper _mapper;

        public PurchasesController(
            ILogger<PurchasesController> logger,
            IPurchaseProvider purchaseProvider,
            IMapper mapper
        )
        {
            _logger = logger;
            _purchaseProvider = purchaseProvider;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PurchaseDTO>>> GetAllPurchasesAsync()
        {
            _logger.LogInformation("Request received for GetAllPurchasesAsync");

            var purchases = await _purchaseProvider.GetAllPurchasesAsync();
            var purchaseDTOs = _mapper.MapPurchasesToPurchaseDtos(purchases);

            return Ok(purchaseDTOs);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> GetPurchasesByEmailAsync(string email)
        {

            var purchases = await _purchaseProvider.GetPurchasesByEmailAsync(email);
            var purchaseDTOs = _mapper.MapPurchasesToPurchaseDtos(purchases);

            if (purchases != null)
            {
                return Ok(purchaseDTOs);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<List<PurchaseDTO>>> CreatePurchaseAsync([FromBody] CreatePurchaseDTO model)
        {
            _logger.LogInformation("Request received for CreatePurchase");

            var newPurchase = _mapper.MapCreatePurchaseDtoToPurchase(model);
            var savedPurchase = await _purchaseProvider.CreatePurchasesAsync(newPurchase);
            var purchaseDTO = _mapper.MapPurchaseToPurchaseDto(savedPurchase);

            if (purchaseDTO == null)
            {
                return NoContent();
            }

            return Created($"/purchases/", purchaseDTO);
        }
    }
}
