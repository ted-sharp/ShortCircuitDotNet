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
        public static T DeepClone<T>(this T o)
            where T : ISerializable
        {
            using var stream = new MemoryStream();
            // 非推奨なので、別のフォーマッタが必要、ZeroFomatterとか？
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, o);
            stream.Position = 0;
            return (T)formatter.Deserialize(stream);
        }

        public static bool In<T>(this T? o, params T[] items) => (o != null) && items.Contains(o);

        public static bool In<T>(this T? o, IEnumerable<T> items) => (o != null) && items.Contains(o);

        public static bool In<T>(this T? o, HashSet<T> vals) => (o != null) && vals.Contains(o);

        public static bool In(this char? o, string s) => (o != null) && s.IndexOf(o.Value) > -1;

        public static T Or<T>(this T? o, T value) => (o == null) ? value : o;

    }
}
