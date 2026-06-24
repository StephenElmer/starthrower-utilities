// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StarThrower.Matrices
{
    /// <summary>
    /// A sparse, arbitrary-dimension matrix keyed by caller-supplied index values rather than by
    /// a fixed numeric range. This is the public entry point for the <see cref="CompositeMatrix{TIndex, TValue}"/>
    /// hierarchy; it selects and delegates to a one-dimensional or multi-dimensional implementation
    /// based on how many dimensions are supplied to the constructor.
    /// </summary>
    /// <typeparam name="TIndex">
    /// The type used to key each dimension (e.g. a row/column label). Must be non-null, since
    /// index values are used as dictionary keys internally.
    /// </typeparam>
    /// <typeparam name="TValue">The type of value stored at each cell of the matrix.</typeparam>
    public class Matrix<TIndex, TValue> : CompositeMatrix<TIndex, TValue> where TIndex : notnull
    {
        /// <summary>
        /// The underlying one-dimensional or multi-dimensional implementation selected by the constructor,
        /// to which all member access is delegated.
        /// </summary>
        private CompositeMatrix<TIndex, TValue> _matrix;

        /// <summary>
        /// Gets or sets the value at the cell identified by the given index key in each dimension.
        /// </summary>
        /// <param name="indexes">
        /// The index key for each dimension, in the same order the dimensions were defined in
        /// the constructor.
        /// </param>
        /// <returns>The value stored at the specified cell.</returns>
        /// <exception cref="ArgumentNullException">Thrown if indexes is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the number of indexes does not match the number of dimensions, or if any index key does not exist in its dimension.</exception>
        public override TValue? this[params TIndex[] indexes]
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

        /// <summary>
        /// Resolves the index key in each dimension corresponding to the given ordinal positions.
        /// </summary>
        /// <param name="indexes">The ordinal position within each dimension, in the same order the dimensions were defined in the constructor.</param>
        /// <returns>The index key for each dimension at the specified positions, in the same dimension order as <paramref name="indexes"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if indexes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if any position is negative or is not less than the number of keys in its dimension.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the number of indexes does not match the number of dimensions.</exception>
        public override Collection<TIndex> GetIndexesAt(params int[] indexes)
        {
            return _matrix.GetIndexesAt(indexes);
        }

        /// <summary>
        /// Gets the value at the cell identified by the given ordinal position in each dimension.
        /// </summary>
        /// <param name="indexes">The ordinal position within each dimension, in the same order the dimensions were defined in the constructor.</param>
        /// <returns>The value stored at the specified cell.</returns>
        /// <exception cref="ArgumentNullException">Thrown if indexes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if any position is negative or is not less than the number of keys in its dimension.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the number of indexes does not match the number of dimensions.</exception>
        public override TValue? GetItemAt(params int[] indexes)
        {
            return _matrix.GetItemAt(indexes);
        }

        /// <summary>
        /// Sets the value at the cell identified by the given ordinal position in each dimension.
        /// </summary>
        /// <param name="value">The value to store at the specified cell.</param>
        /// <param name="indexes">The ordinal position within each dimension, in the same order the dimensions were defined in the constructor.</param>
        /// <exception cref="ArgumentNullException">Thrown if indexes is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if any position is negative or is not less than the number of keys in its dimension.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the number of indexes does not match the number of dimensions.</exception>
        public override void SetItemAt(TValue? value, params int[] indexes)
        {
            _matrix.SetItemAt(value, indexes);
        }

        /// <summary>
        /// Initializes a new matrix with one dimension per supplied index collection, where each
        /// collection enumerates the index keys that make up that dimension.
        /// </summary>
        /// <param name="indexes">
        /// One collection of index keys per dimension. A single collection produces a
        /// one-dimensional matrix; two or more collections produce a multi-dimensional matrix.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown if indexes is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if indexes is empty.</exception>
        public Matrix(params IEnumerable<TIndex>[] indexes)
        {
            ArgumentNullException.ThrowIfNull(indexes);

            int count = indexes.Length;
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
