using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StarThrower.Matrices
{
    public class Matrix<TIndex, TValue> : CompositeMatrix<TIndex, TValue>
    {
        private CompositeMatrix<TIndex, TValue> _matrix;

        public override TValue this[params TIndex[] indexes]
        {
            get
            {
                ArgumentNullException.ThrowIfNull(indexes);
                return _matrix[indexes];
            }
            set
            {
                ArgumentNullException.ThrowIfNull(indexes);
                _matrix[indexes] = value;
            }
        }

        public override Collection<TIndex> GetIndexesAt(params int[] indexes)
        {
            return _matrix.GetIndexesAt(indexes);
        }

        public override TValue GetItemAt(params int[] indexes)
        {
            return _matrix.GetItemAt(indexes);
        }

        public override void SetItemAt(TValue value, params int[] indexes)
        {
            _matrix.SetItemAt(value, indexes);
        }

        public Matrix(params IEnumerable<TIndex>[] indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);

            int count = indexes.Count();
            if (count == 1)
            {
                _matrix = new OneDimensionMatrix<TIndex, TValue>(indexes[0]);
            }
            else if (count > 1)
            {
                _matrix = new MultipleDimensionMatrix<TIndex, TValue>(indexes);
            }
            else
            {
                throw new InvalidOperationException("MatrixD1 must contain at least one value in its indices list");
            }
        }
    }
}
