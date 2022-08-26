using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCircuit.Extensions
{
    // IEnumerable は　GetEnumerator() を持ち foreach を回すだけ。
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T>? o)
        {
            if (o == null)
            {
                return true;
            }

            if (o is ICollection<T> collection)
            {
                return collection.IsNullOrEmpty();
            }

            return (o == null) || (!o.Any());
        }

        public static IEnumerable<T> OrEmpty<T>(this IEnumerable<T>? o)
        {
            return o ?? Enumerable.Empty<T>();
        }

        public static IEnumerable<T> ForEarch<T>(this IEnumerable<T>? o, Action<T> action)
        {
            foreach (var item in o)
            {
                action(item);
                //action.Invoke(item);
            }

            return o;
        }

        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T>? o, int length)
        {
            throw new NotImplementedException();
        }

        public static bool IsSingle<T>(this IEnumerable<T> o)
        {
            if (o == null)
            {
                return false;
            }

            using var enumerator = o.GetEnumerator();
            return enumerator.MoveNext() && !enumerator.MoveNext();
        }
    }
}
