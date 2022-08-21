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
    }
}
