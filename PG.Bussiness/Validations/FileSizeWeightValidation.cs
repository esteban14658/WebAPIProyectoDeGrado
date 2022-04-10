using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PG.Bussiness.Validations
{
    public class FileSizeWeightValidation : ValidationAttribute
    {
        private readonly int _maxWeightOnMB;

        public FileSizeWeightValidation(int maxWeightOnMB)
        {
            _maxWeightOnMB = maxWeightOnMB;
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
            if (formFile.Length > _maxWeightOnMB * 1024 * 1024)
            {
                return new ValidationResult($"the weight of the file should not be greater than {_maxWeightOnMB}mb");
            }
            return ValidationResult.Success;
        }
    }
}
