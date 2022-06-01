using Microsoft.AspNetCore.Http;
using System.Text;

namespace Services.SubModules.LogicLayers.Helpers
{
    public static class FormFileHelper
    {
        public static string ToName(IFormFile formFile)
        {
            var result = Path.GetFileNameWithoutExtension(formFile.FileName);
            return result;
        }
        public static string ToName(string fileName)
        {
            var result = Path.GetFileNameWithoutExtension(fileName);
            return result;
        }
        public static string ToExtension(IFormFile formFile)
        {
            var value = Path.GetExtension(formFile.FileName);
            var result = value.Replace(".", "");
            return result;
        }
        public static string ToExtension(string fileName)
        {
            var value = Path.GetExtension(fileName);
            var result = value.Replace(".", "");
            return result;
        }
        public static byte[] ToBytes(IFormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            formFile.CopyTo(memoryStream);
            var result = memoryStream.ToArray();
            return result;
        }
        public static string ToBase64String(IFormFile formFile)
        {
            var value = ToBytes(formFile);
            var result = Convert.ToBase64String(value);
            return result;
        }

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
