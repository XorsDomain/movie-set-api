using System.ComponentModel.DataAnnotations;

namespace Catalyte.Apparel.Data.Model
{
    public class Promo : BaseEntity
    {

        [MaxLength(100)]
        public string Code { get; set; }

        public string Description { get; set; }

        [MaxLength(100)]
        public string Type { get; set; }

        public decimal Amount { get; set; }

    }
}
