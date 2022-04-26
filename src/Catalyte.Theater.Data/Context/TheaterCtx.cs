using Catalyte.Theater.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Catalyte.Theater.Data.Context
{
    /// <summary>
    /// Theater database context provider.
    /// </summary>
    public class TheaterCtx : DbContext, ITheaterCtx
    {

        public TheaterCtx(DbContextOptions<TheaterCtx> options) : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
