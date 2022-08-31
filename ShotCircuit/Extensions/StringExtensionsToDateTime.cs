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

        /// <summary>
        /// 文字列を <see cref="DateTime"/> に変換を試みます。
        /// </summary>
        public static bool TryToDateTime(this String o, out DateTime result)
            => DateTime.TryParse(o, out result);

        /// <summary>
        /// 文字列が <see cref="DateTime"/> か判別します。
        /// </summary>
        public static bool IsDateTime(this String o)
            => o.TryToDateTime(out _);

        /// <summary>
        /// 文字列を <see cref="DateTime"/> に変換します。
        /// </summary>
        public static DateTime? ToDateTime(this String o)
            => o.TryToDateTime(out var result) ? result : null;

        #endregion DateTime
    }
}
