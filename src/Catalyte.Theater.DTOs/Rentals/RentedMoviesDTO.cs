using Catalyte.Theater.DTOs.Movies;

namespace Catalyte.Theater.DTOs.Rentals
{
    public class RentedMoviesDTO
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public int DaysRented { get; set; }

        public int RentalId { get; set; }

        public MovieDTO Movie { get; set; }
    }
}
