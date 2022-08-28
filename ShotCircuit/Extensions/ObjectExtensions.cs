using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShortCircuit.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// キャストを行います。
        /// </summary>
        public static T As<T>(this object o) => (T)o;

        /// <summary>
        /// キャストを行います。
        /// </summary>
        public static T AsOr<T>(this object o, T value) => (o is T t) ? t : value;

        /// <summary>
        /// null であれば代わりの値を返します。
        /// </summary>
        public static T Or<T>(this T? o, T value) => (o == null) ? value : o;

        /// <summary>
        /// null または空文字列であれば代わりの値を返します。
        /// </summary>
        public static string Or(this string? o, string value) => o.IsNullOrEmpty() ? value : o;

        /// <summary>
        /// どれかに該当するか判別します。
        /// </summary>
        public static bool In<T>(this T? o, params T[] items) => (o != null) && items.Contains(o);

        /// <summary>
        /// どれかに該当するか判別します。
        /// </summary>
        public static bool In<T>(this T? o, IEnumerable<T> items) => (o != null) && items.Contains(o);

        /// <summary>
        /// どれかに該当するか判別します。
        /// </summary>
        public static bool In(this char? o, string s) => (o != null) && s.IndexOf(o.Value) > -1;

        /// <summary>
        /// 間にあるか判別します。
        /// </summary>
        public static bool IsBetween<T>(this T o, T min, T max)
            where T : IComparable<T>
        {
            return o.CompareTo(min) >= 0 && o.CompareTo(max) <= 0;
        }

        //public static T DeepClone<T>(this T o)
        //    where T : ISerializable
        //{
        //    using var stream = new MemoryStream();
        //    // 非推奨なので、別のフォーマッタが必要、ZeroFomatterとか？
        //    var formatter = new BinaryFormatter();
        //    formatter.Serialize(stream, o);
        //    stream.Position = 0;
        //    return (T)formatter.Deserialize(stream);
        //}


    }
}
