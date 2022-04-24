using Catalyte.Apparel.DTOs.Movies;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Catalyte.Apparel.DTOs.Rentals
{
    /// <summary>
    /// Describes a data transfer object for a rental.
    /// </summary>
    public class RentalDTO
    {
        public int Id { get; set; }

        public string RentalDate { get; set; }

        public List<MovieDTO> RentedMovies { get; set; }

        public decimal RentalTotalCost { get; set; }
    }

}
