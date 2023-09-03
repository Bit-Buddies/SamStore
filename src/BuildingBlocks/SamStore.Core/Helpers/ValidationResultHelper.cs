using FluentValidation.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Core.Helpers
{
    public static class ValidationResultHelper 
    {
        public static ValidationResult CreateValidationResult()
        {
            return new ValidationResult();
        }

        public static ValidationResult CreateValidationResult(params string[] errors)
        {
            ValidationResult result = new ValidationResult();

            foreach (var error in errors)
                result.Errors.Add(new ValidationFailure() { ErrorMessage = error });

            return result;
        }
    }
}
