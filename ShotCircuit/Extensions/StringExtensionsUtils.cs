using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCircuit.Extensions
{
    public static class StringExtensionsUtils
    {
        public static string Left(this string o, int length)
        {
            var result = (o != null && o.Length > length) ? o[..length] : o;
            return result ?? "";
        }

        public static string Right(this string o, int length)
        {
            var result = (o != null && o.Length > length) ? o[^length..] : o;
            return result ?? "";
        }
    }
}
