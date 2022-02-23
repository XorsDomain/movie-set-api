using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Data.SeedData;
using Microsoft.EntityFrameworkCore;
using System;

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
            var productFactory = new ProductFactory();

            modelBuilder.Entity<Product>().HasData(productFactory.GenerateRandomProducts(1000));

            var reviewFactory = new ReviewFactory();

            modelBuilder.Entity<Review>().HasData(reviewFactory.GenerateRandomReviews(600));

            var lineItem = new LineItem()
            {
                Id = 6,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ProductId = 21,
                Quantity = 99,
                PurchaseId = 1
            };
            var lineItem2 = new LineItem()
            {
                Id = 1,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ProductId = 71,
                Quantity = 6,
                PurchaseId = 2
            };
            var lineItem3 = new LineItem()
            {
                Id = 2,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ProductId = 61,
                Quantity = 7,
                PurchaseId = 3
            };
            var lineItem4 = new LineItem()
            {
                Id = 3,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ProductId = 51,
                Quantity = 8,
                PurchaseId = 3
            };
            var lineItem5 = new LineItem()
            {
                Id = 4,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ProductId = 41,
                Quantity = 9,
                PurchaseId = 2
            };
            var lineItem6 = new LineItem()
            {
                Id = 5,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ProductId = 31,
                Quantity = 10,
                PurchaseId = 1
            };
            var lineItem7 = new LineItem()
            {
                Id = 7,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ProductId = 51,
                Quantity = 8,
                PurchaseId = 4
            };
            var lineItem8 = new LineItem()
            {
                Id = 8,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ProductId = 41,
                Quantity = 9,
                PurchaseId = 5
            };
            var lineItem9 = new LineItem()
            {
                Id = 9,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ProductId = 31,
                Quantity = 10,
                PurchaseId = 6
            };

            modelBuilder.Entity<LineItem>().HasData(lineItem);
            modelBuilder.Entity<LineItem>().HasData(lineItem2);
            modelBuilder.Entity<LineItem>().HasData(lineItem3);
            modelBuilder.Entity<LineItem>().HasData(lineItem4);
            modelBuilder.Entity<LineItem>().HasData(lineItem5);
            modelBuilder.Entity<LineItem>().HasData(lineItem6);
            modelBuilder.Entity<LineItem>().HasData(lineItem7);
            modelBuilder.Entity<LineItem>().HasData(lineItem8);
            modelBuilder.Entity<LineItem>().HasData(lineItem9);

            var purchase = new Purchase()
            {
                Id = 1,
                BillingCity = "Atlanta",
                BillingEmail = "customer@home.com",
                BillingPhone = "(714) 345-8765",
                BillingState = "GA",
                BillingStreet = "123 Main",
                BillingStreet2 = "Apt A",
                BillingZip = "31675",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                DeliveryCity = "Birmingham",
                DeliveryState = "AL",
                DeliveryStreet = "123 Hickley",
                DeliveryZip = 43690,
                DeliveryFirstName = "Max",
                DeliveryLastName = "Space",
                CardHolder = "Max Perkins",
                CardNumber = "1435678998761234",
                Expiration = "11/21",
                CVV = "456",
                OrderDate = new DateTime(2021, 5, 4)
            };
            var purchase2 = new Purchase()
            {
                Id = 2,
                BillingCity = "Atlanta",
                BillingEmail = "customer2@home.com",
                BillingPhone = "(714) 345-8765",
                BillingState = "GA",
                BillingStreet = "123 Main",
                BillingStreet2 = "Apt A",
                BillingZip = "31675",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                DeliveryCity = "Birmingham",
                DeliveryState = "AL",
                DeliveryStreet = "123 Hickley",
                DeliveryZip = 43690,
                DeliveryFirstName = "Max",
                DeliveryLastName = "Space",
                CardHolder = "Max Perkins",
                CardNumber = "1435678998761234",
                Expiration = "11/21",
                CVV = "456",
                OrderDate = new DateTime(2021, 5, 4)
            };
            var purchase3 = new Purchase()
            {
                Id = 3,
                BillingCity = "Atlanta",
                BillingEmail = "customer3@home.com",
                BillingPhone = "(714) 345-8765",
                BillingState = "GA",
                BillingStreet = "123 Main",
                BillingStreet2 = "Apt A",
                BillingZip = "31675",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                DeliveryCity = "Birmingham",
                DeliveryState = "AL",
                DeliveryStreet = "123 Hickley",
                DeliveryZip = 43690,
                DeliveryFirstName = "Max",
                DeliveryLastName = "Space",
                CardHolder = "Max Perkins",
                CardNumber = "1435678998761234",
                Expiration = "11/21",
                CVV = "456",
                OrderDate = new DateTime(2021, 5, 4)
            };
            var purchase4 = new Purchase()
            {
                Id = 4,
                BillingCity = "Atlanta",
                BillingEmail = "customer3@home.com",
                BillingPhone = "(714) 345-8765",
                BillingState = "GA",
                BillingStreet = "123 Main",
                BillingStreet2 = "Apt A",
                BillingZip = "31675",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                DeliveryCity = "Birmingham",
                DeliveryState = "AL",
                DeliveryStreet = "123 Hickley",
                DeliveryZip = 43690,
                DeliveryFirstName = "Max",
                DeliveryLastName = "Space",
                CardHolder = "Max Perkins",
                CardNumber = "1435678998761234",
                Expiration = "11/21",
                CVV = "456",
                OrderDate = new DateTime(2021, 5, 4)
            };
            var purchase5 = new Purchase()
            {
                Id = 5,
                BillingCity = "Atlanta",
                BillingEmail = "customer2@home.com",
                BillingPhone = "(714) 345-8765",
                BillingState = "GA",
                BillingStreet = "123 Main",
                BillingStreet2 = "Apt A",
                BillingZip = "31675",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                DeliveryCity = "Birmingham",
                DeliveryState = "AL",
                DeliveryStreet = "123 Hickley",
                DeliveryZip = 43690,
                DeliveryFirstName = "Max",
                DeliveryLastName = "Space",
                CardHolder = "Max Perkins",
                CardNumber = "1435678998761234",
                Expiration = "11/21",
                CVV = "456",
                OrderDate = new DateTime(2021, 5, 4)
            };
            var purchase6 = new Purchase()
            {
                Id = 6,
                BillingCity = "Atlanta",
                BillingEmail = "customer@home.com",
                BillingPhone = "(714) 345-8765",
                BillingState = "GA",
                BillingStreet = "123 Main",
                BillingStreet2 = "Apt A",
                BillingZip = "31675",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                DeliveryCity = "Birmingham",
                DeliveryState = "AL",
                DeliveryStreet = "123 Hickley",
                DeliveryZip = 43690,
                DeliveryFirstName = "Max",
                DeliveryLastName = "Space",
                CardHolder = "Max Perkins",
                CardNumber = "1435678998761234",
                Expiration = "11/21",
                CVV = "456",
                OrderDate = new DateTime(2021, 5, 4)
            };

            modelBuilder.Entity<Purchase>().HasData(purchase);
            modelBuilder.Entity<Purchase>().HasData(purchase2);
            modelBuilder.Entity<Purchase>().HasData(purchase3);
            modelBuilder.Entity<Purchase>().HasData(purchase4);
            modelBuilder.Entity<Purchase>().HasData(purchase5);
            modelBuilder.Entity<Purchase>().HasData(purchase6);
        }
    }
}
