namespace Services.SubModules.LogicLayers.Services
{
    /// <summary>
    /// Represents a service for cryptographic operations.
    /// </summary>
    public interface ICryptoService
    {
        /// <summary>
        /// Computes a hash value for the given input.
        /// </summary>
        /// <param name="value">The input value to be hashed.</param>
        /// <returns>The computed hash value as a string.</returns>
        string ComputeHash(string value);

        /// <summary>
        /// Decrypts a Base64-encoded value to an object of type T.
        /// </summary>
        /// <typeparam name="T">The type to which the value should be decrypted.</typeparam>
        /// <param name="value">The Base64-encoded value to be decrypted.</param>
        /// <returns>The decrypted object of type T.</returns>
        T DecryptFromBase64<T>(string value) where T : class;

        /// <summary>
        /// Decrypts a Base64-encoded value to a string.
        /// </summary>
        /// <param name="value">The Base64-encoded value to be decrypted.</param>
        /// <returns>The decrypted value as a string.</returns>
        string DecryptFromBase64(string value);

        /// <summary>
        /// Decrypts a byte array to a string.
        /// </summary>
        /// <param name="value">The byte array to be decrypted.</param>
        /// <returns>The decrypted value as a string.</returns>
        string DecryptToBytes(byte[] value);

        /// <summary>
        /// Encrypts an object of type T to a Base64-encoded string.
        /// </summary>
        /// <typeparam name="T">The type of the object to be encrypted.</typeparam>
        /// <param name="value">The object to be encrypted.</param>
        /// <returns>The encrypted value as a Base64-encoded string.</returns>
        string EncryptToBase64<T>(T value) where T : class;

        /// <summary>
        /// Encrypts a string to a Base64-encoded string.
        /// </summary>
        /// <param name="value">The string to be encrypted.</param>
        /// <returns>The encrypted value as a Base64-encoded string.</returns>
        string EncryptToBase64(string value);

        /// <summary>
        /// Encrypts a string to a byte array.
        /// </summary>
        /// <param name="value">The string to be encrypted.</param>
        /// <returns>The encrypted value as a byte array.</returns>
        byte[] EncryptToBytes(string value);
    }
}
