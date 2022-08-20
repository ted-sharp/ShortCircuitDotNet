using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShortCircuit.Extensions.StringExtensionsToDateTime
{
    public static class StringExtensions
    {
        #region DateTime

        public static bool TryToDateTime(this String o, out DateTime result)
        {
            throw new NotImplementedException();
        }

        public static bool IsDateTime(this String o)
        {
            return o.TryToDateTime(out _);
        }

        public static DateTime? ToDateTime(this String o)
        {
            return o.TryToDateTime(out var result) ? result : null;
        }

        #endregion DateTime

        public static DateOnly ToDateOnly(this String o)
        {
            throw new NotImplementedException();
        }

        public static TimeOnly ToTimeOnly(this String o)
        {
            throw new NotImplementedException();
        }
    }
}
