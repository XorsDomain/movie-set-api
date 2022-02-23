﻿using AutoMapper;
﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalyte.Apparel.API.Controllers
{
    /// <summary>
    /// The ProductsController exposes endpoints for product related actions.
    /// </summary>
    [ApiController]
    [Route("/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductProvider _productProvider;
        private readonly IMapper _mapper;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductProvider productProvider,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _productProvider = productProvider;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id)
        {
            _logger.LogInformation($"Request received for GetProductByIdAsync for id: {id}");

            var product = await _productProvider.GetProductByIdAsync(id);
            var productDTO = _mapper.Map<ProductDTO>(product);

            return Ok(productDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> FilterProductsAsync(
            [FromQuery(Name = "demographic")] string[] demographic,
            [FromQuery(Name = "category")] string[] category,
            [FromQuery(Name = "brand")] string[] brand,
            [FromQuery(Name = "material")] string[] material,
            [FromQuery(Name = "primarycolorcode")] string[] primarycolorcode,
            [FromQuery(Name = "secondarycolorcode")] string[] secondarycolorcode,
            [FromQuery(Name = "minprice")] decimal minprice,
            [FromQuery(Name = "maxprice")] decimal maxprice)
        {
            var result = await _productProvider.FilterProductsAsync(
                demographic,
                category,
                brand,
                material,
                primarycolorcode,
                secondarycolorcode,
                minprice,
                maxprice);

            IEnumerable<ProductDTO> productDTO = _mapper.Map<IEnumerable<ProductDTO>>(result);
            return Ok(productDTO);
        }
        [HttpGet]
        [Route("/products/categories")]
        public async Task<ActionResult<IEnumerable<string>>> GetProductsCategoriesAsync()
        {
            _logger.LogInformation("Request received for GetProductsCategories");

            var categories = await _productProvider.GetProductsCategoriesAsync();
            var productDTOs = _mapper.Map<IEnumerable<string>>(categories);

            return Ok(productDTOs);
        }
        [HttpGet]
        [Route("/products/types")]
        public async Task<ActionResult<IEnumerable<string>>> GetProductsTypesAsync()
        {
            _logger.LogInformation("Request received for GetProductsCategories");

            var categories = await _productProvider.GetProductsTypesAsync();
            var productDTOs = _mapper.Map<IEnumerable<string>>(categories);

            return Ok(productDTOs);
        }
    }
}
