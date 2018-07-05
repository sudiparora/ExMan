using System;
using System.Collections.Generic;
using System.Text;

namespace ExMan.DataAccess.Base
{
    public class CommonBase
    {
        public static DateTime DateTime_NullValue = DateTime.MinValue;
        public static Guid Guid_NullValue = Guid.Empty;
        public static int Int_NullValue = int.MinValue;
        public static float Float_NullValue = float.MinValue;
        public static decimal Decimal_NullValue = decimal.MinValue;
        public static string String_NullValue = null;
        public static long Long_NullValue = long.MaxValue;
        public static bool Bool_NullValue = false;
    }
}
