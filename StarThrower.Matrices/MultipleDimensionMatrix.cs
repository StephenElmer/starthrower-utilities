using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StarThrower.Matrices
{
    internal class MultipleDimensionMatrix<TIndex, TValue> : CompositeMatrix<TIndex, TValue>
    {
        public Dictionary<TIndex, CompositeMatrix<TIndex, TValue>> _values;

        public override TValue this[params TIndex[] indexes]
        {
            get
            {
                if (indexes == null) throw new ArgumentNullException("indexes");

                //TODO: requires still more validation

                /*
                TIndex[] idx = new TIndex[indexes.Length - 1];
                for (int i = 1; i < indexes.Length; i++)
                {
                    idx[i - 1] = indexes[i];
                }
                return _values[indexes[0]][idx];
                */

                TIndex[] idx = new TIndex[indexes.Length - 1];
                for (int i = 0; i < indexes.Length - 1; i++)
                {
                    idx[i] = indexes[i];
                }
                return _values[indexes[indexes.Length - 1]][idx];
            }
            set
            {
                if (indexes == null) throw new ArgumentNullException("indexes");

                //TODO: requires still more validation

                /*
                TIndex[] idx = new TIndex[indexes.Length - 1];
                for (int i = 1; i < indexes.Length; i++)
                {
                    idx[i - 1] = indexes[i];
                }
                _values[indexes[0]][idx] = value;
                */

                TIndex[] idx = new TIndex[indexes.Length - 1];
                for (int i = 0; i < indexes.Length - 1; i++)
                {
                    idx[i] = indexes[i];
                }
                _values[indexes[indexes.Length - 1]][idx] = value;
            }
        }

        public override Collection<TIndex> GetIndexesAt(params int[] indexes)
        {
            if (indexes == null) throw new ArgumentNullException("indexes");

            //TODO: requires still more validation


            /*
            int[] idx = new int[indexes.Length - 1];
            for (int i = 1; i < indexes.Length; i++)
            {
                idx[i - 1] = indexes[i];
            }
            TIndex key = _values.Keys.ElementAt(indexes[0]);

            Collection<TIndex> result = _values[key].GetIndexesAt(idx);
            result.Insert(0, key);
            return result;
            */



            int[] idx = new int[indexes.Length - 1];
            for (int i = 0; i < indexes.Length - 1; i++)
            {
                idx[i] = indexes[i];
            }
            TIndex key = _values.Keys.ElementAt(indexes[indexes.Length - 1]);

            Collection<TIndex> result = _values[key].GetIndexesAt(idx);
            //result.Insert(0, key);
            result.Add(key);
            return result;
        }

        public override TValue GetItemAt(params int[] indexes)
        {
            if (indexes == null) throw new ArgumentNullException("indexes");

            //TODO: requires still more validation


            /*
            int[] idx = new int[indexes.Length - 1];
            for (int i = 1; i < indexes.Length; i++)
            {
                idx[i - 1] = indexes[i];
            }
            TIndex key = _values.Keys.ElementAt(indexes[0]);
            return _values[key].GetItemAt(idx);
            */


            int[] idx = new int[indexes.Length - 1];
            for (int i = 0; i < indexes.Length - 1; i++)
            {
                idx[i] = indexes[i];
            }
            TIndex key = _values.Keys.ElementAt(indexes[indexes.Length - 1]);
            return _values[key].GetItemAt(idx);
        }

        public override void SetItemAt(TValue value, params int[] indexes)
        {
            if (indexes == null) throw new ArgumentNullException("indexes");

            //TODO: requires still more validation


            /*
            int[] idx = new int[indexes.Length - 1];
            for (int i = 1; i < indexes.Length; i++)
            {
                idx[i - 1] = indexes[i];
            }
            TIndex key = _values.Keys.ElementAt(indexes[0]);
            _values[key].SetItemAt(value, idx);
            */


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
            if (indexes == null) throw new ArgumentNullException("indexes");
            if (indexes.Length < 2) throw new InvalidOperationException("MultipleDimensionMatrix must contain at least two values in its indices list");

            if (indexes.Length > 2)
            {
                /*
                _values = new Dictionary<TIndex, CompositeMatrix<TIndex, TValue>>();
                foreach (TIndex i in indexes[2])
                {
                    IEnumerable<TIndex>[] idx = new IEnumerable<TIndex>[indexes.Length - 1];
                    for (int n = 1; n < indexes.Length; n++)
                    {
                        idx[n - 1] = indexes[n];
                    }
                    _values.Add(i, new MatrixDN<TIndex, TValue>(idx));
                }
                */


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
