using ElgrosLib.Factories;
using ElgrosLib.Logs;
using System.Security.Cryptography;
using System.Text;

namespace ElgrosLib.Security
{
    internal class Decryption
    {
        /// <summary>
        /// Returns decrypted string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="decodingPassword"></param>
        /// <returns></returns>
        public string DecryptString(string input, string decodingPassword)
        {
            // Check for null or empty inputs
            if (string.IsNullOrEmpty(input))
            {
                LogFactory.CreateLog(LogTypes.Console, "Input string was null or empty", MessageTypes.Error).WriteLog();
            }
            if (string.IsNullOrEmpty(decodingPassword))
            {
                LogFactory.CreateLog(LogTypes.Console, "Encoding password was null or empty", MessageTypes.Error).WriteLog();
            }

            // input bytes as salt
            byte[] salt = Encoding.UTF8.GetBytes(decodingPassword);
            // Key and vector generator
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(decodingPassword, salt);

            // Create the Aes for decryption
            Aes aes = Aes.Create();
            aes.Key = rfc.GetBytes(32);
            aes.IV = rfc.GetBytes(16);

            // Create streams for decryption
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);

            // Decrypt input as bytes
            byte[] inputBytes = Convert.FromBase64String(input);
            cryptoStream.Write(inputBytes, 0, inputBytes.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();

            // Convert bytes to base64 string
            string result = Encoding.UTF8.GetString(memoryStream.ToArray());
            return result;
        }
    }
}