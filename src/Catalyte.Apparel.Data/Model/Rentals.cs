using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Catalyte.Apparel.Data.Model
{
    /// <summary>
    /// This class is a representation of a rental.
    /// </summary>
    public class Rental : BaseEntity
    {
        public new int Id { get; set; }

        public string RentalDate { get; set; }

        public List<Movie> RentedMovies { get; set; }

        public decimal RentalTotalCost { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static IEqualityComparer<Rental> RentalComparer { get; } = new RentalEqualityComparer();

        private sealed class RentalEqualityComparer : IEqualityComparer<Rental>
        {
            public bool Equals(Rental x, Rental y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.RentalDate == y.RentalDate && x.RentedMovies == y.RentedMovies && x.RentalTotalCost == y.RentalTotalCost;
            }

            public int GetHashCode(Rental obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.Id);
                hashCode.Add(obj.RentalDate);
                hashCode.Add(obj.RentedMovies);
                hashCode.Add(obj.RentalTotalCost);

                return hashCode.ToHashCode();
            }
        }
    }
}
