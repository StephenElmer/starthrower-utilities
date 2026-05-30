using System;
using System.Collections.Generic;
using StarThrower.StringUtilities;

namespace StarThrower.XBase
{
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

        internal XBaseRecord() { }

        #endregion


        #region Internal Properties

        internal string Data
        {
            get { return _data; }
            set { _data = value; }
        }

        #endregion


        #region Private Methods

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

        private void SetDataAtIndex(int index, string data)
        {
            int length = _fields[index].Length;
            int startIndex = CalculateStartIndex(index, length);
            _data = StringUtil.Replace(_data, data, startIndex, length);
        }

        private object GetDataAtIndex(int index)
        {
            int length = _fields[index].Length;
            int startIndex = CalculateStartIndex(index, length);
            string temp = _data.Substring(startIndex, length);
            return _fields[index].Translate(temp);
        }

        #endregion


        #region Public Methods

        public object GetData(string fieldName)
        {
            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new FieldNotFoundException();
            return GetDataAtIndex(index);
        }

        public void SetData(string fieldName, object data)
        {
            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new FieldNotFoundException();
            if (!_fields[index].IsValidData(data, out string result)) throw new BadDataException(result);
            SetDataAtIndex(index, result);
        }

        public void SetData(string fieldName, string data)
        {
            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new FieldNotFoundException();
            if (!_fields[index].IsValidData(data, out string result)) throw new BadDataException(result);
            SetDataAtIndex(index, result);
        }

        public void SetData(string fieldName, bool data)
        {
            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new FieldNotFoundException();
            if (!_fields[index].IsValidData(data, out string result)) throw new BadDataException(result);
            SetDataAtIndex(index, result);
        }

        public void SetData(string fieldName, DateTime data)
        {
            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new FieldNotFoundException();
            if (!_fields[index].IsValidData(data, out string result)) throw new BadDataException(result);
            SetDataAtIndex(index, result);
        }

        public void SetData(string fieldName, double data)
        {
            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new FieldNotFoundException();
            if (!_fields[index].IsValidData(data, out string result)) throw new BadDataException(result);
            SetDataAtIndex(index, result);
        }

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
            return _data.Equals(other._data) &&
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
            return _data.Equals(other._data) &&
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
