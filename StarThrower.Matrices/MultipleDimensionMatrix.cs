// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StarThrower.Matrices
{
    /// <summary>
    /// One level of a multi-dimension <see cref="Matrix{TIndex, TValue}"/>: an outer dimension keyed
    /// by index values, each mapped to a nested <see cref="CompositeMatrix{TIndex, TValue}"/> representing
    /// the remaining, lower-order dimensions.
    /// </summary>
    /// <remarks>
    /// Index arrays passed to this class's members are peeled from the end: the last element
    /// addresses this level's own dimension, and the remaining elements (in their original order)
    /// are passed down to the nested matrix for that key. The nesting therefore reduces by one
    /// dimension per level until a <see cref="OneDimensionMatrix{TIndex, TValue}"/> is reached.
    /// </remarks>
    internal sealed class MultipleDimensionMatrix<TIndex, TValue> : CompositeMatrix<TIndex, TValue> where TIndex : notnull
    {
        /// <summary>
        /// Maps each index key in this level's dimension to the nested matrix representing the
        /// remaining, lower-order dimensions for that key.
        /// </summary>
        public Dictionary<TIndex, CompositeMatrix<TIndex, TValue>> _values;

        /// <summary>The total number of dimensions remaining at and below this level, used to validate the length of incoming index arrays.</summary>
        private readonly int _dimensionCount;

        /// <summary>
        /// Gets or sets the value identified by an index key per remaining dimension. The last
        /// element of <paramref name="indexes"/> addresses this level; the rest are delegated to
        /// the nested matrix for that key.
        /// </summary>
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

        /// <summary>
        /// Resolves the index key at each remaining dimension corresponding to the given ordinal
        /// positions. The last element of <paramref name="indexes"/> addresses this level; the
        /// rest are delegated to the nested matrix for the resolved key.
        /// </summary>
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

        /// <summary>
        /// Gets the value identified by an ordinal position per remaining dimension. The last
        /// element of <paramref name="indexes"/> addresses this level; the rest are delegated to
        /// the nested matrix for the resolved key.
        /// </summary>
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

        /// <summary>
        /// Sets the value identified by an ordinal position per remaining dimension. The last
        /// element of <paramref name="indexes"/> addresses this level; the rest are delegated to
        /// the nested matrix for the resolved key.
        /// </summary>
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

        /// <summary>
        /// Initializes a new level of nested dimensions from the given per-dimension index
        /// collections, recursively building a nested <see cref="MultipleDimensionMatrix{TIndex, TValue}"/>
        /// or <see cref="OneDimensionMatrix{TIndex, TValue}"/> for each key in this level's dimension.
        /// </summary>
        /// <remarks>
        /// The outer dictionary at this level is keyed by the last element of <paramref name="indexes"/>;
        /// the remaining elements, in their original order, are passed down to build the nested matrix
        /// for each key.
        /// </remarks>
        public MultipleDimensionMatrix(params IEnumerable<TIndex>[] indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);
            if (indexes.Length < 2) throw new InvalidOperationException("MultipleDimensionMatrix must contain at least two values in its indices list");

            _dimensionCount = indexes.Length;

            if (indexes.Length > 2)
            {
                _values = new Dictionary<TIndex, CompositeMatrix<TIndex, TValue>>();
                foreach (TIndex i in indexes[indexes.Length - 1])
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
