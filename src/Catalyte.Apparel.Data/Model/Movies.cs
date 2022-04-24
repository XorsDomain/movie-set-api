using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Catalyte.Apparel.Data.Model
{
    /// <summary>
    /// This class is a representation of a movie.
    /// </summary>
    public class Movie : BaseEntity
    {
        public new int Id { get; set; }

        public string Sku { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public string Director { get; set; }

        public decimal DailyRentalCost { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static IEqualityComparer<Movie> MovieComparer { get; } = new MovieEqualityComparer();

        private sealed class MovieEqualityComparer : IEqualityComparer<Movie>
        {
            public bool Equals(Movie x, Movie y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Title == y.Title && x.Sku == y.Sku && x.DailyRentalCost == y.DailyRentalCost && x.Director == y.Director && x.Genre == y.Genre && x.Id == y.Id;
            }

            public int GetHashCode(Movie obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.Id);
                hashCode.Add(obj.Title);
                hashCode.Add(obj.Genre);
                hashCode.Add(obj.Director);
                hashCode.Add(obj.DailyRentalCost);
                
                return hashCode.ToHashCode();
            }
        }
    }

}
