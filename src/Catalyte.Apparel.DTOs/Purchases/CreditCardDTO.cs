using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Catalyte.Apparel.DTOs.Purchases
{
    /// <summary>
    /// Describes a data transfer object for a credit card.
    /// </summary>
    public class CreditCardDTO
    {

        [Required]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Requires 16 digits")]
        [NumberValidator]
        public string CardNumber { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Requires 3 digits")]
        public string CVV { get; set; }

        [Required]
        [DateValidator(ErrorMessage = "Expiration date should be future date")]
        public string Expiration { get; set; }
                                             
        [Required]
        public string CardHolder { get; set; }

    }

    public class NumberValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Regex rgx = new Regex(@"^\d{16}$");
            if (Regex.IsMatch((string) value, "^(4|5)"))
            {
                return true;
            }
            return false;
        }
    }

    public class DateValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            Regex rx = new Regex(@"^\d{2}\/\d{2}$");
            if (rx.IsMatch((string)value))
            {
                var date = DateTime.ParseExact((string)value, "MM/yy", null);
                if (date.Year >= DateTime.Now.Year && date.Month >= DateTime.Now.Month)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
