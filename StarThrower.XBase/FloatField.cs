// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;

namespace StarThrower.XBase
{
    public class FloatField : FieldType
    {
        public FloatField()
            : base()
        {
            this.Text = "Float";
            this.Code = 'F';
        }

        public override XBaseField? Owner
        {
            get { return base.Owner; }
            set
            {
                ArgumentNullException.ThrowIfNull(value);

                base.Owner = value;
                value.Length = 20;
            }
        }

        public override int MinLength
        {
            get { return 20; }
        }

        public override int MaxLength
        {
            get { return 20; }
        }

        public override int MinDecimalCount
        {
            get { return 0; }
        }

        public override int MaxDecimalCount
        {
            get { return 19; }
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
            //TODO: implement IsValidData for FloatField
            result = String.Empty;
            return true;
        }

        public override object Translate(string data)
        {
            //TODO: implement a more precise Translate method for FloatField
            return double.Parse(data, CultureInfo.InvariantCulture);
        }

    }
}
