using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ExMan.WebApi.Providers
{
    internal static class PasswordHelper
    {

        private const string PASSWORD_SALT = "ExMan1625857AmSu";
        private const string PASSWORD_PHRASE = "KharchaManage@0104";
        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes(PASSWORD_SALT);
        private const int ENCRYPTION_KEYSIZE = 256;

        internal static string Decrypt(string cipherText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(PASSWORD_PHRASE, null))
            {
                byte[] keyBytes = password.GetBytes(ENCRYPTION_KEYSIZE / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }
    }
}