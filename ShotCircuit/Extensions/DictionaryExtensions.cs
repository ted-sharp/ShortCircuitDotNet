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
        /// TValue から TKey を探します。
        /// TKey 順に探し、最初に見つかったものを返します。
        /// </summary>
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

        /// <summary>
        /// TValue から TKey を取得します。
        /// TKey が存在しない場合は default を返します。
        /// </summary>
        public static TKey? GetKey<TKey, TValue>(
            this IDictionary<TKey, TValue> o,
            TValue value)
            where TValue : IEquatable<TValue>
        {
            return o.TryGetKey(value, out var key) ? key : default;
        }

        /// <summary>
        /// TKey から TValue を取得します。
        /// TKey が存在しない場合は default を返します。
        /// </summary>
        public static TValue? GetValue<TKey, TValue>(
            this IDictionary<TKey, TValue> o,
            TKey key)
        {
            return o.TryGetValue(key, out var value) ? value : default;
        }

        /// <summary>
        /// TKey と TValue の追加を行います。
        /// すでに TKey が存在する場合は TValue で更新します。
        /// </summary>
        public static void AddOrUpdate<TKey, TValue>(
            this IDictionary<TKey, TValue> o,
            TKey key,
            TValue value)
        {
            if (!o.TryAdd(key, value))
            {
                o[key] = value;
            }
        }

        /// <summary>
        /// 条件に当てはまるとき、TKey と TValue の追加を行います。
        /// すでに TKey が存在する場合は TValue で更新します。
        /// </summary>
        public static bool TryAddIf<TKey, TValue>(
            this IDictionary<TKey, TValue> o,
            bool condition,
            TKey key,
            TValue value)
        {
            if (condition)
            {
                o.AddOrUpdate(key, value);
                return true;
            }
            return false;
        }

        /// <summary>
        /// value があるとき、TKey と TValue の追加を行います。
        /// すでに TKey が存在する場合は TValue で更新します。
        /// </summary>
        public static bool TryAddAny<TKey>(
            this IDictionary<TKey, string> o,
            TKey key,
            string value)
        {
            return o.TryAddIf(!value.IsNullOrEmpty(), key, value);
        }
    }
}
