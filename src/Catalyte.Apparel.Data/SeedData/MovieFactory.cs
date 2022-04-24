using Catalyte.Apparel.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalyte.Apparel.Data.SeedData
{
    /// <summary>
    /// This class provides tools for generating random movies.
    /// </summary>
    public class MovieFactory
    {
        Random _rand = new();

        private readonly List<string> _genres = new()
        {
            "Action",
            "Horror",
            "Drama",
            "Comedy",
            "Sci-Fi",
            "Thriller",
            "Western",
            "Romance",
            "Crime Film",
            "Adventure",
            "Musical",
            "Romantic Comedy",
            "Documentary",
            "Animation",
            "Fantasy",
            "Historical",
            "Mystery",
            "Sports",
            "Comedy",
            "Biographical",
            "Found Footage",
            "Short",
            "Indie",
            "Slasher",
            "Comedy Horror"
        };


        private List<string> _directors = new()
        {
            "George Marshall",
            "Brian Durel",
            "Blair Purdy",
            "Cierra Anderson",
            "Ahmed Roberts",
            "Adam Gaskin",
            "Carlos Santiago",
            "Jaron Christman",
            "Annah Henderson",
            "WaiYing Wong",
            "Reyna Javar",
            "Andy Makous",
            "Stephen Smith",
            "Vivian Marley"
        };

        private readonly List<string> _skuMods = new()
        {
            "2453",
            "7542",
            "4256",
            "8635",
            "4258",
            "7239",
            "4586",
            "9752",
            "5236",
            "4156",
            "3421",
            "3121",
            "9876",
            "1234",
            "5689",
            "7410"
        };

        private readonly List<string> _adjectives = new()
        {
            "Funny",
            "Scary",
            "Terrifying",
            "Horrific",
            "Hilarious",
            "Action-Packed",
            "Adventurous",
            "Heart-Warming",
            "Sad",
            "Heart-Breaking",
            "Nail-Biting",
            "Heroic",
            "Villanous",
            "Super",
            "Insightful",
            "Sensitive",
            "Pleasant",
            "Intriguing",
            "Powerful",
            "Legendary",
            "Powerful",
            "Disgisting",
            "Brutal",
            "Bland",
            "Weak",
            "Bloody",
            "Uneven",
            "Juvenile",
            "Flawless",
            "Dreadful",
            "Cliche",
            "Distasteful",
            "Wacky",
            "Satirical",
            "Sentimental"
        };

        /// <summary>
        /// Generates a randomized movie SKU.
        /// </summary>
        /// <returns>A SKU string.</returns>
        private string GetRandomSku()
        {
            var builder = new StringBuilder();
            builder.Append(RandomString(6));
            builder.Append('-');
            builder.Append(_skuMods[_rand.Next(_skuMods.Count)]);

            return builder.ToString().ToUpper();
        }


        /// <summary>
        /// Returns a random genre from the list of genres.
        /// </summary>
        /// <returns>A genre string.</returns>
        private string GetRandomGenre()
        {
            return _genres[_rand.Next(_genres.Count)];
        }

        /// <summary>
        /// Returns a random adjective from the list of adjectives.
        /// </summary>
        /// <returns>An adjective string.</returns>
        private string GetRandomAdjective()
        {
            return _adjectives[_rand.Next(_adjectives.Count)];
        }

        /// <summary>
        /// Generates a random price between 9.99 and 25.00.
        /// </summary>
        /// <returns>A decimal with two decimal places representing the price.</returns>
        private decimal GetDailyRentalCost()
        {
            var result = new decimal((_rand.Next(199, 999)));
            return Math.Round((result) / 100, 2);
        }

        /// <summary>
        /// Returns a random type from the list of directors.
        /// </summary>
        /// <returns>A type string.</returns>
        private string GetRandomDirector()
        {
            return _directors[_rand.Next(0, _directors.Count)];
        }

        /// <summary>
        /// Generates a number of random movies based on input.
        /// </summary>
        /// <param name="numberOfMovies">The number of random movies to generate.</param>
        /// <returns>A list of random movies.</returns>
        internal List<Movie> GenerateRandomMovies(int numberOfMovies)
        {
            var movieList = new List<Movie>();

            for (var i = 0; i < numberOfMovies; i++)
            {
                movieList.Add(CreateRandomMovie(i + 1));
            }
            return movieList;
        }

        /// <summary>
        /// Uses random generators to build a movie.
        /// </summary>
        /// <param name="id">ID to assign to the movie.</param>
        /// <returns>A randomly generated movie.</returns>
        private Movie CreateRandomMovie(int id)
        {
            // Create adjective, director, and genre variables
            // Used to maintain consistency across fields including Title.
            String randGenre = GetRandomGenre();
            String randDirector = GetRandomDirector();
            String randAdjective = GetRandomAdjective();
            return new Movie
            {
                Id = id,
                Sku = GetRandomSku(),
                Title = randAdjective + " " + randGenre + " " + "Movie",
                Genre = randGenre,
                Director = randDirector,
                DailyRentalCost = GetDailyRentalCost()
            };
        }

        /// <summary>
        /// Generates a random string of characters.
        /// </summary>
        /// <param name="size">Number of characters in the string.</param>
        /// <param name="lowerCase">Boolean if the character string should be lowercase only; defaults to false.</param>
        /// <returns>A random string of characters.</returns>
        private string RandomString(int size, bool lowerCase = false)
        {

            // ** Learning moment **
            // Code From
            // https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/

            // ** Learning moment **
            // Always use a string builder when concatenating more than a couple of strings.
            // Why? https://www.geeksforgeeks.org/c-sharp-string-vs-stringbuilder/
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                // ** Learning moment **
                // Because 'char' is a reserved word you can put '@' at the beginning to allow
                // its use as a variable name.  You could do the same thing with 'class'
                var @char = (char)_rand.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }

}
