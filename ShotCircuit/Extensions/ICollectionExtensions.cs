using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCircuit.Extensions
{
    // ICollectionは要素のカウントや追加削除ができる
    // IEnumerableを含む
    public static class ICollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T>? o)
        {
            return (o == null) || (o.Count == 0);
        }

        public static bool AddRange<T>(this ICollection<T> o)
        {
            throw new NotImplementedException();
        }

    }
}
