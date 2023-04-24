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

        // how to encrypt using AES: https://www.c-sharpcorner.com/article/encryption-and-decryption-using-a-symmetric-key-in-c-sharp/
        public static string Encrypt(string password)
        {
            byte[] strToByte; // a byte array for turn the password string into later

            // AES class allows for creating an encryptor and storing a key and vector
            using (Aes aes = Aes.Create())
            {
                // store the generated key and vector
                aes.Key = key;
                aes.IV = vector;

                // create an encryptor using the AES class in a CryptoTransformer interface
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                // create a stream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // create a crypto stream
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        // write the crypto stream to a streamwriter
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(password);
                        }

                        // turn the memory stream into a byte array
                        strToByte = memoryStream.ToArray();
                    }
                }
            }
            // return as a encrypted base 64 string
            return Convert.ToBase64String(strToByte);
        }

        // how to decrypt using AES: https://www.c-sharpcorner.com/article/encryption-and-decryption-using-a-symmetric-key-in-c-sharp/
        public static string Decrypt(string encryptedPassword)
        {
            // convert an ecrypted string into a bute array
            byte[] byteToStr = Convert.FromBase64String(encryptedPassword);

            // use the AES class
            using (Aes aes = Aes.Create())
            {
                // store the key and vector
                aes.Key = key;
                aes.IV = vector;

                // decrpyt using the AES Create Decryptor method
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                // create a memory stream
                using (MemoryStream memoryStream = new MemoryStream(byteToStr))
                {
                    // create a crypto stream
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        // read the string to the end and return the decrypted password
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static string SecureURL(string unsafeURL)
        {
            string safeURL = unsafeURL.Replace("http:", "https:");
            return safeURL;
        }
    }
}
