using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCircuit.Extensions
{
    // https://gist.github.com/ufcpp/2b3e1a5821169f6b21ded175ad05c752
    public static class IReadOnlyListExtensions
    {
        public struct IndexedListEnumerable<T> : IEnumerable<(T item, int index)>
        {
            private IReadOnlyList<T> _list;

            public IndexedListEnumerable(IReadOnlyList<T> list)
            {
                this._list = list;
            }

            public IndexedListEnumerator<T> GetEnumerator() => new(this._list);

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

            IEnumerator<(T item, int index)> IEnumerable<(T item, int index)>.GetEnumerator() => this.GetEnumerator();
        }

        public struct IndexedListEnumerator<T> : IEnumerator<(T item, int index)>
        {
            int _i;
            IReadOnlyList<T> _list;

            public (T item, int index) Current => (this._list[this._i], this._i);

            internal IndexedListEnumerator(IReadOnlyList<T> list)
            {
                this._i = -1;
                this._list = list;
            }

            public bool MoveNext()
            {
                this._i++;
                return this._i < this._list.Count;
            }

            object IEnumerator.Current => this.Current;

            public void Dispose() { }

            public void Reset() { throw new NotImplementedException(); }
        }

        public static IndexedListEnumerable<T> Indexed<T>(this IReadOnlyList<T> o)
        {
            if (o == null) throw new ArgumentNullException(nameof(o));

            return new IndexedListEnumerable<T>(o);
        }

        // usage
        //foreach (var (item, index) in items.Indexed()) { }
    }
}
