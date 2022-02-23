using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;

namespace Catalyte.Apparel.Data.SeedData
{
    /// <summary>
    /// This class provides tools for generating random reviews.
    /// </summary>
    public class ReviewFactory
    {
        Random _rand = new();

        private List<string> _userEmails = new()
        {
            "Devyn@email.com",
            "Evelin@email.com",
            "Kamron@email.com",
            "Lane@email.com",
            "Taniyah@email.com"
        };

        private List<int> _ratings = new()
        {
            1,
            2,
            3,
            4,
            5
        };

        private List<string> _descriptions = new()
        {
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
            "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",

            "Ut enim ad minim veniam, quis nostrud exercitation ullamco " +
            "laboris nisi ut aliquip ex ea commodo consequat.",

            "Duis aute irure dolor in reprehenderit in voluptate velit " +
            "esse cillum dolore eu fugiat nulla pariatur.",

            "Excepteur sint occaecat cupidatat non proident, sunt in culpa " +
            "qui officia deserunt mollit anim id est laborum."
        };

        /// <summary>
        /// Returns a random username from the list of usernames.
        /// </summary>
        /// <returns>A username string.</returns>
        private string GetRandomUserEmail()
        {
            return _userEmails[_rand.Next(0, _userEmails.Count)];
        }

        /// <summary>
        /// Generates a random product rating.
        /// </summary>
        /// <returns>A product rating int.</returns>
        private int GetRandomRating()
        {
            return _ratings[_rand.Next(0, _ratings.Count)];
        }

        /// <summary>
        /// Generates a random ProductId.
        /// </summary>
        /// <returns>A ProductId int.</returns>
        private int GetRandomProductId()
        {
            return _rand.Next(1, 1001);
        }

        /// <summary>
        /// Generates a random description.
        /// </summary>
        /// <returns>A style code string.</returns>
        private string GetRandomDescription()
        {
            return _descriptions[_rand.Next(0, _descriptions.Count)];
        }

        /// <summary>
        /// Generates a random date between 1/1/2000 and today.
        /// </summary>
        /// <returns>A style code string.</returns>
        private DateTime GetRandomDateTime()
        {
            DateTime start = new (2000, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_rand.Next(range))
                .AddHours(_rand.Next(0,24))
                .AddMinutes(_rand.Next(0,60))
                .AddSeconds(_rand.Next(0,60))
                .AddTicks(_rand.Next(0000000,9999999));
        }

        /// <summary>
        /// Generates a number of random reviews based on input.
        /// </summary>
        /// <param name="numberOfReviews">The number of random reviews to generate.</param>
        /// <returns>A list of random reviews.</returns>
        public List<Review> GenerateRandomReviews(int numberOfReviews)
        {

            var reviewList = new List<Review>();

            for (var i = 0; i < numberOfReviews; i++)
            {
                reviewList.Add(CreateRandomReview(i + 1));
            }

            return reviewList;
        }

        /// <summary>
        /// Uses random generators to build a review.
        /// </summary>
        /// <param name="id">Product ID to assign to the product.</param>
        /// <returns>A randomly generated review.</returns>
        private Review CreateRandomReview(int id)
        {
            return new Review
            {
                Id = id,
                UserEmail = GetRandomUserEmail(),
                Rating = GetRandomRating(),
                ProductId = GetRandomProductId(),
                Description = GetRandomDescription(),
                DateCreated = GetRandomDateTime(),
                DateModified = DateTime.UtcNow
            };
        }
    }
};
