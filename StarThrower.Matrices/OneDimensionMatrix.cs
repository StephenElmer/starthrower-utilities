// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StarThrower.Matrices
{
    /// <summary>
    /// The innermost dimension of a <see cref="Matrix{TIndex, TValue}"/>: a single dimension of
    /// index-keyed values with no further nesting.
    /// </summary>
    internal sealed class OneDimensionMatrix<TIndex, TValue> : CompositeMatrix<TIndex, TValue> where TIndex : notnull
    {
        /// <summary>
        /// Maps each index key in this dimension to its stored value. Entries are created (with
        /// a default value) for every key passed to the constructor and never added to or removed
        /// from afterward, so the key set is fixed for the lifetime of the instance.
        /// </summary>
        public Dictionary<TIndex, TValue?> _values;

        /// <summary>
        /// Gets or sets the value associated with a single index key. <paramref name="indexes"/> must
        /// contain exactly one element.
        /// </summary>
        public override TValue? this[params TIndex[] indexes]
        {
            get
            {
                ArgumentNullException.ThrowIfNull(indexes);
                if (indexes.Length != 1) throw new InvalidOperationException("indexer for OneDimensionMatrix type expects indices with only a single value.");

                if (!_values.TryGetValue(indexes[0], out TValue? value)) throw new InvalidOperationException("OneDimensionMatrix does not have an index associated with " + indexes[0].ToString());
                return value;
                // _values.TryGetValue(indexes[0], out TValue result);
                // return result;
            }
            set
            {
                ArgumentNullException.ThrowIfNull(indexes);
                if (indexes.Length != 1) throw new InvalidOperationException("indexer for OneDimensionMatrix type expects indices with only a single value.");
                if (!_values.ContainsKey(indexes[0])) throw new InvalidOperationException("OneDimensionMatrix does not have an index associated with " + indexes[0].ToString());
                _values[indexes[0]] = value;
            }
        }

        /// <summary>
        /// Resolves the index key at the given ordinal position within this dimension's key set.
        /// <paramref name="indexes"/> must contain exactly one element.
        /// </summary>
        public override Collection<TIndex> GetIndexesAt(params int[] indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);
            if (indexes.Length != 1) throw new InvalidOperationException("indexer for OneDimensionMatrix type expects indices with only a single value.");
            ArgumentOutOfRangeException.ThrowIfNegative(indexes[0]);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(indexes[0], _values.Count);

            TIndex key = _values.Keys.ElementAt(indexes[0]);

            Collection<TIndex> result = new Collection<TIndex>();
            result.Add(key);
            return result;
        }

        /// <summary>
        /// Gets the value at the given ordinal position within this dimension's key set.
        /// <paramref name="indexes"/> must contain exactly one element.
        /// </summary>
        public override TValue? GetItemAt(params int[] indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);
            if (indexes.Length != 1) throw new InvalidOperationException("indexer for OneDimensionMatrix type expects indices with only a single value.");
            ArgumentOutOfRangeException.ThrowIfNegative(indexes[0]);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(indexes[0], _values.Count);

            TIndex key = _values.Keys.ElementAt(indexes[0]);
            return _values[key];
        }

        /// <summary>
        /// Sets the value at the given ordinal position within this dimension's key set.
        /// <paramref name="indexes"/> must contain exactly one element.
        /// </summary>
        public override void SetItemAt(TValue? value, params int[] indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);
            if (indexes.Length != 1) throw new InvalidOperationException("indexer for OneDimensionMatrix type expects indices with only a single value.");
            ArgumentOutOfRangeException.ThrowIfNegative(indexes[0]);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(indexes[0], _values.Count);

            TIndex key = _values.Keys.ElementAt(indexes[0]);
            _values[key] = value;
        }

        /// <summary>
        /// Initializes a new dimension whose key set is the given index values, each initially
        /// mapped to the default value of <typeparamref name="TValue"/>.
        /// </summary>
        public OneDimensionMatrix(IEnumerable<TIndex> indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);
            if (!indexes.Any()) throw new InvalidOperationException("OneDimensionMatrix must contain at least one value in its indices list");

            _values = new Dictionary<TIndex, TValue?>();
            foreach (TIndex i in indexes)
            {
                _values.Add(i, default);
            }
        }
    }
}
