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

namespace StarThrower.XBase
{
    public class MemoField : FieldType
    {
        public MemoField()
            : base()
        {
            this.Text = Resources.Memo;
            this.Code = 'M';
        }

        public override XBaseField? Owner
        {
            get { return base.Owner; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");

                base.Owner = value;
                value.Length = 10;
                value.DecimalCount = 0;
            }
        }

        public override int MinLength
        {
            get { return 10; }
        }

        public override int MaxLength
        {
            get { return 10; }
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
            if (!(data is string))
            {
                result = "Invalid data type";
                return false;
            }

            result = String.Empty;
            return true;
        }

        public override object Translate(string data)
        {
            return data;
        }

    }
}
