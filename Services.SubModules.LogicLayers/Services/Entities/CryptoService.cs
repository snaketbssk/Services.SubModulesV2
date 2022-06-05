using System.Security.Cryptography;
using System.Text;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    public class CryptoService : ICryptoService
    {
        public string ComputeHash(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            var hashData = SHA512.HashData(bytes);
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < hashData.Length; i++)
            {
                stringBuilder.Append(hashData[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
