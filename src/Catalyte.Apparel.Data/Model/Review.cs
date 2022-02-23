using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalyte.Apparel.Data.Model
{
    /// <summary>
    /// This class is a representation of a product review.
    /// </summary>
    public class Review : BaseEntity
    {
        public string UserEmail { get; set; }

        public int Rating { get; set; }

        [Column("Product")]
        public int ProductId { get; set;}

        [MaxLength(280)]
        public string Description { get; set; }

        public static IEqualityComparer<Review> ReviewComparer { get; } = new ReviewEqualityComparer();

        sealed class ReviewEqualityComparer : IEqualityComparer<Review>
        {
            public bool Equals(Review x, Review y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.UserEmail == y.UserEmail && x.Rating == y.Rating && x.ProductId == y.ProductId && x.Description == y.Description;
            }

            public int GetHashCode(Review obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.UserEmail);
                hashCode.Add(obj.Rating);
                hashCode.Add(obj.ProductId);
                hashCode.Add(obj.Description);
                return hashCode.ToHashCode();
            }
        }
    }
}

