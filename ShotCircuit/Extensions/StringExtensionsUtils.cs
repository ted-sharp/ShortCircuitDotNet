﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCircuit.Extensions
{
    public static class StringExtensionsUtils
    {
        public static bool IsNullOrEmpty(this string o)
        {
            if (o == null)
            {
                return true;
            }

            return o.Length == 0;
        }

        public static string Or(this string? o, string value)
        {
            return o.IsNullOrEmpty() ? value : o;
        }

        public static string Left(this string o, int length)
        {
            var result = (o != null && o.Length > length) ? o[..length] : o;
            return result ?? "";
        }

        public static string Right(this string o, int length)
        {
            var result = (o != null && o.Length > length) ? o[^length..] : o;
            return result ?? "";
        }

        // Humanizerっぽく
        public static string Truncate(this string o, int length)
        {
            throw new NotImplementedException();
        }

        public static string Mask(this string o, int start, int length)
        {
            throw new NotImplementedException();
        }
    }
}