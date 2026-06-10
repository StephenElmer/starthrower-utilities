// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using StarThrower.Logging;

namespace StarThrower.XBase
{
    /// <summary>
    /// A collection of XBaseFields
    /// </summary>
    public class XBaseFieldCollection : IList<StarThrower.XBase.XBaseField>, IList
    {
        #region Private Member Variables

        private List<StarThrower.XBase.XBaseField> _list;

        #endregion


        #region Construction

        /// <summary>
        /// Default Constructor
        /// </summary>
        public XBaseFieldCollection()
        {
            _list = new List<StarThrower.XBase.XBaseField>();
        }

        #endregion


        #region Public Custom Methods

        /// <summary>
        /// Searches the XBaseFieldCollection for a target fieldName.
        /// </summary>
        /// <param name="fieldName">The field name to search for.</param>
        /// <returns>True if the field exists, false if not.</returns>
        /// <exception cref="ArgumentNullException">Thrown if fieldName is null.</exception>
        public bool Find(string fieldName)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            try
            {
                int index = -1;
                return this.Find(fieldName, ref index);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".Find(string)", ex);
                throw;
            }
        }

        /// <summary>
        /// Searches the XBaseFieldCollection for a target XBaseField.  If the XBaseField is found, the index is filled in.
        /// </summary>
        /// <param name="fieldName">The name of the XBaseField to search for.</param>
        /// <param name="index">The index of the XBaseField in the list, if it is found.</param>
        /// <returns>True if the XBaseField is in the list, false if not or if an exception is thrown.</returns>
        /// <exception cref="ArgumentNullException">Thrown if fieldName is null.</exception>
        public bool Find(string fieldName, ref int index)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            try
            {
                for (Int32 i = 0; i < this.Count; i++)
                {
                    string temp = this[i].Name;
                    if (this[i].Name.Length < fieldName.Length)
                    {
                        continue;
                    }
                    else if (temp.Length == fieldName.Length)
                    {
                        temp = fieldName;
                    }
                    else //(temp.Length > fieldName.Length)
                    {
                        char[] buf = new char[this[i].Name.Length];
                        int curIdx = 0;
                        for (int j = 0; j < fieldName.Length; j++)
                        {
                            buf[curIdx++] = fieldName[j];
                        }
                        while (curIdx < temp.Length)
                        {
                            buf[curIdx++] = '\0';
                        }
                        temp = new string(buf);
                    }

                    if (this[i].Name.Equals(temp, StringComparison.Ordinal))
                    {
                        index = i;
                        return true;
                    }
                }
                index = -1;
                return false;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".Find(string, int)", ex);
                throw;
            }
        }

        public XBaseField this[string fieldName]
        {
            get
            {
                ArgumentNullException.ThrowIfNull(fieldName);

                int index = -1;
                if (!this.Find(fieldName, ref index)) throw new ArgumentOutOfRangeException(nameof(fieldName));
                return this[index];
            }
            set
            {
                ArgumentNullException.ThrowIfNull(fieldName);

                int index = -1;
                if (!this.Find(fieldName, ref index)) throw new ArgumentOutOfRangeException(nameof(fieldName));
                this[index] = value;
            }
        }

        #endregion


        #region IList<StarThrower.XBase.XBaseField> Members

        /// <summary>
        /// Searches for the specified XBaseField and returns the zero-based index of the first occurrence within the entire XBaseFieldCollection.
        /// </summary>
        /// <param name="item">The XBaseField to locate in the XBaseFieldCollection.</param>
        /// <returns>true if the XBaseFieldCollection contains the specified value; otherwise, false.</returns>
        public int IndexOf(StarThrower.XBase.XBaseField item)
        {
            try
            {
                return _list.IndexOf(item);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".IndexOf(XBaseField)", ex);
                throw;
            }
        }

        /// <summary>
        /// Inserts an XBaseField into the XBaseFieldCollection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The XBaseField to insert.</param>
        public void Insert(int index, StarThrower.XBase.XBaseField item)
        {
            try
            {
                _list.Insert(index, item);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".Insert(int, XBaseField)", ex);
                throw;
            }
        }

        /// <summary>
        /// Removes the XBaseField at the specified index of the XBaseFieldCollection.
        /// </summary>
        /// <param name="index">Zero-based index of the XBaseField to remove.</param>
        public void RemoveAt(int index)
        {
            try
            {
                _list.RemoveAt(index);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".RemoveAt(int)", ex);
                throw;
            }
        }

        /// <summary>
        /// Gets or sets the XBaseField at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the XBaseField to get or set.</param>
        /// <returns>The XBaseField at the specified index.</returns>
        public StarThrower.XBase.XBaseField this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        #endregion


        #region ICollection<StarThrower.XBase.XBaseField> Members

        /// <summary>
        /// Adds a XBaseField to the end of the XBaseFieldCollection.
        /// </summary>
        /// <param name="item">The XBaseField to be added.</param>
        public void Add(StarThrower.XBase.XBaseField item)
        {
            try
            {
                _list.Add(item);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".Add(string)", ex);
                throw;
            }
        }

        /// <summary>
        /// Removes all XBaseFields from the XBaseFieldCollection.
        /// </summary>
        public void Clear()
        {
            try
            {
                _list.Clear();
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".Clear()", ex);
                throw;
            }
        }

        /// <summary>
        /// Determines whether a XBaseField is in the XBaseFieldCollection.
        /// </summary>
        /// <param name="item">The XBaseField to locate in the XBaseFieldCollection. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
        /// <returns>true if item is found in the XBaseFieldCollection; otherwise, false.</returns>
        public bool Contains(StarThrower.XBase.XBaseField item)
        {
            try
            {
                return _list.Contains(item);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".Contains(string)", ex);
                throw;
            }
        }

        /// <summary>
        /// Copies the entire XBaseFieldCollection to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from XBaseFieldCollection. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(StarThrower.XBase.XBaseField[] array, int arrayIndex)
        {
            try
            {
                _list.CopyTo(array, arrayIndex);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".CopyTo(string[], int)", ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the number of XBaseFields actually contained in the XBaseFieldCollection.
        /// </summary>
        public int Count
        {
            get { return _list.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the XBaseFieldCollection is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific XBaseField from the XBaseFieldCollection.
        /// </summary>
        /// <param name="item">The XBaseField to remove from the XBaseFieldCollection. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the XBaseFieldCollection.</returns>
        public bool Remove(StarThrower.XBase.XBaseField item)
        {
            try
            {
                return _list.Remove(item);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".Remove(string)", ex);
                throw;
            }
        }

        #endregion


        #region IEnumerable<StarThrower.XBase.XBaseField> Members

        /// <summary>
        /// Returns an enumerator that iterates through the XBaseFieldCollection.
        /// </summary>
        /// <returns>An IEnumerator for the XBaseFieldCollection.</returns>
        public IEnumerator<StarThrower.XBase.XBaseField> GetEnumerator()
        {
            foreach (StarThrower.XBase.XBaseField o in _list)
            {
                yield return o;
            }
        }

        #endregion


        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through a XBaseFieldCollection.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the XBaseFieldCollection.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            try
            {
                return new StarThrower.XBase.XBaseFieldCollectionEnumerator(this);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".GetEnumerator()", ex);
                throw;
            }
        }

        #endregion


        #region IList Members

        /// <summary>
        /// Adds a XBaseField to the end of the XBaseFieldCollection.
        /// </summary>
        /// <param name="value">The Object to add to the IList.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(object? value)
        {
            try
            {
                if (value is not StarThrower.XBase.XBaseField item) throw new ArgumentException("value must be an XBaseField.", nameof(value));
                _list.Add(item);
                return _list.Count - 1;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".Add(object)", ex);
                throw;
            }
        }

        /// <summary>
        /// Determines whether the XBaseFieldCollection contains a specific XBaseField.
        /// </summary>
        /// <param name="value">The XBaseField to locate in the XBaseFieldCollection.</param>
        /// <returns>true if the XBaseField is found in the XBaseFieldCollection; otherwise, false.</returns>
        public bool Contains(object? value)
        {
            try
            {
                return value is StarThrower.XBase.XBaseField item && _list.Contains(item);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".Contains(object)", ex);
                throw;
            }
        }

        /// <summary>
        /// Determines the index of a specific XBaseField in the XBaseFieldCollection.
        /// </summary>
        /// <param name="value">The XBaseField to locate in the XBaseFieldCollection.</param>
        /// <returns>The index of value if found in the XBaseFieldCollection; otherwise, -1.</returns>
        public int IndexOf(object? value)
        {
            try
            {
                return value is StarThrower.XBase.XBaseField item ? _list.IndexOf(item) : -1;
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".IndexOf(object)", ex);
                throw;
            }
        }

        /// <summary>
        /// Inserts a XBaseField to the XBaseFieldCollection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which value should be inserted.</param>
        /// <param name="value">The XBaseField to insert into the XBaseFieldCollection.</param>
        public void Insert(int index, object? value)
        {
            try
            {
                if (value is not StarThrower.XBase.XBaseField item) throw new ArgumentException("value must be an XBaseField.", nameof(value));
                _list.Insert(index, item);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".Insert(int, object)", ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the XBaseFieldCollection has a fixed size.
        /// </summary>
        public bool IsFixedSize
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific XBaseField from the XBaseFieldCollection.
        /// </summary>
        /// <param name="value">The Object to remove from the IList.</param>
        public void Remove(object? value)
        {
            try
            {
                if (value is StarThrower.XBase.XBaseField item) _list.Remove(item);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".Remove(object)", ex);
                throw;
            }
        }

        /// <summary>
        /// Gets or sets the XBaseField at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the XBaseField to get or set.</param>
        /// <returns>The XBaseField at the specified index.</returns>
        object? IList.this[int index]
        {
            get { return _list[index]; }
            set
            {
                try
                {
                    if (value is not StarThrower.XBase.XBaseField item) throw new ArgumentException("value must be an XBaseField.", nameof(value));
                    _list[index] = item;
                }
                catch (Exception ex)
                {
                    Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".this[int]", ex);
                    throw;
                }
            }
        }

        #endregion


        #region ICollection Members

        /// <summary>
        /// Copies the XBaseFields of the XBaseFieldCollection to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the XBaseFields copied from XBaseFieldCollection. The Array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        public void CopyTo(Array array, int index)
        {
            try
            {
                if (array is not StarThrower.XBase.XBaseField[] typed) throw new ArgumentException("array must be XBaseField[].", nameof(array));
                _list.CopyTo(typed, index);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".CopyTo(Array, int)", ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a value indicating whether access to the XBaseFieldCollection is synchronized (thread safe).
        /// </summary>
        public bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the XBaseFieldCollection.
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
            if (!(obj is StarThrower.XBase.XBaseFieldCollection)) return false;
            StarThrower.XBase.XBaseFieldCollection other = (StarThrower.XBase.XBaseFieldCollection)obj;
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
        public bool Equals(StarThrower.XBase.XBaseFieldCollection other)
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
        /// <returns>A hash code for the current XBaseFieldCollection.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            foreach (StarThrower.XBase.XBaseField o in this)
            {
                result = 31 * result + o.GetHashCode();
            }
            return result;
        }

        /// <summary>
        /// Returns the string representation of this XBaseFieldCollection.
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
    /// Supports a simple iteration over a XBaseFieldCollection.
    /// </summary>
    public class XBaseFieldCollectionEnumerator : System.Collections.IEnumerator
    {
        #region Private Member Variables

        private StarThrower.XBase.XBaseFieldCollection _list;
        private int _cursor;

        #endregion


        #region Constructors / Destructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="list">The XBaseFieldCollection over which this IEnumerator is to iterate.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public XBaseFieldCollectionEnumerator(StarThrower.XBase.XBaseFieldCollection list)
        {
            ArgumentNullException.ThrowIfNull(list);
            _list = list;
            _cursor = -1;
        }

        #endregion


        #region IEnumerator Members

        /// <summary>
        /// Gets the current element in the XBaseFieldCollection.
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
        /// Gets the current element in the XBaseFieldCollection.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public StarThrower.XBase.XBaseField Current
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
        /// Advances the enumerator to the next element of the XBaseFieldCollection.
        /// </summary>
        /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
        public bool MoveNext()
        {
            try
            {
                if (_cursor < _list.Count)
                {
                    _cursor++;
                }

                return (!(_cursor == _list.Count));
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".MoveNext()", ex);
                throw;
            }
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the XBaseFieldCollection.
        /// </summary>
        public void Reset()
        {
            _cursor = -1;
        }

        #endregion
    }
}
