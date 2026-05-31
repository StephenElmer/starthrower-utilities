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

namespace StarThrower.Gis.EsriLibrary.Types
{
    public class DateField : StarThrower.Gis.EsriLibrary.Types.FieldType
    {
        #region Private Member Variables

        private StarThrower.XBase.DateField _field = new StarThrower.XBase.DateField();

        #endregion


        #region Construction

        public DateField()
        {
            this.Code = _field.Code;
            this.Text = _field.Text;
        }

        #endregion


        #region Public Methods

        public override int MinLength
        {
            get { return _field.MinLength; }
        }

        public override int MaxLength
        {
            get { return _field.MaxLength; }
        }

        public override int MinDecimalCount
        {
            get { return _field.MinDecimalCount; }
        }

        public override int MaxDecimalCount
        {
            get { return _field.MaxDecimalCount; }
        }

        public override bool IsValidLength(int length)
        {
            return _field.IsValidLength(length);
        }

        public override bool IsValidDecimalCount(int decimalCount)
        {
            return _field.IsValidDecimalCount(decimalCount);
        }

        public override bool IsValidData(object data, out string result)
        {
            return _field.IsValidData(data, out result);
        }

        public override object Translate(string data)
        {
            return _field.Translate(data);
        }

        #endregion
    }
}
