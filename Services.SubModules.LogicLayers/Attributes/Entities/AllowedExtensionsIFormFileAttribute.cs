using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Services.SubModules.LogicLayers.Attributes.Entities
{
    /// <summary>
    /// Custom validation attribute to check if the uploaded IFormFile has allowed extensions.
    /// </summary>
    public class AllowedExtensionsIFormFileAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        /// <summary>
        /// Initializes a new instance of the <see cref="AllowedExtensionsIFormFileAttribute"/> class with allowed extensions.
        /// </summary>
        /// <param name="extensions">An array of allowed file extensions.</param>
        public AllowedExtensionsIFormFileAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        /// <summary>
        /// Validates whether the uploaded IFormFile has an allowed extension.
        /// </summary>
        /// <param name="value">The value to be validated.</param>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating whether the value is valid.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is null)
            {
                return ValidationResult.Success;
            }
            var extension = Path.GetExtension(file.FileName);
            if (!_extensions.Contains(extension.ToLower()))
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }

        /// <summary>
        /// Gets the error message for the validation.
        /// </summary>
        /// <returns>The error message.</returns>
        public string GetErrorMessage()
        {
            return $"Your image's filetype is not valid.";
        }
    }
}
