using System;

namespace Catalyte.Apparel.DTOs.Reviews
{
    /// <summary>
    /// Describes a data transfer object for a product review.
    /// </summary>
    public class ReviewDTO
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public string UserEmail { get; set; }

        public int Rating { get; set; }

        public int ProductId { get; set; }

        public string Description { get; set; }
    }
}
