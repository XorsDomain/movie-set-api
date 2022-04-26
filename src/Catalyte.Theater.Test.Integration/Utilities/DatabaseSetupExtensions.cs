using Catalyte.Theater.Data.Context;
using Catalyte.Theater.Data.SeedData;

namespace Catalyte.Theater.Test.Integration.Utilities
{
    public static class DatabaseSetupExtensions
    {
        public static void InitializeDatabaseForTests(this TheaterCtx context)
        {
            var movieFactory = new MovieFactory();
            var movies = movieFactory.GenerateRandomMovies(250);

            context.Movies.AddRange(movies);
            context.SaveChanges();
        }

        public static void ReinitializeDatabaseForTests(this TheaterCtx context)
        {
            context.Movies.RemoveRange(context.Movies);
            context.Rentals.RemoveRange(context.Rentals);
            context.InitializeDatabaseForTests();
        }
    }
}
