using Catalyte.Apparel.DTOs.Movies;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Catalyte.Apparel.Test.Integration
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
        public async Task GetMovieGenres_Returns200()
        {
            var response = await _client.GetAsync("/movies/genres");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetMovieDirectors_Returns200()
        {
            var response = await _client.GetAsync("/movies/directors");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
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
        public async Task FlterMoviesAsyncGivenByInvalidPriceReturns400()
        {
            var response = await _client.GetAsync("/movies?minprice=100@sdf");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            
        }

        [Fact]
        public async Task FlterMoviesAsyncGivenByExistingParamsReturns200()
        {
            var response = await _client.GetAsync("/movies?genre=Horror&director=George Marshall");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var contents = await response.Content.ReadAsAsync<IEnumerable<MovieDTO>>();
            foreach (var item in contents)
            {
                Assert.Equal("Horror", item.Genre);
                Assert.Equal("George Marshall", item.Director);
            }
        }

        [Fact]
        public async Task GetMovies_ReturnsCorrectAmount()
        {
            int count = 1000;
            var response = await _client.GetAsync("/movies");
            var content = await response.Content.ReadAsAsync<ICollection<MovieDTO>>();
            Assert.Equal(count, content.Count);
        }
    }
}
