using Catalyte.Theater.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Theater.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for movie repository methods.
    /// </summary>
    public interface IMovieRepository
    {
        Task<Movie> GetMovieByIdAsync(int movieId);

        Task<IEnumerable<Movie>> GetAllMoviesAsync();

        Task<Movie> CreateMovieAsync(Movie movie);

        Task<Movie> UpdateMovieAsync(Movie updatedMovie);

        Task DeleteMovieAsync(Movie movie);
    }
}
