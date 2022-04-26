using Catalyte.Theater.DTOs.Movies;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Catalyte.Theater.Test.Integration
{
    public class MovieIntegrationTests : IntegrationTests
    {
        [Fact]
        public async Task GetMovies_Returns200()
        {
            var response = await _client.GetAsync("/movies");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetMovieById_GivenByExistingId_Returns200()
        {
            var response = await _client.GetAsync("/movies/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<MovieDTO>();
            Assert.Equal(1, content.Id);
        }


        [Fact]
        public async Task GetMovieById_GivenInvalidId_Returns400()
        {
            var response = await _client.GetAsync("/movies/asdf");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetMovieById_GivenNonexistingId_Returns404()
        {
            var response = await _client.GetAsync("/movies/34567");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetMovies_ReturnsCorrectAmount()
        {
            int count = 502;
            var response = await _client.GetAsync("/movies");
            var content = await response.Content.ReadAsAsync<ICollection<MovieDTO>>();
            Assert.Equal(count, content.Count);
        }
    }
}