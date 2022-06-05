using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Services.SubModules.LogicLayers.Attributes.Entities
{
    public class AllowedExtensionsIFormFileCollectionAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsIFormFileCollectionAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var formFileCollection = value as IFormFileCollection;
            foreach (var file in formFileCollection)
            {
                var extension = Path.GetExtension(file.FileName);
                if (file != null)
                {
                    if (!_extensions.Contains(extension.ToLower()))
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Your image's filetype is not valid.";
        }
    }
}
