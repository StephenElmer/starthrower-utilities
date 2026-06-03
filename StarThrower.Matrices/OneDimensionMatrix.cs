/***********************************************************************************
    StarThrower Utilities / Matrices
    Copyright (C) 2005-2026  Stephen Elmer

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StarThrower.Matrices
{
    internal sealed class OneDimensionMatrix<TIndex, TValue> : CompositeMatrix<TIndex, TValue> where TIndex : notnull
    {
        public Dictionary<TIndex, TValue> _values;

        public override TValue this[params TIndex[] indexes]
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

        public override TValue GetItemAt(params int[] indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);
            if (indexes.Length != 1) throw new InvalidOperationException("indexer for OneDimensionMatrix type expects indices with only a single value.");
            ArgumentOutOfRangeException.ThrowIfNegative(indexes[0]);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(indexes[0], _values.Count);

            TIndex key = _values.Keys.ElementAt(indexes[0]);
            return _values[key];
        }

        public override void SetItemAt(TValue value, params int[] indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);
            ArgumentOutOfRangeException.ThrowIfNegative(indexes[0]);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(indexes[0], _values.Count);

            TIndex key = _values.Keys.ElementAt(indexes[0]);
            _values[key] = value;
        }

        public OneDimensionMatrix(IEnumerable<TIndex> indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);
            if (!indexes.Any()) throw new InvalidOperationException("OneDimensionMatrix must contain at least one value in its indices list");

            _values = new Dictionary<TIndex, TValue>();
            foreach (TIndex i in indexes)
            {
                _values.Add(i, default(TValue));
            }
        }
    }
}
