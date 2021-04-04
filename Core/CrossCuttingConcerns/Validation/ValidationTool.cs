using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        //c sharpda static sınıfın methodlarının da static olması gerekir javada böyle değil 

        public static void Validate(IValidator validator,object entity)
        {

            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {

                throw new ValidationException(result.Errors);
            }
        }
    }
}
