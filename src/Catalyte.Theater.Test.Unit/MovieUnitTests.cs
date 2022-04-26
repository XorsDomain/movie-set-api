using System;
using Xunit;
using Moq;
using Catalyte.Theater.Providers.Providers;
using Catalyte.Theater.Data.Interfaces;
using Microsoft.Extensions.Logging;
using Catalyte.Theater.Data.Model;
using System.Linq;
using System.Collections.Generic;
using Catalyte.Theater.Providers.Interfaces;
using Catalyte.Theater.Utilities.HttpResponseExceptions;

namespace Catalyte.Theater.Test.Unit
{
    public class MovieUnitTests
    {
        private readonly List<Movie> movies;
        private readonly IMovieProvider movieProvider;
        private readonly Mock<IMovieRepository> movieRepo;
        private readonly Mock<ILogger<MovieProvider>> logger;

        public MovieUnitTests()
        {
            movieRepo = new Mock<IMovieRepository>();
            logger = new Mock<ILogger<MovieProvider>>();
            movieProvider = new MovieProvider(movieRepo.Object, logger.Object);

            movies = new List<Movie>()
            {
                new Movie() {Id = 1, Genre = "Horror"}
            };

        }

        [Fact]
        public async void GetMoviesByIdAsync_IdExistsReturnsProduct()
        {
            var movie = movies.Single(x => x.Id == 1);
            movieRepo.Setup(m => m.GetMovieByIdAsync(1)).ReturnsAsync(movie);

            var actual = await movieRepo.Object.GetMovieByIdAsync(1);
            Assert.Same(movie, actual);
            Assert.Equal(1, actual.Id);
        }

        [Fact]
        public async void GetMovieByIdAsync_DatabaseErrorReturnsException()
        {
            var exception = new ServiceUnavailableException("There was a problem connecting to the database.");

            movieRepo.Setup(m => m.GetMovieByIdAsync(1)).ThrowsAsync(exception);
            try
            {
                await movieProvider.GetMovieByIdAsync(1);
            }
            catch (Exception ex)
            {
                Assert.Same(ex.GetType(), exception.GetType());
                Assert.Equal(ex.Message, exception.Message);
            }
        }

        [Fact]
        public async void GetMovieByIdAsync_IdIsNullReturnsNotFoundError()
        {
            Movie movie = null;
            var movieId = 2;
            var exception = new NotFoundException($"Movie with id: {movieId} could not be found.");

            movieRepo.Setup(m => m.GetMovieByIdAsync(movieId)).ReturnsAsync(movie);
            try
            {
                await movieProvider.GetMovieByIdAsync(movieId);
            }
            catch (Exception ex)
            {
                Assert.Same(ex.GetType(), exception.GetType());
                Assert.Equal(ex.Message, exception.Message);
            }
        }

        [Fact]
        public async void GetMovieByIdAsync_IdIsDefaultReturnsNotFoundError()
        {
            Movie movie = default;
            var movieId = 2;
            var exception = new NotFoundException($"Product with id: {movieId} could not be found.");

            movieRepo.Setup(m => m.GetMovieByIdAsync(movieId)).ReturnsAsync(movie);
            try
            {
                await movieProvider.GetMovieByIdAsync(movieId);
            }
            catch (Exception ex)
            {
                Assert.Same(ex.GetType(), exception.GetType());
                Assert.Equal(ex.Message, exception.Message);
            }
        }

    }
}

