/***********************************************************************************
    StarThrower Utilities / XBase
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
using StarThrower.StringUtilities;

namespace StarThrower.XBase
{
    public class StringField : FieldType
    {
        public StringField()
            : base()
        {
            this.Text = "String";
            this.Code = 'C';
        }


        public override int MinLength
        {
            get { return 1; }
        }

        public override int MaxLength
        {
            get { return 253; }
        }

        public override int MinDecimalCount
        {
            get { return 0; }
        }

        public override int MaxDecimalCount
        {
            get { return 0; }
        }

        public override bool IsValidLength(int length)
        {
            return (length >= MinLength && length <= MaxLength);
        }

        public override bool IsValidDecimalCount(int decimalCount)
        {
            return (decimalCount >= MinDecimalCount && decimalCount <= MaxDecimalCount);
        }

        public override bool IsValidData(object data, out string result)
        {
            if (this.Owner is null) throw new InvalidOperationException("Owner is not set.");

            string? temp = data as String;
            if (temp == null)
            {
                result = "Invalid data type";
                return false;
            }

            if (temp.Length >= 254)
            {
                result = "Data exceeds maximum length for Character data type";
                return false;
            }
            else if (temp.Length > this.Owner.Length)
            {
                result = "Data exceeds length defined for this field";
                return false;
            }

            result = StringUtil.AppendSpaces(temp, this.Owner.Length);
            return true;
        }

        public override object Translate(string data)
        {
            return data;
        }

    }
}
