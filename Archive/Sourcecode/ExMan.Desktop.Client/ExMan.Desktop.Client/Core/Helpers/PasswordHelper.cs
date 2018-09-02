using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Desktop.Client.Core
{
    public static class PasswordHelper
    {

        private const string PASSWORD_SALT = "ExMan1625857AmSu";
        private const string PASSWORD_PHRASE = "KharchaManage@0104";
        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes(PASSWORD_SALT);
        private const int ENCRYPTION_KEYSIZE = 256;

        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(PASSWORD_PHRASE, null))
            {
                byte[] keyBytes = password.GetBytes(ENCRYPTION_KEYSIZE / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                byte[] cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }


    }
}
