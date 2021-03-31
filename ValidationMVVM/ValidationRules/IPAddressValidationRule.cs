using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using System.Windows.Controls;

namespace ValidationMVVM.ValidationRules
{
    public class IPAddressValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(IPAddress.TryParse(value.ToString(), out IPAddress ipAddress))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "IP address is invalid.");
        }
    }
}
