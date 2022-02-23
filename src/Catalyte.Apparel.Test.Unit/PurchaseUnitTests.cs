
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Providers.Providers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;

namespace Catalyte.Apparel.Test.Unit
{
    public class PurchaseUnitTests
    {
        private readonly Mock<ILogger<PurchaseProvider>> _logger;
        private readonly Mock<IPurchaseRepository> _mockPurchaseRepo;
        private readonly Mock<IProductRepository> _mockProductRepo;
        private readonly IPurchaseProvider _purchaseProvider;
        public PurchaseUnitTests()
        {
            _logger = new Mock<ILogger<PurchaseProvider>>();
            _mockPurchaseRepo = new Mock<IPurchaseRepository>();
            _mockProductRepo = new Mock<IProductRepository>();
            _purchaseProvider = new PurchaseProvider(_mockPurchaseRepo.Object, _logger.Object, _mockProductRepo.Object);
        }

        [Fact]
        public async Task CreatePurchase_ReturnsPurchase()
        {
            var expected = new Purchase()
            {
                Id = 3,
                OrderDate = DateTime.Now,
                BillingStreet = "123 Sesame Street",
                BillingStreet2 = "Apartment #789",
                BillingCity = "New York City",
                BillingState = "New York",
                BillingZip = "12345",
                BillingEmail = "ILikeToLearn@email.com",
                BillingPhone = "(123)456-7890",
                DeliveryFirstName = "John",
                DeliveryLastName = "Doe",
                DeliveryStreet = "123 Sesame Street",
                DeliveryStreet2 = "Apartment #789",
                DeliveryCity = "New York City",
                DeliveryState = "New York",
                DeliveryZip = 12345,
                CardNumber = "1234567890123456",
                CVV = "123",
                Expiration = "12/99",
                CardHolder = "John Doe",
                LineItems = new List<LineItem>()
                {
                    new LineItem()
                    {
                        ProductId = 3,
                        Quantity = 1
                    }

                }

            };

            var product = new Product()
            {
                Name = "Steel-Toed Sneaker Boots",
                Sku = "ABC-NYUK",
                Description = "Sneaker styled boots designed for comfort, with metal steel at the toe for foot protection.",
                Demographic = "Men",
                Category = "Work",
                Type = "Shoe",
                ReleaseDate = DateTime.Now,
                PrimaryColorCode = "Black",
                SecondaryColorCode = "Black",
                StyleNumber = "15789",
                GlobalProductCode = "A789YT",
                Active = true,

            };
            
            _mockProductRepo.Setup(p => p.GetProductByIdAsync(It.IsAny<int>())).ReturnsAsync(product);
            _mockPurchaseRepo.Setup(p => p.CreatePurchaseAsync(It.IsAny<Purchase>())).ReturnsAsync(expected);
            var actual = await _purchaseProvider.CreatePurchasesAsync(expected);

            Assert.NotNull(actual);
            Assert.IsType<Purchase>(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task CreatePurchasesAsync_ReturnsError()
        {
            var purchase = new Purchase()
            {
                Id = 3,
                OrderDate = DateTime.Now,
                BillingStreet = "123 Sesame Street",
                BillingStreet2 = "Apartment #789",
                BillingCity = "New York City",
                BillingState = "New York",
                BillingZip = "12345",
                BillingEmail = "ILikeToLearn@email.com",
                BillingPhone = "(123)456-7890",
                DeliveryFirstName = "John",
                DeliveryLastName = "Doe",
                DeliveryStreet = "123 Sesame Street",
                DeliveryStreet2 = "Apartment #789",
                DeliveryCity = "New York City",
                DeliveryState = "New York",
                DeliveryZip = 12345,
                CardNumber = "1234567890123456",
                CVV = "123",
                Expiration = "12/99",
                CardHolder = "John Doe",
                LineItems = new List<LineItem>()
                {
                    new LineItem()
                    {
                        ProductId = 3,
                        Quantity = 1
                    }

                }

            };

            var product = new Product()
            {
                Name = "Steel-Toed Sneaker Boots",
                Sku = "ABC-NYUK",
                Description = "Sneaker styled boots designed for comfort, with metal steel at the toe for foot protection.",
                Demographic = "Men",
                Category = "Work",
                Type = "Shoe",
                ReleaseDate = DateTime.Now,
                PrimaryColorCode = "Black",
                SecondaryColorCode = "Black",
                StyleNumber = "15789",
                GlobalProductCode = "A789YT",
                Active = true,

            };

            
            _mockProductRepo.Setup(p => p.GetProductByIdAsync(It.IsAny<int>())).ThrowsAsync(new ServiceUnavailableException("There was a problem connecting to the database."));
            
            await Assert.ThrowsAsync<ServiceUnavailableException>( () =>  _purchaseProvider.CreatePurchasesAsync(purchase));
        }
    }
}
