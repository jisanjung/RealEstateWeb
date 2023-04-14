using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Security
    {
        private static byte[] key = { 160, 28, 137, 36, 168, 148, 209, 130, 32, 109, 206, 118, 251, 134, 186, 82 };
        private static byte[] vector = { 89, 121, 16, 123, 36, 175, 245, 244, 100, 127, 64, 240, 64, 54, 133, 136 };
        public static string Encrypt(string password)
        {
            UTF8Encoding encoder = new UTF8Encoding();      // used to convert bytes to characters, and back

            // Convert a string to a byte array, which will be used in the encryption process.
            byte[] strToBytes = encoder.GetBytes(password);

            RijndaelManaged rm = new RijndaelManaged(); // Create an instances of the encryption algorithm (Rinjdael AES) for the encryption to perform,
            MemoryStream ms = new MemoryStream(); // a memory stream used to store the encrypted data temporarily, and
            CryptoStream cs = new CryptoStream(ms, rm.CreateEncryptor(key, vector), CryptoStreamMode.Write); // a crypto stream that performs the encryption algorithm.

            // Use the crypto stream to perform the encryption on the plain text byte array.
            cs.Write(strToBytes, 0, strToBytes.Length);
            cs.FlushFinalBlock();

            // Retrieve the encrypted data from the memory stream, and write it to a separate byte array.
            ms.Position = 0;
            Byte[] encryptedBytes = new Byte[ms.Length];
            ms.Read(encryptedBytes, 0, encryptedBytes.Length);

            // Close all the streams.
            cs.Close();
            ms.Close();

            string encryptedPassword = Convert.ToBase64String(encryptedBytes);
            return encryptedPassword;
        }

        public static string Decrypt(string encryptedPassword)
        {
            byte[] strToBytes = Convert.FromBase64String(encryptedPassword);
            UTF8Encoding encoder = new UTF8Encoding();

            RijndaelManaged rm = new RijndaelManaged();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, rm.CreateDecryptor(key, vector), CryptoStreamMode.Write);

            cs.Write(strToBytes, 0, strToBytes.Length);
            cs.FlushFinalBlock();

            ms.Position = 0;
            byte[] decryptedBytes = new byte[ms.Length];
            ms.Read(decryptedBytes, 0, decryptedBytes.Length);

            cs.Close();
            ms.Close();

            string decryptedPassword = encoder.GetString(decryptedBytes);
            return decryptedPassword;
        }

        public static string SecureURL(string unsafeURL)
        {
            string safeURL = unsafeURL.Replace("http:", "https:");
            return safeURL;
        }
    }
}
