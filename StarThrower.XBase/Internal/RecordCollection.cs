// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace StarThrower.XBase.Internal
{
    /// <summary>
    /// A collection of Records
    /// </summary>
    internal sealed class RecordCollection : IList<StarThrower.XBase.Internal.Record>, IList
    {
        #region Private Member Variables

        private StarThrower.XBase.Internal.FileHeader? _fileHeader;
        private List<StarThrower.XBase.Internal.Record> _list;

        #endregion


        #region Internal Properties

        internal StarThrower.XBase.Internal.FileHeader? FileHeader
        {
            get { return _fileHeader; }
            set { _fileHeader = value; }
        }

        #endregion


        #region Construction

        /// <summary>
        /// Default Constructor
        /// </summary>
        internal RecordCollection()
        {
            _list = new List<StarThrower.XBase.Internal.Record>();
        }

        internal RecordCollection(StarThrower.XBase.Internal.FileHeader fileHeader)
            : this()
        {
            _fileHeader = fileHeader;
        }

        #endregion


        #region Internal Custom Methods

        internal string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.AppendLine("<recordList>");
            foreach (StarThrower.XBase.Internal.Record record in this)
            {
                result.Append(record.ToXml());
            }
            result.AppendLine("</recordList>");
            return result.ToString();
        }

        internal byte[] GetBytes()
        {
            if (_fileHeader == null) throw new InvalidOperationException("FileHeader is not set.");
            byte[] result = new byte[this.Count * _fileHeader.RecordLength];
            Int32 curIdx = 0;
            for (Int32 i = 0; i < this.Count; i++)
            {
                StarThrower.XBase.Internal.Record record = this[i];
                result[curIdx++] = record.IsDeleted;
                for (Int32 j = 0; j < record.Data.Length; j++)
                {
                    result[curIdx++] = record.Data[j];
                }
            }
            return result;
        }

        #endregion


        #region IList<StarThrower.XBase.Internal.Record> Members

        /// <summary>
        /// Searches for the specified Record and returns the zero-based index of the first occurrence within the entire RecordCollection.
        /// </summary>
        /// <param name="item">The Record to locate in the RecordCollection.</param>
        /// <returns>true if the RecordCollection contains the specified value; otherwise, false.</returns>
        public int IndexOf(StarThrower.XBase.Internal.Record item)
        {
            return _list.IndexOf(item);
        }

        /// <summary>
        /// Inserts a Record into the RecordCollection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The Record to insert.</param>
        public void Insert(int index, StarThrower.XBase.Internal.Record item)
        {
            _list.Insert(index, item);
        }

        /// <summary>
        /// Removes the Record at the specified index of the RecordCollection.
        /// </summary>
        /// <param name="index">Zero-based index of the Record to remove.</param>
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        /// <summary>
        /// Gets or sets the Record at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the Record to get or set.</param>
        /// <returns>The Record at the specified index.</returns>
        public StarThrower.XBase.Internal.Record this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        #endregion


        #region ICollection<StarThrower.XBase.Internal.Record> Members

        /// <summary>
        /// Adds a Record to the end of the RecordCollection.
        /// </summary>
        /// <param name="item">The Record to be added.</param>
        public void Add(StarThrower.XBase.Internal.Record item)
        {
            _list.Add(item);
        }

        /// <summary>
        /// Removes all Records from the RecordCollection.
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }

        /// <summary>
        /// Determines whether a Record is in the RecordCollection.
        /// </summary>
        /// <param name="item">The Record to locate in the RecordCollection. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
        /// <returns>true if item is found in the RecordCollection; otherwise, false.</returns>
        public bool Contains(StarThrower.XBase.Internal.Record item)
        {
            return _list.Contains(item);
        }

        /// <summary>
        /// Copies the entire RecordCollection to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from RecordCollection. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(StarThrower.XBase.Internal.Record[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the number of Records actually contained in the RecordCollection.
        /// </summary>
        public int Count
        {
            get { return _list.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the RecordCollection is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific Record from the RecordCollection.
        /// </summary>
        /// <param name="item">The Record to remove from the RecordCollection. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the RecordCollection.</returns>
        public bool Remove(StarThrower.XBase.Internal.Record item)
        {
            return _list.Remove(item);
        }

        #endregion


        #region IEnumerable<StarThrower.XBase.Internal.Record> Members

        /// <summary>
        /// Returns an enumerator that iterates through the RecordCollection.
        /// </summary>
        /// <returns>An IEnumerator for the RecordCollection.</returns>
        public IEnumerator<StarThrower.XBase.Internal.Record> GetEnumerator()
        {
            foreach (StarThrower.XBase.Internal.Record o in _list)
            {
                yield return o;
            }
        }

        #endregion


        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through a RecordCollection.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the RecordCollection.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new StarThrower.XBase.Internal.RecordCollectionEnumerator(this);
        }

        #endregion


        #region IList Members

        /// <summary>
        /// Adds a Record to the end of the RecordCollection.
        /// </summary>
        /// <param name="value">The Object to add to the IList.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(object? value)
        {
            if (value is not StarThrower.XBase.Internal.Record item) throw new ArgumentException("value must be a Record.", nameof(value));
            _list.Add(item);
            return _list.Count - 1;
        }

        /// <summary>
        /// Determines whether the RecordCollection contains a specific Record.
        /// </summary>
        /// <param name="value">The Record to locate in the RecordCollection.</param>
        /// <returns>true if the Record is found in the RecordCollection; otherwise, false.</returns>
        public bool Contains(object? value)
        {
            return value is StarThrower.XBase.Internal.Record item && _list.Contains(item);
        }

        /// <summary>
        /// Determines the index of a specific Record in the RecordCollection.
        /// </summary>
        /// <param name="value">The Record to locate in the RecordCollection.</param>
        /// <returns>The index of value if found in the RecordCollection; otherwise, -1.</returns>
        public int IndexOf(object? value)
        {
            return value is StarThrower.XBase.Internal.Record item ? _list.IndexOf(item) : -1;
        }

        /// <summary>
        /// Inserts a Record to the RecordCollection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which value should be inserted.</param>
        /// <param name="value">The Record to insert into the RecordCollection.</param>
        public void Insert(int index, object? value)
        {
            if (value is not StarThrower.XBase.Internal.Record item) throw new ArgumentException("value must be a Record.", nameof(value));
            _list.Insert(index, item);
        }

        /// <summary>
        /// Gets a value indicating whether the RecordCollection has a fixed size.
        /// </summary>
        public bool IsFixedSize
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific Record from the RecordCollection.
        /// </summary>
        /// <param name="value">The Object to remove from the IList.</param>
        public void Remove(object? value)
        {
            if (value is StarThrower.XBase.Internal.Record item) _list.Remove(item);
        }

        /// <summary>
        /// Gets or sets the Record at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the Record to get or set.</param>
        /// <returns>The Record at the specified index.</returns>
        object? IList.this[int index]
        {
            get { return _list[index]; }
            set
            {
                if (value is not StarThrower.XBase.Internal.Record item) throw new ArgumentException("value must be a Record.", nameof(value));
                _list[index] = item;
            }
        }

        #endregion


        #region ICollection Members

        /// <summary>
        /// Copies the Records of the RecordCollection to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the Records copied from RecordCollection. The Array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        public void CopyTo(Array array, int index)
        {
            if (array is not StarThrower.XBase.Internal.Record[] typed) throw new ArgumentException("array must be Record[].", nameof(array));
            _list.CopyTo(typed, index);
        }

        /// <summary>
        /// Gets a value indicating whether access to the RecordCollection is synchronized (thread safe).
        /// </summary>
        public bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the RecordCollection.
        /// </summary>
        public object SyncRoot
        {
            get { return this; }
        }

        #endregion


        #region Object Overrides

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to compare to this object.</param>
        /// <returns>true if other is an instance of the same class as this object and has reference or value equality with this object; otherwise, false.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        public override bool Equals(object? obj)
        {
            if (Object.ReferenceEquals(obj, null)) return false;
            if (Object.ReferenceEquals(obj, this)) return true;
            if (!(obj is StarThrower.XBase.Internal.RecordCollection)) return false;
            StarThrower.XBase.Internal.RecordCollection other = (StarThrower.XBase.Internal.RecordCollection)obj;
            if (this.Count != other.Count) return false;
            for (int i = 0; i < this.Count; i++)
            {
                if (!(this[i].Equals(other[i]))) return false;
            }
            return true;
        }

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// Optimized for instances of this class.
        /// </summary>
        /// <param name="other">The object to compare to this object.</param>
        /// <returns>true if other has reference or value equality with this object; otherwise, false.</returns>
        public bool Equals(StarThrower.XBase.Internal.RecordCollection other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(other, this)) return true;
            if (this.Count != other.Count) return false;
            for (int i = 0; i < this.Count; i++)
            {
                if (!(this[i].Equals(other[i]))) return false;
            }
            return true;
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current RecordCollection.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            foreach (StarThrower.XBase.Internal.Record o in this)
            {
                result = 31 * result + o.GetHashCode();
            }
            return result;
        }

        /// <summary>
        /// Returns the string representation of this RecordCollection.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  Count=" + this.Count.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }


    /// <summary>
    /// Supports a simple iteration over a RecordCollection.
    /// </summary>
    internal sealed class RecordCollectionEnumerator : System.Collections.IEnumerator
    {
        #region Private Member Variables

        private StarThrower.XBase.Internal.RecordCollection _list;
        private int _cursor;

        #endregion


        #region Constructors / Destructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="list">The RecordCollection over which this IEnumerator is to iterate.</param>
        /// <exception cref="ArgumentNullException"></exception>
        internal RecordCollectionEnumerator(StarThrower.XBase.Internal.RecordCollection list)
        {
            ArgumentNullException.ThrowIfNull(list);

            _list = list;
            _cursor = -1;
        }

        #endregion


        #region IEnumerator Members

        /// <summary>
        /// Gets the current element in the RecordCollection.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        object IEnumerator.Current
        {
            get
            {
                if ((_cursor < 0) || (_cursor == _list.Count))
                {
                    throw new InvalidOperationException();
                }
                return _list[_cursor];
            }
        }


        /// <summary>
        /// Gets the current element in the RecordCollection.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public StarThrower.XBase.Internal.Record Current
        {
            get
            {
                if ((_cursor < 0) || (_cursor == _list.Count))
                {
                    throw new InvalidOperationException();
                }
                return _list[_cursor];
            }
        }

        /// <summary>
        /// Advances the enumerator to the next element of the RecordCollection.
        /// </summary>
        /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
        public bool MoveNext()
        {
            if (_cursor < _list.Count)
            {
                _cursor++;
            }

            return (!(_cursor == _list.Count));
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the RecordCollection.
        /// </summary>
        public void Reset()
        {
            _cursor = -1;
        }

        #endregion
    }
}
