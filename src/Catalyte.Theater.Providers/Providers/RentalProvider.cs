using Catalyte.Theater.Data.Interfaces;
using Catalyte.Theater.Data.Model;
using Catalyte.Theater.Providers.Interfaces;
using Catalyte.Theater.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Theater.Providers.Providers
{
    /// <summary>
    /// This class provides the implementation of the IRentalProvider interface, providing service methods for rentals.
    /// </summary>
    public class RentalProvider : IRentalProvider
    {
        private readonly ILogger<RentalProvider> _logger;
        private readonly IRentalRepository _rentalRepository;

        public RentalProvider(IRentalRepository rentalRepository, ILogger<RentalProvider> logger)
        {
            _logger = logger;
            _rentalRepository = rentalRepository;
        }

        /// <summary>
        /// Asynchronously retrieves the rental or rentals with the provided field parameters from the database.
        /// </summary>
        /// <returns>the rental or rentals</returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="NotFoundException"></exception>
        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
        {
            IEnumerable<Rental> rentals;

            try
            {
                rentals = await _rentalRepository.GetAllRentalsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return rentals;
        }

        /// <summary>
        /// Asynchronously retrieves the rental with the provided id from the database.
        /// </summary>
        /// <param name="rentalId">The id of the rental to retrieve.</param>
        /// <returns>The rental.</returns>
        public async Task<Rental> GetRentalByIdAsync(int rentalId)
        {
            Rental rental;

            try
            {
                rental = await _rentalRepository.GetRentalByIdAsync(rentalId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (rental == null || rental == default)
            {
                _logger.LogInformation($"Rental with id: {rentalId} could not be found.");
                throw new NotFoundException($"Rental with id: {rentalId} could not be found.");

            }

            return rental;
        }

        /// <summary>
        /// Asynchronously adds a rental to the database.
        /// </summary>
        /// <param name="newRental"></param>
        /// <returns>Rental</returns>
        /// <exception cref="ServiceUnavailableException"></exception>

        public async Task<Rental> CreateRentalAsync(Rental newRental)
        {
            Rental savedRental;

            try
            {
                savedRental = await _rentalRepository.CreateRentalAsync(newRental);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }
            return savedRental;
        }

        /// <summary>
        /// Asychronously updates rental by given id
        /// </summary>
        /// <param name="id">Id of rental to update</param>
        /// <param name="updatedRental">Rental being updated</param>
        /// <returns>Updated rental</returns>
        /// <exception cref="ServiceUnavailableException"></exception>
        /// <exception cref="NotFoundException"></exception>

        public async Task<Rental> UpdateRentalAsync(int rentalId, Rental updatedRental)
        {
            Rental existingRental;

            try
            {
                existingRental = await _rentalRepository.GetRentalByIdAsync(rentalId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }


            if (existingRental == default)
            {
                _logger.LogInformation($"Rental with id: {rentalId} does not exist.");
                throw new NotFoundException($"Rental with id: {rentalId} not found.");
            }

            if (updatedRental.Id != existingRental.Id)
            {
                _logger.LogInformation("Edited rental id must be the same as original rental id.");
                throw new BadRequestException("Edited rental id must be the same as original rental id.");
            }

            try
            {
                await _rentalRepository.UpdateRentalAsync(updatedRental);
                _logger.LogInformation("Rental updated.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database");
            }
            return existingRental;
        }

        /// <summary>
        /// asynchronously deletes a rental in the database by a given id
        /// </summary>
        /// <param name="rentalId">id of rental to be deleted</param>
        /// <exception cref="NotFoundException"></exception>

        public async Task DeleteRentalByIdAsync(int rentalId)
        {
            var _rental = await _rentalRepository.GetRentalByIdAsync(rentalId);

            if (_rental != null)
            {
                await _rentalRepository.DeleteRentalAsync(_rental);
            }
            else
            {
                throw new NotFoundException($"Rental with ID {rentalId} could not be found.");
            }
        }
    }
}
