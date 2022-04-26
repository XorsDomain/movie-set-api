using Catalyte.Theater.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Catalyte.Theater.Data.Context
{
    /// <summary>
    /// This interface provides an abstraction layer for the Theater database context.
    /// </summary>
    public interface ITheaterCtx
    {

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }

}
