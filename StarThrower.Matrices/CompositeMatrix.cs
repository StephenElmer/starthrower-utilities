using System;
using System.Collections.ObjectModel;

namespace StarThrower.Matrices
{
    public abstract class CompositeMatrix<TIndex, TValue>
    {
        public abstract TValue this[params TIndex[] indexes] { get; set; }
        public abstract Collection<TIndex> GetIndexesAt(params int[] indexes);
        public abstract TValue GetItemAt(params int[] indexes);
        public abstract void SetItemAt(TValue value, params int[] indexes);
    }
}
