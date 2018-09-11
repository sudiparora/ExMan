using System;
using System.Runtime.InteropServices;
using System.Security;

namespace PerFin.Desktop.Core.Helpers
{
    public static class ExtensionMethods
    {
        public static string ConvertSecureStringToString(this SecureString secureString)
        {
            IntPtr passwordBSTR = default(IntPtr);
            string password = string.Empty;
            try
            {
                passwordBSTR = Marshal.SecureStringToBSTR(secureString);
                password = Marshal.PtrToStringBSTR(passwordBSTR);
            }
            catch
            {
                password = string.Empty;
            }
            return password;
        }
    }
}
