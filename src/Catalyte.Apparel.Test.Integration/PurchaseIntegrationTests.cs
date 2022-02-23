using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Catalyte.Apparel.DTOs.Purchases;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalyte.Apparel.Test.Integration
{
    /// <summary>
    /// Integration Test for Credit Card Validation with Data Annotations.
    /// </summary>


    public class PurchaseIntegrationTests : IntegrationTests
    {

        [Fact]
        public async Task CreditCardValid_Success()
        {
            var lineItem = new LineItemDTO()
            {

                ProductId = 1,
                Quantity = 1,

            };

            var purchase = new PurchaseDTO()
            {

                OrderDate = DateTime.UtcNow,
                DeliveryAddress = new DeliveryAddressDTO
                {
                    DeliveryCity = "Los Angeles",
                    DeliveryState = "CA",
                    DeliveryStreet = "1232 Hickley",
                    DeliveryZip = 43690,
                    DeliveryFirstName = "Ryan",
                    DeliveryLastName = "Space",

                },
                BillingAddress = new BillingAddressDTO
                {
                    BillingCity = "Honolulu",
                    Email = "customer34@home.com",
                    Phone = "(808) 345-8765",
                    BillingState = "HI",
                    BillingStreet = "123 Main",
                    BillingStreet2 = "Apt A",
                    BillingZip = 31625,
                },
                CreditCard = new CreditCardDTO()
                {
                    CardHolder = "Max Perkins",
                    CardNumber = "5135678998761234",
                    Expiration = "11/23",
                    CVV = "056",
                },
                LineItems = new List<LineItemDTO>
                {
                    lineItem
                }
            };

            string json = JsonConvert.SerializeObject(purchase);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/purchases", httpContent);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        }

        [Fact]
        public async Task CreditCardValid_Fail()
        {
            var lineItem = new LineItemDTO()
            {

                ProductId = 1,
                Quantity = 1,

            };

            var purchase = new PurchaseDTO()
            {

                OrderDate = DateTime.UtcNow,
                DeliveryAddress = new DeliveryAddressDTO
                {
                    DeliveryCity = "Birmingham",
                    DeliveryState = "AL",
                    DeliveryStreet = "123 Hickley",
                    DeliveryZip = 43690,
                    DeliveryFirstName = "Max",
                    DeliveryLastName = "Space",

                },
                BillingAddress = new BillingAddressDTO
                {
                    BillingCity = "Atlanta",
                    Email = "customer@home.com",
                    Phone = "(714) 345-8765",
                    BillingState = "GA",
                    BillingStreet = "123 Main",
                    BillingStreet2 = "Apt A",
                    BillingZip = 31675,
                },
                CreditCard = new CreditCardDTO
                {
                    CardHolder = " ",
                    CardNumber = " ",
                    Expiration = " ",
                    CVV = " ",
                },
                LineItems = new List<LineItemDTO>
                {
                    lineItem
                }
            };

            string json = JsonConvert.SerializeObject(purchase);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/purchases", httpContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }
    }
}




