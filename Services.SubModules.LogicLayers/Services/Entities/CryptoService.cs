using Microsoft.AspNetCore.WebUtilities;
using Services.SubModules.Configurations.Entities.Environments;
using Services.SubModules.Configurations.Models.Roots.Entities.Environments;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Services.SubModules.LogicLayers.Services.Entities
{
    /// <summary>
    /// Provides cryptographic operations such as hashing and encryption/decryption.
    /// </summary>
    public class CryptoService : ICryptoService
    {
        /// <summary>
        /// The encryption key used for cryptographic operations.
        /// </summary>
        private readonly byte[] _key;

        /// <summary>
        /// The initialization vector (IV) used for cryptographic operations.
        /// </summary>
        private readonly byte[] _iv;

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptoService"/> class.
        /// </summary>
        public CryptoService()
        {
            var root = CryptographyEnvironmentConfiguration<CryptographyEnvironmentRoot>.Instance.GetRoot();
            _key = Convert.FromBase64String(root.KEY);
            _iv = Convert.FromBase64String(root.IV);
        }

        /// <summary>
        /// Computes the SHA-512 hash of a given value.
        /// </summary>
        /// <param name="value">The input value to be hashed.</param>
        /// <returns>The computed hash as a hexadecimal string.</returns>
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

        /// <summary>
        /// Decrypts a Base64-encoded string to an object of type T using JSON deserialization.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
        /// <param name="value">The Base64-encoded string to decrypt.</param>
        /// <returns>The deserialized object of type T.</returns>
        public T DecryptFromBase64<T>(string value) where T : class
        {
            var json = DecryptFromBase64(value);
            var result = JsonSerializer.Deserialize<T>(json);
            return result;
        }

        /// <summary>
        /// Decrypts a Base64-encoded string to its original plaintext representation.
        /// </summary>
        /// <param name="value">The Base64-encoded string to decrypt.</param>
        /// <returns>The decrypted plaintext string.</returns>
        public string DecryptFromBase64(string value)
        {
            var bytes = WebEncoders.Base64UrlDecode(value);
            var result = DecryptToBytes(bytes);
            return result;
        }

        /// <summary>
        /// Decrypts a byte array to its original plaintext representation.
        /// </summary>
        /// <param name="value">The byte array to decrypt.</param>
        /// <returns>The decrypted plaintext string.</returns>
        public string DecryptToBytes(byte[] value)
        {
            var result = DecryptFromBytes(value, _key, _iv);
            return result;
        }

        /// <summary>
        /// Encrypts an object of type T to a Base64-encoded string using JSON serialization.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize and encrypt.</typeparam>
        /// <param name="value">The object to be encrypted.</param>
        /// <returns>The Base64-encoded encrypted string.</returns>
        public string EncryptToBase64<T>(T value) where T : class
        {
            var json = JsonSerializer.Serialize(value);
            var result = EncryptToBase64(json);
            return result;
        }

        /// <summary>
        /// Encrypts a plaintext string to a Base64-encoded encrypted string.
        /// </summary>
        /// <param name="value">The plaintext string to encrypt.</param>
        /// <returns>The Base64-encoded encrypted string.</returns>
        public string EncryptToBase64(string value)
        {
            var bytes = EncryptToBytes(value);
            var result = WebEncoders.Base64UrlEncode(bytes);
            return result;
        }

        /// <summary>
        /// Encrypts a plaintext string to an array of encrypted bytes.
        /// </summary>
        /// <param name="value">The plaintext string to encrypt.</param>
        /// <returns>The encrypted bytes.</returns>
        public byte[] EncryptToBytes(string value)
        {
            var result = EncryptToBytes(value, _key, _iv);
            return result;
        }

        /// <summary>
        /// Encrypts the given string value using AES encryption.
        /// </summary>
        /// <param name="value">The value to be encrypted.</param>
        /// <param name="key">The encryption key.</param>
        /// <param name="iv">The initialization vector.</param>
        /// <returns>The encrypted bytes.</returns>
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

        /// <summary>
        /// Decrypts the given byte array using AES decryption.
        /// </summary>
        /// <param name="value">The byte array to be decrypted.</param>
        /// <param name="key">The decryption key.</param>
        /// <param name="iv">The initialization vector.</param>
        /// <returns>The decrypted string.</returns>
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
