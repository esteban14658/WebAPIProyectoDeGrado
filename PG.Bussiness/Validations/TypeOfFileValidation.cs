using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.Bussiness.Validations
{
    public class TypeOfFileValidation: ValidationAttribute
    {
        private readonly string[] _typeOfFile;

        public TypeOfFileValidation(string[] typeOfFile)
        {
            _typeOfFile = typeOfFile;
        }

        public TypeOfFileValidation(TypeOfFyleGroup typeOfFyleGroup)
        {
            if (typeOfFyleGroup == TypeOfFyleGroup.Image)
            {
                _typeOfFile = new string[] { "image/jpeg", "image/png", "image/gif" };
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if (formFile == null)
            {
                return ValidationResult.Success;
            }
            if (!_typeOfFile.Contains(formFile.ContentType))
            {
                return new ValidationResult($"the type of file must be one of the following: {string.Join(", ", _typeOfFile)}");
            }
            return ValidationResult.Success;
        }
    }
}
