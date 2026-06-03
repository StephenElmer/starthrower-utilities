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
using System.Globalization;

namespace StarThrower.Gis.EsriLibrary
{
    public class Field : ICloneable
    {
        #region Private Member Variables

        private string _name = "";
        private StarThrower.Gis.EsriLibrary.Types.FieldType? _type;
        private int _length = 0;
        private int _decimalCount = 0;

        #endregion


        #region Public Properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public StarThrower.Gis.EsriLibrary.Types.FieldType? Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public int DecimalCount
        {
            get { return _decimalCount; }
            set { _decimalCount = value; }
        }

        #endregion


        #region Construction

        public Field() { }

        public Field(StarThrower.Gis.EsriLibrary.Field other)
            : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

        public object Clone()
        {
            return new StarThrower.Gis.EsriLibrary.Field(this);
        }

        #endregion


        #region IItemCopyable Members

        public void ItemCopy(object value)
        {
            try
            {
                if (!(value is StarThrower.Gis.EsriLibrary.Field)) throw new ArgumentException("Could not cast " + value.GetType().ToString() + " to " + this.GetType().ToString());
                StarThrower.Gis.EsriLibrary.Field other = (StarThrower.Gis.EsriLibrary.Field)value;
                this.Name = other.Name;
                this.Type = other.Type;
                this.Length = other.Length;
                this.DecimalCount = other.DecimalCount;
            }
            catch
            {
                throw;
            }
        }

        #endregion


        #region Object Overrides

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is StarThrower.Gis.EsriLibrary.Field)) return false;
            StarThrower.Gis.EsriLibrary.Field other = (StarThrower.Gis.EsriLibrary.Field)obj;
            return _name.Equals(other.Name, StringComparison.Ordinal) &&
                   object.Equals(_type, other.Type) &&
                   _length.Equals(other.Length) &&
                   _decimalCount.Equals(other.DecimalCount);
        }

        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _name.GetHashCode();
            result = 31 * result + (_type?.GetHashCode() ?? 0);
            result = 31 * result + _length.GetHashCode();
            result = 31 * result + _decimalCount.GetHashCode();
            return result;
        }

        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  Name='" + _name + "', Type=" + (_type?.ToString() ?? "null") + ", Length=" + _length.ToString(CultureInfo.InvariantCulture) + ", DecimalCount=" + _decimalCount.ToString(CultureInfo.InvariantCulture) + "]";
        }

        #endregion
    }
}
