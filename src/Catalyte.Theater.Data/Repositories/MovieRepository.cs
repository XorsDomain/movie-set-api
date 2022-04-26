using Catalyte.Theater.Data.Context;
using Catalyte.Theater.Data.Interfaces;
using Catalyte.Theater.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Theater.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the movie repository.
    /// </summary>
    public class MovieRepository : IMovieRepository
    {
        private readonly ITheaterCtx _ctx;

        public MovieRepository(ITheaterCtx ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// This method gets a movie by its id.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>Movie by given ID</returns>
        public async Task<Movie> GetMovieByIdAsync(int movieId)
        {
            return await _ctx.Movies.AsNoTracking().FirstOrDefaultAsync(i => i.Id == movieId);
        }

        /// <summary>
        /// method to get all movies in the backend and return a list of movies
        /// </summary>
        /// <returns>a list of movies</returns>
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()

        {
            return await _ctx.Movies.ToListAsync();
        }


        /// <summary>
        /// Adds a movie to the database.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>Movie</returns>

        public async Task<Movie> CreateMovieAsync(Movie movie)
        {
            _ctx.Movies.Add(movie);
            await _ctx.SaveChangesAsync();

            return movie;
        }

        /// <summary>
        /// Updates a movie
        /// </summary>
        /// <param name="movie">Movie to be updated</param>
        /// <returns>Movie</returns>

        public async Task<Movie> UpdateMovieAsync(Movie updatedMovie)
        {
            _ctx.Movies.Update(updatedMovie);
            await _ctx.SaveChangesAsync();

            return updatedMovie;
        }

        /// <summary>
        /// This method deletes a movie
        /// </summary>
        /// <param name="movie">movie to be deleted</param>
        public async Task DeleteMovieAsync(Movie movie)
        {
            _ctx.Movies.Remove(movie);
            await _ctx.SaveChangesAsync();
        }

    }

}
