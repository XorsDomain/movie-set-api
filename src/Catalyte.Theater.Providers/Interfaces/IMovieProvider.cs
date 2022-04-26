using Catalyte.Theater.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Theater.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for movie related service methods.
    /// </summary>
    public interface IMovieProvider
    {
        Task<Movie> GetMovieByIdAsync(int movieId);

        Task<IEnumerable<Movie>> GetAllMoviesAsync();

        Task<Movie> CreateMovieAsync(Movie movie);

        Task<Movie> UpdateMovieAsync(int id, Movie updatedMovie);

        Task DeleteMovieByIdAsync(int movieId);

    }
}
