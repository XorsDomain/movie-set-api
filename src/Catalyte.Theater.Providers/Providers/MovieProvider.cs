using Catalyte.Theater.Data.Interfaces;
using Catalyte.Theater.Data.Model;
using Catalyte.Theater.Providers.Interfaces;
using Catalyte.Theater.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalyte.Theater.Providers.Providers
{
    /// <summary>
    /// This class provides the implementation of the IMovieProvider interface, providing service methods for movies.
    /// </summary>
    public class MovieProvider : IMovieProvider
    {
        private readonly ILogger<MovieProvider> _logger;
        private readonly IMovieRepository _movieRepository;

        public MovieProvider(IMovieRepository movieRepository, ILogger<MovieProvider> logger)
        {
            _logger = logger;
            _movieRepository = movieRepository;
        }

        /// <summary>
        /// Asynchronously retrieves the movie with the provided id from the database.
        /// </summary>
        /// <param name="movieId">The id of the movie to retrieve.</param>
        /// <returns>The movie.</returns>
        public async Task<Movie> GetMovieByIdAsync(int movieId)
        {
            Movie movie;

            try
            {
                movie = await _movieRepository.GetMovieByIdAsync(movieId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (movie == null || movie == default)
            {
                _logger.LogInformation($"Movie with id: {movieId} could not be found.");
                throw new NotFoundException($"Movie with id: {movieId} could not be found.");

            }

            return movie;
        }

        /// <summary>
        /// Asynchronously retrieves the movie or movies with the provided field parameters from the database.
        /// </summary>
        /// <returns>the movie or movies</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="NotFoundException"></exception>
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            IEnumerable<Movie> movies;

            try
            {
                movies = await _movieRepository.GetAllMoviesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            
            return movies;
        }

        /// <summary>
        /// Asynchronously adds a movie to the database.
        /// </summary>
        /// <param name="newMovie"></param>
        /// <returns>Movie</returns>
        /// <exception cref="ServiceUnavailableException"></exception>

        public async Task<Movie> CreateMovieAsync(Movie newMovie)
        {
            Movie savedMovie;
            IEnumerable<Movie> movies;
            bool movieSkuAlreadyExists;

            try
            {
                movies = await _movieRepository.GetAllMoviesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            movieSkuAlreadyExists = movies.Any(m => m.Sku.ToLower() == newMovie.Sku.ToLower());

            if (movieSkuAlreadyExists)
            {
                throw new ConflictException("This movie already exists.");
            }
            try
            {
                savedMovie = await _movieRepository.CreateMovieAsync(newMovie);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return savedMovie;
        }

        /// <summary>
        /// Asychronously updates movie by given id
        /// </summary>
        /// <param name="id">Id of movie to update</param>
        /// <param name="updatedMovie">Movie being updated</param>
        /// <returns>Updated movie</returns>
        /// <exception cref="ServiceUnavailableException"></exception>
        /// <exception cref="NotFoundException"></exception>

        public async Task<Movie> UpdateMovieAsync(int movieId, Movie updatedMovie)
        {
            Movie existingMovie;

            try
            {
                existingMovie = await _movieRepository.GetMovieByIdAsync(movieId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }


            if (existingMovie == default)
            {
                _logger.LogInformation($"Movie with id: {movieId} does not exist.");
                throw new NotFoundException($"Movie with id: {movieId} not found.");
            }

            if (updatedMovie.Id != existingMovie.Id)
            {
                _logger.LogInformation("Edited movie id must be the same as original movie id.");
                throw new BadRequestException("Edited movie id must be the same as original movie id.");
            }

            try
            {
                await _movieRepository.UpdateMovieAsync(updatedMovie);
                _logger.LogInformation("Movie updated.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database");
            }
            return existingMovie;
        }

        /// <summary>
        /// asynchronously deletes a movie in the database by a given id
        /// </summary>
        /// <param name="MovieId">id of movie to be deleted</param>
        /// <exception cref="NotFoundException"></exception>

        public async Task DeleteMovieByIdAsync(int movieId)
        {
            var _movie = await _movieRepository.GetMovieByIdAsync(movieId);

            if (_movie != null)
            {
                await _movieRepository.DeleteMovieAsync(_movie);
            }
            else
            {
                throw new NotFoundException($"Movie with ID {movieId} could not be found.");
            }
        }
    }
}
