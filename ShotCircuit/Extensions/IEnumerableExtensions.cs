using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShotCircuit.Extensions
{
    // IEnumerable は　GetEnumerator() を持ち foreach を回すだけ。
    public static class IEnumerableExtensions
    {

        public static IEnumerable<T> OrEmpty<T>(this IEnumerable<T>? o)
        {
            return o ?? Enumerable.Empty<T>();
        }
    }
}
