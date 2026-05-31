/***********************************************************************************
    StarThrower Utilities / Gis.EsriLibrary
    Copyright (C) 2005-2026  Stephen Elmer

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
***********************************************************************************/

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
            _data.Add(field.Name.Replace("\0", ""), null);
        }

        internal void AddField(StarThrower.XBase.XBaseField field)
        {
            _fields.Add(field);
            _data.Add(field.Name.Replace("\0", ""), null);
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
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException();
            string result = StringUtil.AppendSpaces(GetData(fieldName)?.ToString() ?? string.Empty, _fields[index].Length);
            return result;
        }



        #region Public Methods

        public object? GetData(string fieldName)
        {
            if (fieldName == null) throw new ArgumentNullException("fieldName");

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException();

            //int length = _fields[index].Length;
            //int startIndex = CalculateStartIndex(index, length);

            return _data[fieldName.Replace("\0", "")];
        }

        public void SetData(string fieldName, object newValue)
        {
            if (fieldName == null) throw new ArgumentNullException("fieldName");

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException();
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName.Replace("\0", "")] = newValue;
        }

        public void SetData(string fieldName, bool newValue)
        {
            if (fieldName == null) throw new ArgumentNullException("fieldName");

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException();
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName.Replace("\0", "")] = newValue;
        }

        public void SetData(string fieldName, DateTime newValue)
        {
            if (fieldName == null) throw new ArgumentNullException("fieldName");

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException();
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName.Replace("\0", "")] = newValue;
        }

        public void SetData(string fieldName, string newValue)
        {
            if (fieldName == null) throw new ArgumentNullException("fieldName");

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException();
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName.Replace("\0", "")] = newValue;
        }

        public void SetData(string fieldName, float newValue)
        {
            if (fieldName == null) throw new ArgumentNullException("fieldName");

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException();
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName.Replace("\0", "")] = newValue;
        }

        public void SetData(string fieldName, double newValue)
        {
            if (fieldName == null) throw new ArgumentNullException("fieldName");

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException();
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName.Replace("\0", "")] = newValue;
        }

        public void SetData(string fieldName, long newValue)
        {
            if (fieldName == null) throw new ArgumentNullException("fieldName");

            int index = -1;
            if (!_fields.Find(fieldName, ref index)) throw new ArgumentException();
            string result = String.Empty;
            if (!_fields[index].IsValidData(newValue, out result)) throw new BadDataException(result);
            _data[fieldName.Replace("\0", "")] = newValue;
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
