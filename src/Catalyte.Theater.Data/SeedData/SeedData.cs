using Catalyte.Theater.Data.Model;
using Catalyte.Theater.Data.SeedData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalyte.Theater.Data.Context
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
            var movieList = movieFactory.GenerateRandomMovies(500);
            modelBuilder.Entity<Movie>().HasData(movieList);


            var movieOne = new Movie()
            {
                Id = 501,
                Sku = "ABCDE-1234",
                Title = "Insightful Horror Movie",
                Genre = "Horror",
                Director = "George Marshall",
                DailyRentalCost = 7.99m
            };

            var movieTwo = new Movie()
            {
                Id = 502,
                Sku = "ZXCVB-8521",
                Title = "Hilarious Found Footage Movie",
                Genre = "Found Footage",
                Director = "George Marshall",
                DailyRentalCost = 5.99m
            };

            modelBuilder.Entity<Movie>().HasData(movieOne);
            modelBuilder.Entity<Movie>().HasData(movieTwo);


            var rentedMovieOne = new RentedMovie()
            {
                Id = 1,
                MovieId = movieList.ElementAt(450).Id,
                Movie = movieList.ElementAt(450),
                DaysRented = 5,
                RentalId = 1
            };


            var rentedMovieTwo = new RentedMovie()
            {
                Id = 2,
                MovieId = movieList.ElementAt(451).Id,
                Movie = movieList.ElementAt(451),
                DaysRented = 5,
                RentalId = 1
            };

            modelBuilder.Entity<RentedMovie>().HasData(rentedMovieTwo);
            modelBuilder.Entity<RentedMovie>().HasData(rentedMovieOne);


            var rentalOne = new Rental()
            {
                Id = 1,
                RentalDate = DateTime.Now,
                RentalTotalCost = calculateRentalTotalCost(new List<RentedMovie> { rentedMovieOne, rentedMovieTwo })
            };

            rentedMovieOne.Movie = default;
            rentedMovieTwo.Movie = default;

            modelBuilder.Entity<Rental>().HasData(rentalOne);

             static decimal calculateRentalTotalCost (List<RentedMovie> rentedMovies)
            {
                decimal totalCost = 0;
                foreach (RentedMovie rentedMovie in rentedMovies)
                {
                    totalCost += rentedMovie.DaysRented * rentedMovie.Movie.DailyRentalCost;
                }
                return totalCost;
            }

        }
    }
}
