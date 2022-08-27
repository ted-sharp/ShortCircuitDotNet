using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCircuit.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 月初(1日)を返します。
        /// </summary>
        public static DateTime BeginningOfMonth(this DateTime o)
        {
            return new DateTime(o.Year, o.Month, 1);
        }

        /// <summary>
        /// 月末(28-31日)を返します。
        /// </summary>
        public static DateTime EndOfMonth(this DateTime o)
        {
            var date = o.Date;
            return date.AddMonths(1).AddDays(-date.Day);
        }
    }
}
