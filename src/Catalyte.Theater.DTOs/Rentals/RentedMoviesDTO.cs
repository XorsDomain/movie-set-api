using Catalyte.Theater.DTOs.Movies;
using System.ComponentModel.DataAnnotations;

namespace Catalyte.Theater.DTOs.Rentals
{
    public class RentedMoviesDTO
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        [Required]
        [RegularExpression("@^[1-9]$", ErrorMessage = "This field requires numbers greater than 0.")]
        public int DaysRented { get; set; }

        public int RentalId { get; set; }

        public MovieDTO Movie { get; set; }
    }
}
