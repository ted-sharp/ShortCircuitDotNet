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
        public static bool AddRange<T>(this ICollection<T> o)
        {
            throw new NotImplementedException();
        }

    }
}
