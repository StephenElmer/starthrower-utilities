// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System.Collections.ObjectModel;

namespace StarThrower.Matrices
{
    /// <summary>
    /// Base class for a sparse, arbitrary-dimension matrix in which each dimension is keyed by
    /// arbitrary, caller-supplied index values rather than by a fixed numeric range.
    /// </summary>
    /// <typeparam name="TIndex">
    /// The type used to key each dimension (e.g. a row/column label). Must be non-null, since
    /// index values are used as dictionary keys internally.
    /// </typeparam>
    /// <typeparam name="TValue">The type of value stored at each cell of the matrix.</typeparam>
    /// <remarks>
    /// Implementations expose two parallel ways to address a cell: the indexer, which addresses a
    /// cell by its actual <typeparamref name="TIndex"/> key in each dimension, and the
    /// <c>*At</c> methods, which address a cell by its ordinal position within each dimension
    /// instead of by key value.
    /// </remarks>
    public abstract class CompositeMatrix<TIndex, TValue> where TIndex : notnull
    {
        /// <summary>
        /// Gets or sets the value at the cell identified by the given index key in each dimension.
        /// </summary>
        /// <param name="indexes">
        /// The index key for each dimension, in the same order the dimensions were defined in.
        /// </param>
        /// <returns>The value stored at the specified cell.</returns>
        public abstract TValue? this[params TIndex[] indexes] { get; set; }

        /// <summary>
        /// Resolves the index key in each dimension corresponding to the given ordinal positions.
        /// </summary>
        /// <param name="indexes">The ordinal position within each dimension, in the same order the dimensions were defined in.</param>
        /// <returns>The index key for each dimension at the specified positions, in the same dimension order as <paramref name="indexes"/>.</returns>
        public abstract Collection<TIndex> GetIndexesAt(params int[] indexes);

        /// <summary>
        /// Gets the value at the cell identified by the given ordinal position in each dimension.
        /// </summary>
        /// <param name="indexes">The ordinal position within each dimension, in the same order the dimensions were defined in.</param>
        /// <returns>The value stored at the specified cell.</returns>
        public abstract TValue? GetItemAt(params int[] indexes);

        /// <summary>
        /// Sets the value at the cell identified by the given ordinal position in each dimension.
        /// </summary>
        /// <param name="value">The value to store at the specified cell.</param>
        /// <param name="indexes">The ordinal position within each dimension, in the same order the dimensions were defined in.</param>
        public abstract void SetItemAt(TValue? value, params int[] indexes);
    }
}
