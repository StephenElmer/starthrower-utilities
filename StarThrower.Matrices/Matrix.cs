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
