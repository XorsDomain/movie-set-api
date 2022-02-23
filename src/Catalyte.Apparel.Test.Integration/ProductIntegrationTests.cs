using Catalyte.Apparel.DTOs.Products;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Catalyte.Apparel.Test.Integration
{
    public class ProductIntegrationTests : IntegrationTests
    {
        [Fact]
        public async Task GetProducts_Returns200()
        {
            var response = await _client.GetAsync("/products");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetProductById_GivenByExistingId_Returns200()
        {
            var response = await _client.GetAsync("/products/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<ProductDTO>();
            Assert.Equal(1, content.Id);
        }

        [Fact]
        public async Task GetProductCategories_Returns200()
        {
            var response = await _client.GetAsync("/products/categories");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetProductTypes_Returns200()
        {
            var response = await _client.GetAsync("/products/types");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task GetProductById_GivenInvalidId_Returns400()
        {
            var response = await _client.GetAsync("/products/asdf");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetProductById_GivenNonexistingId_Returns404()
        {
            var response = await _client.GetAsync("/products/34567");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task FlterProductsAsyncGivenByInvalidPriceReturns400()
        {
            var response = await _client.GetAsync("/products?minprice=100@sdf");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            
        }

        [Fact]
        public async Task FlterProductsAsyncGivenByExistingDemographicReturns200()
        {
            var response = await _client.GetAsync("/products?demographic=Men");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var contents = await response.Content.ReadAsAsync<IEnumerable<ProductDTO>>();
            foreach (var item in contents)
            {
                Assert.Equal("Men", item.Demographic);                
            }
        }

        [Fact]
        public async Task FlterProductsAsyncGivenByExistingParamsReturns200()
        {
            var response = await _client.GetAsync("/products?brand=Nike&material=Synthetic");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var contents = await response.Content.ReadAsAsync<IEnumerable<ProductDTO>>();
            foreach (var item in contents)
            {
                Assert.Equal("Nike", item.Brand);
                Assert.Equal("Synthetic", item.Material);
            }
        }

        [Fact]
        public async Task GetProducts_ReturnsCorrectAmount()
        {
            // Count is set in Startup.cs
            int count = 1000;
            var response = await _client.GetAsync("/products");
            var content = await response.Content.ReadAsAsync<ICollection<ProductDTO>>();
            Assert.Equal(count, content.Count);
        }
    }
}
