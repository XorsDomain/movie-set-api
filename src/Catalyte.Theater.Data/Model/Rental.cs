using System;
using System.Collections.Generic;

namespace Catalyte.Theater.Data.Model
{
    public class Rental : BaseEntity
    {
        public DateTime RentalDate { get; set; }

        public ICollection<RentedMovie> RentedMovies { get; set; }

        public decimal RentalTotalCost { get; set; }
    }
}
