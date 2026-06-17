// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using StarThrower.StringUtilities;
using StarThrower.XBase;

namespace StarThrower.Gis.EsriLibrary
{
    public class Record
    {
        #region Private Member Variables

        private XBaseFieldCollection _fields = new XBaseFieldCollection();
        private Dictionary<string, object?> _data = new Dictionary<string, object?>();
        private StarThrower.Gis.GeoUtilities.Shapes.Shape _shape = new StarThrower.Gis.GeoUtilities.Shapes.NullShape();

        #endregion


        #region Construction

        internal Record() { }

        #endregion


        #region Internal Methods

        internal void AddField(StarThrower.Gis.EsriLibrary.Field field)
        {
            _fields.Add(EsriLibrary.EsriFieldToXBaseField(field));
            _data.Add(field.Name, null);
        }

        internal void AddField(StarThrower.XBase.XBaseField field)
        {
            _fields.Add(field);
            _data.Add(field.Name, null);
        }

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


        internal string GetXBaseDataString(string fieldName)
        {
            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));
            string result = StringUtil.AppendSpaces(GetData(fieldName)?.ToString() ?? string.Empty, _fields[index].Length);
            return result;
        }



        #region Public Methods

        public object? GetData(string fieldName)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));

            //int length = _fields[index].Length;
            //int startIndex = CalculateStartIndex(index, length);

            return _data[fieldName];
        }

        public void SetData(string fieldName, object newValue)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName] = newValue;
        }

        public void SetData(string fieldName, bool newValue)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName] = newValue;
        }

        public void SetData(string fieldName, DateTime newValue)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName] = newValue;
        }

        public void SetData(string fieldName, string newValue)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName] = newValue;
        }

        public void SetData(string fieldName, float newValue)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName] = newValue;
        }

        public void SetData(string fieldName, double newValue)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName] = newValue;
        }

        public void SetData(string fieldName, long newValue)
        {
            ArgumentNullException.ThrowIfNull(fieldName);

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException(fieldName + " is not a valid field name for this record.", nameof(fieldName));
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName] = newValue;
        }

        public StarThrower.Gis.GeoUtilities.Shapes.Shape GetShape()
        {
            return _shape;
        }

        public void SetShape(StarThrower.Gis.GeoUtilities.Shapes.Shape shape)
        {
            _shape = shape;
        }

        #endregion
    }
}
