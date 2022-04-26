using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Catalyte.Theater.Data.Model
{
    /// <summary>
    /// This class is a representation of a rented movie.
    /// </summary>
    public class RentedMovie : BaseEntity
    {

        public int MovieId { get; set; }

        public int DaysRented { get; set; }

        public int RentalId { get; set; }

        public Movie Movie { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static IEqualityComparer<RentedMovie> RentedMovieComparer { get; } = new RentedMovieEqualityComparer();

        private sealed class RentedMovieEqualityComparer : IEqualityComparer<RentedMovie>
        {
            public bool Equals(RentedMovie x, RentedMovie y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id 
                    && x.MovieId == y.MovieId 
                    && x.DaysRented == y.DaysRented 
                    && x.RentalId == y.RentalId 
                    && x.Movie == y.Movie;
            }

            public int GetHashCode(RentedMovie obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.Id);
                hashCode.Add(obj.MovieId);
                hashCode.Add(obj.DaysRented);
                hashCode.Add(obj.RentalId);
                hashCode.Add(obj.Movie);

                return hashCode.ToHashCode();
            }
        }
    }
}
