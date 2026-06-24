// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using StarThrower.StringUtilities;

namespace StarThrower.XBase
{
    /// <summary>
    /// A single record (row) in an XBase (.dbf) file: a fixed-width data string interpreted
    /// according to the field definitions in <see cref="Fields"/>, plus an <see cref="IsDeleted"/> flag.
    /// </summary>
    public class XBaseRecord
    {
        #region Private Member Variables

        private string _data = "";
        private bool _isDeleted;
        private StarThrower.XBase.XBaseFieldCollection _fields = new XBaseFieldCollection();

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets a reference to this XBaseRecord's collection of fields.
        /// </summary>
        public StarThrower.XBase.XBaseFieldCollection Fields
        {
            get { return _fields; }
        }

        /// <summary>
        /// Gets or sets the IsDeleted flag, indicating whether the XBaseRecord has been deleted.
        /// </summary>
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }

        #endregion


        #region Construction

        /// <summary>
        /// Initializes a new, empty record with no fields and no data. Instances are created by
        /// <see cref="XBaseFile"/>, which populates <see cref="Fields"/> and <see cref="Data"/>.
        /// </summary>
        internal XBaseRecord() { }

        #endregion


        #region Internal Properties

        /// <summary>
        /// Gets or sets the raw fixed-width record text, as stored in (or to be written to) the .dbf file.
        /// </summary>
        internal string Data
        {
            get { return _data; }
            set { _data = value; }
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Computes the character offset within <see cref="Data"/> where the field at the given
        /// position begins, based on the cumulative length of the preceding fields.
        /// </summary>
        private int CalculateStartIndex(int index, int length)
        {
            int result = 0;
            if (index == 0)
            {
                result = 0;
            }
            else if ((index + length) == _data.Length)
            {
                result = _data.Length - length;
            }
            else
            {
                for (int i = 0; i < _fields.Count; i++)
                {
                    if (i < index)
                    {
                        result += _fields[i].Length;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Overwrites the portion of <see cref="Data"/> occupied by the field at the given
        /// position with its already-converted fixed-width text representation.
        /// </summary>
        private void SetDataAtIndex(int index, string data)
        {
            int length = _fields[index].Length;
            int startIndex = CalculateStartIndex(index, length);
            _data = StringUtil.Replace(_data, data, startIndex, length);
        }

        /// <summary>
        /// Extracts the portion of <see cref="Data"/> occupied by the field at the given
        /// position and translates it to its in-memory .NET value.
        /// </summary>
        private object GetDataAtIndex(int index)
        {
            int length = _fields[index].Length;
            int startIndex = CalculateStartIndex(index, length);
            string temp = _data.Substring(startIndex, length);
            return _fields[index].Translate(temp);
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Gets the value of the named field in this record, translated to its in-memory .NET type.
        /// </summary>
        /// <param name="fieldName">The name of the field to retrieve.</param>
        /// <returns>The in-memory value of the named field.</returns>
        /// <exception cref="FieldNotFoundException">Thrown if no field named fieldName exists in <see cref="Fields"/>.</exception>
        public object GetData(string fieldName)
        {
            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new FieldNotFoundException();
            return GetDataAtIndex(index);
        }

        /// <summary>
        /// Sets the value of the named field in this record.
        /// </summary>
        /// <param name="fieldName">The name of the field to set.</param>
        /// <param name="data">The value to store. Must be a type valid for the field's data type (e.g. bool, DateTime, string, or a numeric type).</param>
        /// <exception cref="FieldNotFoundException">Thrown if no field named fieldName exists in <see cref="Fields"/>.</exception>
        /// <exception cref="BadDataException">Thrown if data is not valid for this field's data type.</exception>
        public void SetData(string fieldName, object data)
        {
            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new FieldNotFoundException();
            if (!_fields[index].IsValidData(data, out string result)) throw new BadDataException(result);
            SetDataAtIndex(index, result);
        }

        /// <summary>
        /// Sets the value of the named field in this record to a string.
        /// </summary>
        /// <param name="fieldName">The name of the field to set.</param>
        /// <param name="data">The string value to store.</param>
        /// <exception cref="FieldNotFoundException">Thrown if no field named fieldName exists in <see cref="Fields"/>.</exception>
        /// <exception cref="BadDataException">Thrown if data is not valid for this field's data type.</exception>
        public void SetData(string fieldName, string data)
        {
            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new FieldNotFoundException();
            if (!_fields[index].IsValidData(data, out string result)) throw new BadDataException(result);
            SetDataAtIndex(index, result);
        }

        /// <summary>
        /// Sets the value of the named field in this record to a boolean.
        /// </summary>
        /// <param name="fieldName">The name of the field to set.</param>
        /// <param name="data">The boolean value to store.</param>
        /// <exception cref="FieldNotFoundException">Thrown if no field named fieldName exists in <see cref="Fields"/>.</exception>
        /// <exception cref="BadDataException">Thrown if data is not valid for this field's data type.</exception>
        public void SetData(string fieldName, bool data)
        {
            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new FieldNotFoundException();
            if (!_fields[index].IsValidData(data, out string result)) throw new BadDataException(result);
            SetDataAtIndex(index, result);
        }

        /// <summary>
        /// Sets the value of the named field in this record to a date.
        /// </summary>
        /// <param name="fieldName">The name of the field to set.</param>
        /// <param name="data">The date value to store.</param>
        /// <exception cref="FieldNotFoundException">Thrown if no field named fieldName exists in <see cref="Fields"/>.</exception>
        /// <exception cref="BadDataException">Thrown if data is not valid for this field's data type.</exception>
        public void SetData(string fieldName, DateTime data)
        {
            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new FieldNotFoundException();
            if (!_fields[index].IsValidData(data, out string result)) throw new BadDataException(result);
            SetDataAtIndex(index, result);
        }

        /// <summary>
        /// Sets the value of the named field in this record to a double.
        /// </summary>
        /// <param name="fieldName">The name of the field to set.</param>
        /// <param name="data">The double value to store.</param>
        /// <exception cref="FieldNotFoundException">Thrown if no field named fieldName exists in <see cref="Fields"/>.</exception>
        /// <exception cref="BadDataException">Thrown if data is not valid for this field's data type.</exception>
        public void SetData(string fieldName, double data)
        {
            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new FieldNotFoundException();
            if (!_fields[index].IsValidData(data, out string result)) throw new BadDataException(result);
            SetDataAtIndex(index, result);
        }

        /// <summary>
        /// Sets the value of the named field in this record to a long.
        /// </summary>
        /// <param name="fieldName">The name of the field to set.</param>
        /// <param name="data">The long value to store.</param>
        /// <exception cref="FieldNotFoundException">Thrown if no field named fieldName exists in <see cref="Fields"/>.</exception>
        /// <exception cref="BadDataException">Thrown if data is not valid for this field's data type.</exception>
        public void SetData(string fieldName, long data)
        {
            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new FieldNotFoundException();
            if (!_fields[index].IsValidData(data, out string result)) throw new BadDataException(result);
            SetDataAtIndex(index, result);
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
            if (!(obj is StarThrower.XBase.XBaseRecord)) return false;
            StarThrower.XBase.XBaseRecord other = (StarThrower.XBase.XBaseRecord)obj;
            return _data.Equals(other._data, StringComparison.Ordinal) &&
                   _isDeleted.Equals(other._isDeleted) &&
                   _fields.Equals(other._fields);
        }

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// Optimized for instances of this class.
        /// </summary>
        /// <param name="other">The object to compare to this object.</param>
        /// <returns>true if other has reference or value equality with this object; otherwise, false.</returns>
        public bool Equals(StarThrower.XBase.XBaseRecord other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(other, this)) return true;
            return _data.Equals(other._data, StringComparison.Ordinal) &&
                   _isDeleted.Equals(other._isDeleted) &&
                   _fields.Equals(other._fields);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _data.GetHashCode();
            result = 31 * result + _isDeleted.GetHashCode();
            result = 31 * result + _fields.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this object.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  IsDeleted=" + _isDeleted.ToString() + ", Data='" + _data + "']";
        }

        #endregion
    }
}
