using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Data.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Catalyte.Apparel.Data.Context
{
    public static class Extensions
    {
        /// <summary>
        /// Produces a set of seed data to insert into the database on startup.
        /// </summary>
        /// <param name="modelBuilder">Used to build model base DbContext.</param>
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var movieFactory = new MovieFactory();

            modelBuilder.Entity<Movie>().HasData(movieFactory.GenerateRandomMovies(500));

            var movieOne = new Movie()
            {
                Id = 501,
                Sku = "ABCDEF-1234",
                Title = "Insightful Horror Movie",
                Genre = "Horror",
                Director = "George Marshall",
                DailyRentalCost = 7.99m
            };

            modelBuilder.Entity<Movie>().HasData(movieOne);


        }
    }
}
