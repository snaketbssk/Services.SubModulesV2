using Microsoft.AspNetCore.Http;
using System.Text;

namespace Services.SubModules.LogicLayers.Helpers
{
    /// <summary>
    /// Provides utility methods for working with IFormFile instances (file uploads).
    /// </summary>
    public static class FormFileHelper
    {
        /// <summary>
        /// Extracts the name (without extension) from an IFormFile instance.
        /// </summary>
        /// <param name="formFile">The IFormFile instance to extract the name from.</param>
        /// <returns>The extracted name without extension.</returns>
        public static string ToName(IFormFile formFile)
        {
            var result = Path.GetFileNameWithoutExtension(formFile.FileName);
            return result;
        }

        /// <summary>
        /// Extracts the name (without extension) from a file name.
        /// </summary>
        /// <param name="fileName">The file name to extract the name from.</param>
        /// <returns>The extracted name without extension.</returns>
        public static string ToName(string fileName)
        {
            var result = Path.GetFileNameWithoutExtension(fileName);
            return result;
        }

        /// <summary>
        /// Extracts the extension (without dot) from an IFormFile instance.
        /// </summary>
        /// <param name="formFile">The IFormFile instance to extract the extension from.</param>
        /// <returns>The extracted extension without dot.</returns>
        public static string ToExtension(IFormFile formFile)
        {
            var value = Path.GetExtension(formFile.FileName);
            var result = value.Replace(".", "");
            return result;
        }

        /// <summary>
        /// Extracts the extension (without dot) from a file name.
        /// </summary>
        /// <param name="fileName">The file name to extract the extension from.</param>
        /// <returns>The extracted extension without dot.</returns>
        public static string ToExtension(string fileName)
        {
            var value = Path.GetExtension(fileName);
            var result = value.Replace(".", "");
            return result;
        }

        /// <summary>
        /// Converts an IFormFile instance to a byte array.
        /// </summary>
        /// <param name="formFile">The IFormFile instance to convert.</param>
        /// <returns>The byte array representing the content of the IFormFile.</returns>
        public static byte[] ToBytes(IFormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            formFile.CopyTo(memoryStream);
            var result = memoryStream.ToArray();
            return result;
        }

        /// <summary>
        /// Converts an IFormFile instance to a base64 encoded string.
        /// </summary>
        /// <param name="formFile">The IFormFile instance to convert.</param>
        /// <returns>The base64 encoded string representing the content of the IFormFile.</returns>
        public static string ToBase64String(IFormFile formFile)
        {
            var value = ToBytes(formFile);
            var result = Convert.ToBase64String(value);
            return result;
        }

        /// <summary>
        /// Reads the content of an IFormFile instance as a string.
        /// </summary>
        /// <param name="formFile">The IFormFile instance to read from.</param>
        /// <returns>The content of the IFormFile as a string.</returns>
        public static string ToContent(IFormFile formFile)
        {
            var result = new StringBuilder();
            using var reader = new StreamReader(formFile.OpenReadStream());
            while (reader.Peek() >= 0)
            {
                result.AppendLine(reader.ReadLine());
            }
            return result.ToString();
        }

        /// <summary>
        /// Asynchronously reads the content of an IFormFile instance as a string.
        /// </summary>
        /// <param name="formFile">The IFormFile instance to read from.</param>
        /// <returns>The content of the IFormFile as a string.</returns>
        public static async Task<string> ToContentAsync(IFormFile formFile)
        {
            var result = new StringBuilder();
            using var reader = new StreamReader(formFile.OpenReadStream());
            while (reader.Peek() >= 0)
            {
                result.AppendLine(await reader.ReadLineAsync());
            }
            return result.ToString();
        }
    }

}
