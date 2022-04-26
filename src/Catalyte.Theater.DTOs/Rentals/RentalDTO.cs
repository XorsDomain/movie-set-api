using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Catalyte.Theater.DTOs.Rentals
{
    /// <summary>
    /// Describes a data transfer object for a rental.
    /// </summary>
    public class RentalDTO
    {
        public int Id { get; set; }

        public DateTime RentalDate { get; set; }

        public ICollection<RentedMoviesDTO> RentedMovies { get; set; }

        public decimal RentalTotalCost { get; set; }
    }
}
