// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.XBase
{
    public class BooleanField : FieldType
    {
        public BooleanField()
            : base()
        {
            this.Text = "Boolean";
            this.Code = 'L';
        }

        public override XBaseField? Owner
        {
            get { return base.Owner; }
            set
            {
                ArgumentNullException.ThrowIfNull(value);

                base.Owner = value;
                value.Length = 1;
                value.DecimalCount = 0;
            }
        }

        public override int MinLength
        {
            get { return 1; }
        }

        public override int MaxLength
        {
            get { return 1; }
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
            if (!(data is bool))
            {
                result = "Invalid data type";
                return false;
            }

            bool temp = (bool)data;
            if (temp)
            {
                result = "T";
            }
            else
            {
                result = "F";
            }

            return true;
        }

        public override object Translate(string data)
        {
            ArgumentNullException.ThrowIfNull(data);

            if (string.Equals(data, "y", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(data, "t", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (string.Equals(data, "n", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(data, "f", StringComparison.OrdinalIgnoreCase)   ||
                     string.Equals(data, "?", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                throw new BadDataException();
            }
        }
    }
}
