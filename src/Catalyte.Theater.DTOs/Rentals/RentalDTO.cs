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
        [Required]
        [RegularExpression("@^[0-9]{4}-((0[1-9])|(1[012]))-((0[1-9]|[12][0-9])|3[01]", ErrorMessage = "Format must equal 'YYYY-MM-DD'.")]
        public DateTime RentalDate { get; set; }
        [Required]
        public ICollection<RentedMoviesDTO> RentedMovies { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+[.][0-9]{2}$", ErrorMessage = "Numbers with the decimal format 'X.XX' is required.")]
        public decimal RentalTotalCost { get; set; }
    }
}
