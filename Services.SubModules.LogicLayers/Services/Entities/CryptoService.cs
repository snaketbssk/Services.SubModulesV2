using Microsoft.AspNetCore.WebUtilities;
using Services.SubModules.Configurations.Entities;
using Services.SubModules.Configurations.Models.Roots.Entities;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class CryptoService : ICryptoService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly byte[] _key;

        /// <summary>
        /// 
        /// </summary>
        private readonly byte[] _iv;

        public CryptoService()
        {
            var root = CryptographyConfiguration<CryptographyRoot>.Instance.Root;
            _key = Convert.FromBase64String(root.KeyCryptography);
            _iv = Convert.FromBase64String(root.IvCryptography);
        }

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

        public T DecryptFromBase64<T>(string value) where T : class
        {
            var json = DecryptFromBase64(value);
            var result = JsonSerializer.Deserialize<T>(json);
            return result;
        }

        public string DecryptFromBase64(string value)
        {
            var bytes = WebEncoders.Base64UrlDecode(value);
            var result = DecryptToBytes(bytes);
            return result;
        }

        public string DecryptToBytes(byte[] value)
        {
            var result = DecryptFromBytes(value, _key, _iv);
            return result;
        }

        public string EncryptToBase64<T>(T value) where T : class
        {
            var json = JsonSerializer.Serialize(value);
            var result = EncryptToBase64(json);
            return result;
        }

        public string EncryptToBase64(string value)
        {
            var bytes = EncryptToBytes(value);
            var result = WebEncoders.Base64UrlEncode(bytes);
            return result;
        }

        public byte[] EncryptToBytes(string value)
        {
            var result = EncryptToBytes(value, _key, _iv);
            return result;
        }

        private byte[] EncryptToBytes(string value, byte[] key, byte[] iv)
        {
            if (value == null || value.Length <= 0)
                throw new ArgumentNullException(nameof(value));
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException(nameof(key));
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(iv));
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(value);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        private string DecryptFromBytes(byte[] value, byte[] key, byte[] iv)
        {
            if (value == null || value.Length <= 0)
                throw new ArgumentNullException(nameof(value));
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException(nameof(key));
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException(nameof(iv));

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(value))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
