﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShotCircuit.Extensions
{
    public static class IDictionaryExtensions
    {
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
    }
}
