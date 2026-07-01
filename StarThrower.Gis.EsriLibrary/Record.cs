// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using StarThrower.StringUtilities;
using StarThrower.XBase;

namespace StarThrower.Gis.EsriLibrary
{
    /// <summary>
    /// Represents a single record in a <see cref="ShapeFile"/>, combining the record's
    /// attribute data (field values) with its geographic shape. Instances are obtained from a
    /// <see cref="ShapeFile"/> via <see cref="ShapeFile.CreateNewRecord"/> or
    /// <see cref="ShapeFile.GetRecord(int)"/>.
    /// </summary>
    public class Record
    {
        #region Private Member Variables

        private XBaseFieldCollection _fields = new XBaseFieldCollection();
        private Dictionary<string, object?> _data = new Dictionary<string, object?>();
        private StarThrower.Gis.GeoUtilities.Shapes.Shape _shape = new StarThrower.Gis.GeoUtilities.Shapes.NullShape();

        #endregion


        #region Construction

        /// <summary>
        /// Initializes a new, empty <see cref="Record"/>. Records are created via
        /// <see cref="ShapeFile.CreateNewRecord"/> rather than directly by consumers.
        /// </summary>
        internal Record() { }

        #endregion


        #region Internal Methods

        /// <summary>
        /// Adds a field (converted to its XBase equivalent) to this record's schema and
        /// initializes its value to <see langword="null"/>.
        /// </summary>
        internal void AddField(StarThrower.Gis.EsriLibrary.Field field)
        {
            _fields.Add(EsriLibrary.EsriFieldToXBaseField(field));
            _data.Add(field.Name, null);
        }

        /// <summary>
        /// Adds an XBase field descriptor to this record's schema and initializes its value to
        /// <see langword="null"/>.
        /// </summary>
        internal void AddField(StarThrower.XBase.XBaseField field)
        {
            _fields.Add(field);
            _data.Add(field.Name, null);
        }

        /// <summary>
        /// Gets the collection of XBase field descriptors associated with this record.
        /// </summary>
        internal XBaseFieldCollection GetFieldDescriptors()
        {
            return _fields;
        }

        #endregion


        //#region Private Methods

        //private int CalculateStartIndex(int index, int length)
        //{
        //    int result = 0;
        //    if (index == 0)
        //    {
        //        result = 0;
        //    }
        //    else if ((index + length) == _data.Length)
        //    {
        //        result = _data.Length - length;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < _fields.Count; i++)
        //        {
        //            if (i < index)
        //            {
        //                result += _fields[i].Length;
        //            }
        //        }
        //    }
        //    return result;
        //}

        //#endregion


        /// <summary>
        /// Gets the value of the specified field formatted as a fixed-width string, padded
        /// with trailing spaces to the field's defined length, as required by the XBase
        /// (.dbf) file format.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is not a valid field name for this record.</exception>
        internal string GetXBaseDataString(string fieldName)
        {
            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));
            string result = StringUtil.AppendSpaces(GetData(fieldName)?.ToString() ?? string.Empty, _fields[index].Length);
            return result;
        }



        #region Public Methods

        /// <summary>
        /// Gets the current value stored for the specified field.
        /// </summary>
        /// <param name="fieldName">The name of the field whose value to retrieve.</param>
        /// <returns>The value stored for the field, or <see langword="null"/> if no value has been set.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is not a valid field name for this record.</exception>
        public object? GetData(string fieldName)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));

            //int length = _fields[index].Length;
            //int startIndex = CalculateStartIndex(index, length);

            return _data[fieldName];
        }

        /// <summary>
        /// Sets the value of the specified field.
        /// </summary>
        /// <param name="fieldName">The name of the field to set.</param>
        /// <param name="newValue">The value to store for the field.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is not a valid field name for this record.</exception>
        /// <exception cref="BadDataException"><paramref name="newValue"/> is not valid data for the field's type.</exception>
        public void SetData(string fieldName, object newValue)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName] = newValue;
        }

        /// <summary>
        /// Sets the value of the specified field to a Boolean value.
        /// </summary>
        /// <param name="fieldName">The name of the field to set.</param>
        /// <param name="newValue">The value to store for the field.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is not a valid field name for this record.</exception>
        /// <exception cref="BadDataException"><paramref name="newValue"/> is not valid data for the field's type.</exception>
        public void SetData(string fieldName, bool newValue)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName] = newValue;
        }

        /// <summary>
        /// Sets the value of the specified field to a date/time value.
        /// </summary>
        /// <param name="fieldName">The name of the field to set.</param>
        /// <param name="newValue">The value to store for the field.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is not a valid field name for this record.</exception>
        /// <exception cref="BadDataException"><paramref name="newValue"/> is not valid data for the field's type.</exception>
        public void SetData(string fieldName, DateTime newValue)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName] = newValue;
        }

        /// <summary>
        /// Sets the value of the specified field to a string value.
        /// </summary>
        /// <param name="fieldName">The name of the field to set.</param>
        /// <param name="newValue">The value to store for the field.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is not a valid field name for this record.</exception>
        /// <exception cref="BadDataException"><paramref name="newValue"/> is not valid data for the field's type.</exception>
        public void SetData(string fieldName, string newValue)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName] = newValue;
        }

        /// <summary>
        /// Sets the value of the specified field to a single-precision floating-point value.
        /// </summary>
        /// <param name="fieldName">The name of the field to set.</param>
        /// <param name="newValue">The value to store for the field.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is not a valid field name for this record.</exception>
        /// <exception cref="BadDataException"><paramref name="newValue"/> is not valid data for the field's type.</exception>
        public void SetData(string fieldName, float newValue)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName] = newValue;
        }

        /// <summary>
        /// Sets the value of the specified field to a double-precision floating-point value.
        /// </summary>
        /// <param name="fieldName">The name of the field to set.</param>
        /// <param name="newValue">The value to store for the field.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is not a valid field name for this record.</exception>
        /// <exception cref="BadDataException"><paramref name="newValue"/> is not valid data for the field's type.</exception>
        public void SetData(string fieldName, double newValue)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName] = newValue;
        }

        /// <summary>
        /// Sets the value of the specified field to an integer value.
        /// </summary>
        /// <param name="fieldName">The name of the field to set.</param>
        /// <param name="newValue">The value to store for the field.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is not a valid field name for this record.</exception>
        /// <exception cref="BadDataException"><paramref name="newValue"/> is not valid data for the field's type.</exception>
        public void SetData(string fieldName, long newValue)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName] = newValue;
        }

        /// <summary>
        /// Gets the geographic shape associated with this record.
        /// </summary>
        /// <returns>The record's <see cref="StarThrower.Gis.GeoUtilities.Shapes.Shape"/>.</returns>
        public StarThrower.Gis.GeoUtilities.Shapes.Shape GetShape()
        {
            return _shape;
        }

        /// <summary>
        /// Sets the geographic shape associated with this record.
        /// </summary>
        /// <param name="shape">The shape to associate with this record.</param>
        public void SetShape(StarThrower.Gis.GeoUtilities.Shapes.Shape shape)
        {
            _shape = shape;
        }

        #endregion
    }
}
