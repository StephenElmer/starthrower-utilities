using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StarThrower.Matrices
{
    internal class OneDimensionMatrix<TIndex, TValue> : CompositeMatrix<TIndex, TValue>
    {
        public Dictionary<TIndex, TValue> _values;

        public override TValue this[params TIndex[] indexes]
        {
            get
            {
                ArgumentNullException.ThrowIfNull(indexes);
                if (indexes.Length != 1) throw new InvalidOperationException("indexer for OneDimensionMatrix type expects indices with only a single value.");
                if (!_values.ContainsKey(indexes[0])) throw new InvalidOperationException("OneDimensionMatrix does not have an index associated with " + indexes[0].ToString());
                return _values[indexes[0]];
            }
            set
            {
                ArgumentNullException.ThrowIfNull(indexes);
                if (indexes.Length != 1) throw new InvalidOperationException("indexer for OneDimensionMatrix type expects indices with only a single value.");
                if (!_values.ContainsKey(indexes[0])) throw new InvalidOperationException("OneDimensionMatrix does not have an index associated with " + indexes[0].ToString());
                _values[indexes[0]] = value;
            }
        }

        public override Collection<TIndex> GetIndexesAt(params int[] indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);
            if (indexes.Length != 1) throw new InvalidOperationException("indexer for OneDimensionMatrix type expects indices with only a single value.");
            if (indexes[0] < 0) throw new IndexOutOfRangeException();
            if (indexes[0] >= _values.Count) throw new IndexOutOfRangeException();

            TIndex key = _values.Keys.ElementAt(indexes[0]);

            Collection<TIndex> result = new Collection<TIndex>();
            result.Add(key);
            return result;
        }

        public override TValue GetItemAt(params int[] indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);
            if (indexes.Length != 1) throw new InvalidOperationException("indexer for OneDimensionMatrix type expects indices with only a single value.");
            if (indexes[0] < 0) throw new IndexOutOfRangeException();
            if (indexes[0] >= _values.Count) throw new IndexOutOfRangeException();

            TIndex key = _values.Keys.ElementAt(indexes[0]);
            return _values[key];
        }

        public override void SetItemAt(TValue value, params int[] indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);
            if (indexes.Length != 1) throw new InvalidOperationException("indexer for OneDimensionMatrix type expects indices with only a single value.");
            if (indexes[0] < 0) throw new IndexOutOfRangeException();
            if (indexes[0] >= _values.Count) throw new IndexOutOfRangeException();

            TIndex key = _values.Keys.ElementAt(indexes[0]);
            _values[key] = value;
        }

        public OneDimensionMatrix(IEnumerable<TIndex> indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);
            if (indexes.Count() < 1) throw new InvalidOperationException("OneDimensionMatrix must contain at least one value in its indices list");

            _values = new Dictionary<TIndex, TValue>();
            foreach (TIndex i in indexes)
            {
                _values.Add(i, default(TValue));
            }
        }
    }
}
