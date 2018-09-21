using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace FinCare.Core
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
