using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCircuit.Extensions
{
    /// <summary>
    /// <see cref="IEnumerable{T}"/> は GetEnumerator() を定義して、foreach ループに使用できます。
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// null または空か判別します。
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T>? o)
        {
            if (o == null)
            {
                return true;
            }

            // TODO: あったほうがよいか？
            if (o is ICollection<T> collection)
            {
                return collection.IsNullOrEmpty();
            }

            // TODO: !Any()とどちらがよいか？ 
            using var enumerator = o.GetEnumerator();
            return !enumerator.MoveNext();
        }

        /// <summary>
        /// 要素数がひとつか判別します。
        /// </summary>
        public static bool IsSingle<T>(this IEnumerable<T> o)
        {
            if (o is ICollection<T> collection)
            {
                return collection.Count == 1;
            }

            using var enumerator = o.GetEnumerator();
            return enumerator.MoveNext() && !enumerator.MoveNext();
        }

        /// <summary>
        /// null であれば空を返します。
        /// </summary>
        /// <example>
        /// null を想定していない箇所で例外を回避するために使用できます。
        /// <code>
        /// foreach (var item in items.OrEmpty())
        /// </code>
        /// </example>
        public static IEnumerable<T> OrEmpty<T>(this IEnumerable<T>? o)
            => o ?? Enumerable.Empty<T>();

        /// <summary>
        /// ページに分割して抜き出します。
        /// </summary>
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> o, int pageSize, int pageIndex)
            => o.Skip(pageSize * (pageIndex - 1)).Take(pageSize);

        /// <summary>
        /// それぞれの要素で <see cref="Action{T}"/> を実行します。
        /// </summary>
        public static void ForEarch<T>(this IEnumerable<T> o, Action<T> action)
        {
            foreach (var item in o)
            {
                action(item);
            }
        }

        ///// <summary>
        ///// 要素を指定された大きさ毎に分割します。
        ///// </summary>
        ///// <example>
        ///// { 1, 2, 3, 4, 5 } ⇒ { 1, 2 }, { 3, 4 }, { 5 }
        ///// </example>
        //// https://blog.xin9le.net/entry/2013/03/03/123246
        //public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> o, int size)
        //{
        //    var result = new List<T>(size);
        //    foreach (var item in o)
        //    {
        //        result.Add(item);
        //        if (result.Count == size)
        //        {
        //            yield return result;
        //            result = new List<T>(size);
        //        }
        //    }
        //    if (result.Count != 0)
        //    {
        //        yield return result.ToArray();
        //    }
        //}

    }
}
