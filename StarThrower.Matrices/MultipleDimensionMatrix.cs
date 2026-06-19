// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StarThrower.Matrices
{
    internal sealed class MultipleDimensionMatrix<TIndex, TValue> : CompositeMatrix<TIndex, TValue> where TIndex : notnull
    {
        public Dictionary<TIndex, CompositeMatrix<TIndex, TValue>> _values;
        private readonly int _dimensionCount;

        public override TValue? this[params TIndex[] indexes]
        {
            get
            {
                ArgumentNullException.ThrowIfNull(indexes);
                if (indexes.Length != _dimensionCount) throw new InvalidOperationException($"indexer for MultipleDimensionMatrix type expects exactly {_dimensionCount} index value(s) but received {indexes.Length}.");

                TIndex[] idx = new TIndex[indexes.Length - 1];
                for (int i = 0; i < indexes.Length - 1; i++)
                {
                    idx[i] = indexes[i];
                }

                TIndex key = indexes[indexes.Length - 1];
                if (!_values.TryGetValue(key, out CompositeMatrix<TIndex, TValue>? matrix)) throw new InvalidOperationException("MultipleDimensionMatrix does not have an index associated with " + key.ToString());
                return matrix[idx];
            }
            set
            {
                ArgumentNullException.ThrowIfNull(indexes);
                if (indexes.Length != _dimensionCount) throw new InvalidOperationException($"indexer for MultipleDimensionMatrix type expects exactly {_dimensionCount} index value(s) but received {indexes.Length}.");

                TIndex[] idx = new TIndex[indexes.Length - 1];
                for (int i = 0; i < indexes.Length - 1; i++)
                {
                    idx[i] = indexes[i];
                }

                TIndex key = indexes[indexes.Length - 1];
                if (!_values.TryGetValue(key, out CompositeMatrix<TIndex, TValue>? matrix)) throw new InvalidOperationException("MultipleDimensionMatrix does not have an index associated with " + key.ToString());
                matrix[idx] = value;
            }
        }

        public override Collection<TIndex> GetIndexesAt(params int[] indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);
            if (indexes.Length != _dimensionCount) throw new InvalidOperationException($"GetIndexesAt for MultipleDimensionMatrix type expects exactly {_dimensionCount} index value(s) but received {indexes.Length}.");
            ArgumentOutOfRangeException.ThrowIfNegative(indexes[indexes.Length - 1]);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(indexes[indexes.Length - 1], _values.Count);

            int[] idx = new int[indexes.Length - 1];
            for (int i = 0; i < indexes.Length - 1; i++)
            {
                idx[i] = indexes[i];
            }
            TIndex key = _values.Keys.ElementAt(indexes[indexes.Length - 1]);

            Collection<TIndex> result = _values[key].GetIndexesAt(idx);
            result.Add(key);
            return result;
        }

        public override TValue? GetItemAt(params int[] indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);
            if (indexes.Length != _dimensionCount) throw new InvalidOperationException($"GetItemAt for MultipleDimensionMatrix type expects exactly {_dimensionCount} index value(s) but received {indexes.Length}.");
            ArgumentOutOfRangeException.ThrowIfNegative(indexes[indexes.Length - 1]);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(indexes[indexes.Length - 1], _values.Count);

            int[] idx = new int[indexes.Length - 1];
            for (int i = 0; i < indexes.Length - 1; i++)
            {
                idx[i] = indexes[i];
            }
            TIndex key = _values.Keys.ElementAt(indexes[indexes.Length - 1]);
            return _values[key].GetItemAt(idx);
        }

        public override void SetItemAt(TValue? value, params int[] indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);
            if (indexes.Length != _dimensionCount) throw new InvalidOperationException($"SetItemAt for MultipleDimensionMatrix type expects exactly {_dimensionCount} index value(s) but received {indexes.Length}.");
            ArgumentOutOfRangeException.ThrowIfNegative(indexes[indexes.Length - 1]);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(indexes[indexes.Length - 1], _values.Count);

            int[] idx = new int[indexes.Length - 1];
            for (int i = 0; i < indexes.Length - 1; i++)
            {
                idx[i] = indexes[i];
            }
            TIndex key = _values.Keys.ElementAt(indexes[indexes.Length - 1]);
            _values[key].SetItemAt(value, idx);
        }

        public MultipleDimensionMatrix(params IEnumerable<TIndex>[] indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);
            if (indexes.Length < 2) throw new InvalidOperationException("MultipleDimensionMatrix must contain at least two values in its indices list");

            _dimensionCount = indexes.Length;

            if (indexes.Length > 2)
            {
                _values = new Dictionary<TIndex, CompositeMatrix<TIndex, TValue>>();
                foreach (TIndex i in indexes[2])
                {
                    IEnumerable<TIndex>[] idx = new IEnumerable<TIndex>[indexes.Length - 1];
                    for (int n = 0; n < indexes.Length - 1; n++)
                    {
                        idx[n] = indexes[n];
                    }
                    _values.Add(i, new MultipleDimensionMatrix<TIndex, TValue>(idx));
                }
            }
            else
            {
                _values = new Dictionary<TIndex, CompositeMatrix<TIndex, TValue>>();
                foreach (TIndex i in indexes[1])
                {
                    _values.Add(i, new OneDimensionMatrix<TIndex, TValue>(indexes[0]));
                }
            }
        }
    }
}
