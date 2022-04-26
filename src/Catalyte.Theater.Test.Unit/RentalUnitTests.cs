using System;
using Xunit;
using Moq;
using Catalyte.Theater.Providers.Providers;
using Catalyte.Theater.Data.Interfaces;
using Microsoft.Extensions.Logging;
using Catalyte.Theater.Data.Model;
using System.Linq;
using System.Collections.Generic;
using Catalyte.Theater.Providers.Interfaces;
using Catalyte.Theater.Utilities.HttpResponseExceptions;

namespace Catalyte.Theater.Test.Unit
{
    public class RentalUnitTests
    {
        private readonly List<Rental> rentals;
        private readonly IRentalProvider rentalProvider;
        private readonly Mock<IRentalRepository> rentalRepo;
        private readonly Mock<ILogger<RentalProvider>> logger;

        public RentalUnitTests()
        {
            rentalRepo = new Mock<IRentalRepository>();
            logger = new Mock<ILogger<RentalProvider>>();
            rentalProvider = new RentalProvider(rentalRepo.Object, logger.Object);

        }


        [Fact]
        public async void GetRentalByIdAsync_DatabaseErrorReturnsException()
        {
            var exception = new ServiceUnavailableException("There was a problem connecting to the database.");

            rentalRepo.Setup(m => m.GetRentalByIdAsync(1)).ThrowsAsync(exception);
            try
            {
                await rentalProvider.GetRentalByIdAsync(1);
            }
            catch (Exception ex)
            {
                Assert.Same(ex.GetType(), exception.GetType());
                Assert.Equal(ex.Message, exception.Message);
            }
        }

        [Fact]
        public async void GetRentalByIdAsync_IdIsNullReturnsNotFoundError()
        {
            Rental rental = null;
            var rentalId = 2;
            var exception = new NotFoundException($"Rental with id: {rentalId} could not be found.");

            rentalRepo.Setup(m => m.GetRentalByIdAsync(rentalId)).ReturnsAsync(rental);
            try
            {
                await rentalProvider.GetRentalByIdAsync(rentalId);
            }
            catch (Exception ex)
            {
                Assert.Same(ex.GetType(), exception.GetType());
                Assert.Equal(ex.Message, exception.Message);
            }
        }

        [Fact]
        public async void GetRentalByIdAsync_IdIsDefaultReturnsNotFoundError()
        {
            Rental rental = default;
            var rentalId = 2;
            var exception = new NotFoundException($"Product with id: {rentalId} could not be found.");

            rentalRepo.Setup(m => m.GetRentalByIdAsync(rentalId)).ReturnsAsync(rental);
            try
            {
                await rentalProvider.GetRentalByIdAsync(rentalId);
            }
            catch (Exception ex)
            {
                Assert.Same(ex.GetType(), exception.GetType());
                Assert.Equal(ex.Message, exception.Message);
            }
        }
    }
}
