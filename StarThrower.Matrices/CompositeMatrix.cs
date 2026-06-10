// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System.Collections.ObjectModel;

namespace StarThrower.Matrices
{
    public abstract class CompositeMatrix<TIndex, TValue> where TIndex : notnull
    {
        public abstract TValue? this[params TIndex[] indexes] { get; set; }
        public abstract Collection<TIndex> GetIndexesAt(params int[] indexes);
        public abstract TValue? GetItemAt(params int[] indexes);
        public abstract void SetItemAt(TValue? value, params int[] indexes);
    }
}
