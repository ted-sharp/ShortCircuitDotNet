using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCircuit.Extensions
{
    public static class DateTimeExtensions
    {
        public static int ToAge(this DateTime o)
        {
            throw new NotImplementedException();
        }

        public static int ToAgeAt(this DateTime o, DateTime at)
        {
            throw new NotImplementedException();
        }

        public static bool IsBetween(this DateTime o, DateTime startInclude, DateTime endExclude)
        {
            throw new NotImplementedException();
        }
        
        // 月末を取得するのもよく使うかも
    }
}
