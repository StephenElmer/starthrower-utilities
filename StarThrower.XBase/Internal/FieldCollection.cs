// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using StarThrower.ByteUtilities;

namespace StarThrower.XBase.Internal
{
    /// <summary>
    /// A collection of Fields
    /// </summary>
    internal sealed class FieldCollection : IList<StarThrower.XBase.Internal.Field>, IList
    {
        internal const Int32 MAXSIZE = 128;


        #region Private Member Variables

        private List<StarThrower.XBase.Internal.Field> _list;

        #endregion


        #region Construction

        /// <summary>
        /// Default Constructor
        /// </summary>
        internal FieldCollection()
        {
            _list = new List<StarThrower.XBase.Internal.Field>();
        }

        #endregion


        #region Internal Custom Methods

        /// <summary>
        /// Searches the FieldCollection for a target fieldName.
        /// </summary>
        /// <param name="fieldName">The field name to search for.</param>
        /// <returns>True if the field exists, false if not.</returns>
        /// <exception cref="ArgumentNullException">Thrown if fieldName is null.</exception>
        internal bool Find(byte[] fieldName)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            Int32 idx = -1;
            return Find(fieldName, ref idx);
        }

        /// <summary>
        /// Searches the FieldCollection for a target Field.  If the Field is found, the index is filled in.
        /// </summary>
        /// <param name="fieldName">The Field to search for.</param>
        /// <param name="index">The index of the target in the list, if it is found.</param>
        /// <returns>True if the target is in the list, false if not or if an exception is thrown.</returns>
        /// <exception cref="ArgumentNullException">Thrown if fieldName is null.</exception>
        internal bool Find(byte[] fieldName, ref Int32 index)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            for (Int32 i = 0; i < this.Count; i++)
            {
                byte[] temp = new byte[this[i].Name.Length];
                if (this[i].Name.Length < fieldName.Length)
                {
                    continue;
                }
                else if (temp.Length == fieldName.Length)
                {
                    for (Int32 j = 0; j < fieldName.Length; j++)
                    {
                        temp[j] = fieldName[j];
                    }
                }
                else //(temp.Length > fieldName.Length)
                {
                    Int32 curIdx = 0;
                    for (Int32 j = 0; j < fieldName.Length; j++)
                    {
                        temp[curIdx++] = fieldName[j];
                    }
                    while (curIdx < temp.Length)
                    {
                        temp[curIdx++] = 0;
                    }
                }


                if ( this[i].Name.AsSpan().SequenceEqual(temp))
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }

        internal Int32 CalculateStartIndex(int index)
        {
            Int32 result = 0;
            for (Int32 i = 0; i < index; i++)
            {
                result += this[i].Length;
            }
            return result;
        }

        internal string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.AppendLine("<fieldList>");
            foreach (StarThrower.XBase.Internal.Field field in this)
            {
                result.Append(field.ToXml());
            }
            result.AppendLine("</fieldList>");
            return result.ToString();
        }

        internal void GetFieldBounds(byte[] fieldName, ref Int32 startIndex, ref Int32 length)
        {
            Int32 index = -1;
            if (!this.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this list of Field Descriptors.");
            length = this[index].Length;
            startIndex = CalculateStartIndex(index);
        }

        internal void GetFieldBounds(Int32 fieldIndex, ref Int32 startIndex, ref Int32 length)
        {
            if (fieldIndex < 0 || fieldIndex > (this.Count - 1)) throw new ArgumentOutOfRangeException(nameof(fieldIndex));
            length = this[fieldIndex].Length;
            startIndex = CalculateStartIndex(fieldIndex);
        }

        internal StarThrower.XBase.Internal.Field this[byte[] fieldName]
        {
            get
            {
                Int32 index = -1;
                if (!this.Find(fieldName, ref index)) throw new ArgumentException("Field " + fieldName + " does not exist.");
                return _list[index];
            }
            set
            {
                Int32 index = -1;
                if (!this.Find(fieldName, ref index)) throw new ArgumentException("Field " + fieldName + " does not exist.");
                _list[index] = value;
            }
        }

        #endregion


        #region IList<StarThrower.XBase.Internal.Field> Members

        /// <summary>
        /// Searches for the specified Field and returns the zero-based index of the first occurrence within the entire FieldCollection.
        /// </summary>
        /// <param name="item">The Field to locate in the FieldCollection.</param>
        /// <returns>true if the FieldCollection contains the specified value; otherwise, false.</returns>
        public int IndexOf(StarThrower.XBase.Internal.Field item)
        {
            return _list.IndexOf(item);
        }

        /// <summary>
        /// Inserts a Field into the FieldCollection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The Field to insert.</param>
        public void Insert(int index, StarThrower.XBase.Internal.Field item)
        {
            _list.Insert(index, item);
        }

        /// <summary>
        /// Removes the Field at the specified index of the FieldCollection.
        /// </summary>
        /// <param name="index">Zero-based index of the Field to remove.</param>
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        /// <summary>
        /// Gets or sets the Field at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the Field to get or set.</param>
        /// <returns>The Field at the specified index.</returns>
        public StarThrower.XBase.Internal.Field this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        #endregion


        #region ICollection<StarThrower.XBase.Internal.Field> Members

        /// <summary>
        /// Adds a Field to the end of the FieldCollection.
        /// </summary>
        /// <param name="item">The Field to be added.</param>
        public void Add(StarThrower.XBase.Internal.Field item)
        {
            _list.Add(item);
        }

        /// <summary>
        /// Removes all Fields from the FieldCollection.
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }

        /// <summary>
        /// Determines whether a Field is in the FieldCollection.
        /// </summary>
        /// <param name="item">The Field to locate in the FieldCollection. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
        /// <returns>true if item is found in the FieldCollection; otherwise, false.</returns>
        public bool Contains(StarThrower.XBase.Internal.Field item)
        {
            return _list.Contains(item);
        }

        /// <summary>
        /// Copies the entire FieldCollection to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from FieldCollection. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(StarThrower.XBase.Internal.Field[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the number of Fields actually contained in the FieldCollection.
        /// </summary>
        public int Count
        {
            get { return _list.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the FieldCollection is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific Field from the FieldCollection.
        /// </summary>
        /// <param name="item">The Field to remove from the FieldCollection. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the StringCollection.</returns>
        public bool Remove(StarThrower.XBase.Internal.Field item)
        {
            return _list.Remove(item);
        }

        #endregion


        #region IEnumerable<StarThrower.XBase.Internal.Field> Members

        /// <summary>
        /// Returns an enumerator that iterates through the FieldCollection.
        /// </summary>
        /// <returns>An IEnumerator for the FieldCollection.</returns>
        public IEnumerator<StarThrower.XBase.Internal.Field> GetEnumerator()
        {
            foreach (StarThrower.XBase.Internal.Field o in _list)
            {
                yield return o;
            }
        }

        #endregion


        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through a FieldCollection.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the FieldCollection.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new StarThrower.XBase.Internal.FieldCollectionEnumerator(this);
        }

        #endregion


        #region IList Members

        /// <summary>
        /// Adds a Field to the end of the FieldCollection.
        /// </summary>
        /// <param name="value">The Object to add to the IList.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(object? value)
        {
            if (value is not StarThrower.XBase.Internal.Field item) throw new ArgumentException("value must be a Field.", nameof(value));
            _list.Add(item);
            return _list.Count - 1;
        }

        /// <summary>
        /// Determines whether the FieldCollection contains a specific Field.
        /// </summary>
        /// <param name="value">The Field to locate in the FieldCollection.</param>
        /// <returns>true if the Field is found in the FieldCollection; otherwise, false.</returns>
        public bool Contains(object? value)
        {
            return value is StarThrower.XBase.Internal.Field item && _list.Contains(item);
        }

        /// <summary>
        /// Determines the index of a specific Field in the FieldCollection.
        /// </summary>
        /// <param name="value">The Field to locate in the FieldCollection.</param>
        /// <returns>The index of value if found in the FieldCollection; otherwise, -1.</returns>
        public int IndexOf(object? value)
        {
            return value is StarThrower.XBase.Internal.Field item ? _list.IndexOf(item) : -1;
        }

        /// <summary>
        /// Inserts a Field to the FieldCollection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which value should be inserted.</param>
        /// <param name="value">The Field to insert into the FieldCollection.</param>
        public void Insert(int index, object? value)
        {
            if (value is not StarThrower.XBase.Internal.Field item) throw new ArgumentException("value must be a Field.", nameof(value));
            _list.Insert(index, item);
        }

        /// <summary>
        /// Gets a value indicating whether the FieldCollection has a fixed size.
        /// </summary>
        public bool IsFixedSize
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific Field from the FieldCollection.
        /// </summary>
        /// <param name="value">The Object to remove from the IList.</param>
        public void Remove(object? value)
        {
            if (value is StarThrower.XBase.Internal.Field item) _list.Remove(item);
        }

        /// <summary>
        /// Gets or sets the Field at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the Field to get or set.</param>
        /// <returns>The Field at the specified index.</returns>
        object? IList.this[int index]
        {
            get { return _list[index]; }
            set
            {
                if (value is not StarThrower.XBase.Internal.Field item) throw new ArgumentException("value must be a Field.", nameof(value));
                _list[index] = item;
            }
        }

        #endregion


        #region ICollection Members

        /// <summary>
        /// Copies the Fields of the FieldCollection to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the Fields copied from FieldCollection. The Array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        public void CopyTo(Array array, int index)
        {
            if (array is not StarThrower.XBase.Internal.Field[] typed) throw new ArgumentException("array must be Field[].", nameof(array));
            _list.CopyTo(typed, index);
        }

        /// <summary>
        /// Gets a value indicating whether access to the FieldCollection is synchronized (thread safe).
        /// </summary>
        public bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the FieldCollection.
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
            if (!(obj is StarThrower.XBase.Internal.FieldCollection)) return false;
            StarThrower.XBase.Internal.FieldCollection other = (StarThrower.XBase.Internal.FieldCollection)obj;
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
        public bool Equals(StarThrower.XBase.Internal.FieldCollection other)
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
        /// <returns>A hash code for the current FieldCollection.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            foreach (StarThrower.XBase.Internal.Field o in this)
            {
                result = 31 * result + o.GetHashCode();
            }
            return result;
        }

        /// <summary>
        /// Returns the string representation of this FieldCollection.
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
    /// Supports a simple iteration over a FieldCollection.
    /// </summary>
    internal sealed class FieldCollectionEnumerator : System.Collections.IEnumerator
    {
        #region Private Member Variables

        private StarThrower.XBase.Internal.FieldCollection _list;
        private int _cursor;

        #endregion


        #region Constructors / Destructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="list">The FieldCollection over which this IEnumerator is to iterate.</param>
        /// <exception cref="ArgumentNullException"></exception>
        internal FieldCollectionEnumerator(StarThrower.XBase.Internal.FieldCollection list)
        {
            ArgumentNullException.ThrowIfNull(list);

            _list = list;
            _cursor = -1;
        }

        #endregion


        #region IEnumerator Members

        /// <summary>
        /// Gets the current element in the FieldCollection.
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
        /// Gets the current element in the FieldCollection.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public StarThrower.XBase.Internal.Field Current
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
        /// Advances the enumerator to the next element of the FieldCollection.
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
        /// Sets the enumerator to its initial position, which is before the first element in the FieldCollection.
        /// </summary>
        public void Reset()
        {
            _cursor = -1;
        }

        #endregion
    }
}
