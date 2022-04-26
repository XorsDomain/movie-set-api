using Catalyte.Theater.DTOs.Rentals;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Catalyte.Theater.Test.Integration
{
    public class RentalIntegrationTests : IntegrationTests
    {
        [Fact]
        public async Task GetRentals_Returns200()
        {
            var response = await _client.GetAsync("/rentals");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetRentalById_GivenByExistingId_Returns200()
        {
            var response = await _client.GetAsync("/rentals/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<RentalDTO>();
            Assert.Equal(1, content.Id);
        }


        [Fact]
        public async Task GetRentalById_GivenInvalidId_Returns400()
        {
            var response = await _client.GetAsync("/rentals/asdf");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetRentalById_GivenNonexistingId_Returns404()
        {
            var response = await _client.GetAsync("/rentals/34567");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
