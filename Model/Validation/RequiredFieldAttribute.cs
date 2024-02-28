using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Validation
{
    public class RequiredFieldAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Field Cannot be Empty");
        }
    }
}
