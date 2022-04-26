using System.ComponentModel.DataAnnotations;

namespace Catalyte.Theater.DTOs.Movies
{
    /// <summary>
    /// Describes a data transfer object for a movie.
    /// </summary>
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]{5}\-[0-9]{4}$", ErrorMessage = "This field requires a format of 'LLLLL-DDDD'.")]
        public string Sku { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+[.][0-9]{2}$", ErrorMessage = "Numbers with the decimal format 'X.XX' is required.")]
        public decimal DailyRentalCost { get; set; }


    }
}
