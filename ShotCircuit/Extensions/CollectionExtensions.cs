using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCircuit.Extensions
{
    /// <summary>
    /// <see cref="ICollection{T}"/> は要素のカウント、追加、削除を定義しています。
    /// <see cref="IEnumerable{T}"/> を継承しています。
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// null または空か判別します。
        /// </summary>
        /// <remarks>
        /// <see cref="IEnumerable{T}"/> では LINQ の Any() で評価されるため、より低速です。
        /// </remarks>
        public static bool IsNullOrEmpty<T>(this ICollection<T>? o) => (o == null) || (o.Count == 0);

        /// <summary>
        /// 複数の要素を追加します。
        /// </summary>
        public static ICollection<T> AddRange<T>(this ICollection<T> o, ICollection<T> items)
        {
            items.ForEarch(x => o.Add(x));
            return o;
        }
    }
}
