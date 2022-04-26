using Catalyte.Theater.Data.Context;
using Catalyte.Theater.Data.Interfaces;
using Catalyte.Theater.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace Catalyte.Theater.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the rental repository.
    /// </summary>
    public class RentalRepository : IRentalRepository
    {
        private readonly ITheaterCtx _ctx;

        public RentalRepository(ITheaterCtx ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// This method gets a rental by its id.
        /// </summary>
        /// <param name="rentalId"></param>
        /// <returns>Rental by given ID</returns>
        public async Task<Rental> GetRentalByIdAsync(int rentalId)
        {
            return await _ctx.Rentals.AsNoTracking()
                .Include(rental => rental.RentedMovies)
                .ThenInclude(rentedMovie => rentedMovie.Movie)
                .FirstOrDefaultAsync(i => i.Id == rentalId);
        }

        /// <summary>
        /// method to get all rentals in the backend and return a list of rentals
        /// </summary>
        /// <returns>a list of rentals</returns>
        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()

        {
            return await _ctx.Rentals.AsNoTracking()
                .Include(rental => rental.RentedMovies)
                .ThenInclude(rentedMovie => rentedMovie.Movie)
                .ToListAsync();
        }


        /// <summary>
        /// Adds a rental to the database.
        /// </summary>
        /// <param name="rental"></param>
        /// <returns>Rental</returns>

        public async Task<Rental> CreateRentalAsync(Rental rental)
        {
            _ctx.Rentals.Add(rental);
            await _ctx.SaveChangesAsync();

            return rental;
        }

        /// <summary>
        /// Updates a rental
        /// </summary>
        /// <param name="rental">Rental to be updated</param>
        /// <returns>Rental</returns>

        public async Task<Rental> UpdateRentalAsync(Rental updatedRental)
        {
            _ctx.Rentals.Update(updatedRental);
            await _ctx.SaveChangesAsync();

            return updatedRental;
        }

        /// <summary>
        /// This method deletes a rental
        /// </summary>
        /// <param name="rental">rental to be deleted</param>
        public async Task DeleteRentalAsync(Rental rental)
        {
            _ctx.Rentals.Remove(rental);
            await _ctx.SaveChangesAsync();
        }
    }
}
