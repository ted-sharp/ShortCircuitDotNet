using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCircuit.Extensions
{
    /// <summary>
    /// <see cref="KeyValuePair{TKey, TValue}"/> の <see cref="ICollection{T}"/> と <see cref="IEnumerable{T}"/> を扱います。
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// TKey から TValue を取得します。
        /// TKey が存在しない場合は default を返します。
        /// </summary>
        public static TValue? GetValue<TKey, TValue>(
            this IDictionary<TKey, TValue> o,
            TKey key)
            => o.TryGetValue(key, out var value) ? value : default;

        /// <summary>
        /// TValue から TKey を探します。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="o"></param>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryGetKey<TKey, TValue>(
            this IDictionary<TKey, TValue> o,
            TValue value,
            [MaybeNullWhen(false)] out TKey result)
            where TValue : IEquatable<TValue>
        {
            foreach (var key in o.Keys)
            {
                if (o[key].Equals(value))
                {
                    result = key;
                    return true;
                }
            }

            result = default;
            return false;
        }

        // TryAdd<string, object> がほしい
        // 
    }
}
