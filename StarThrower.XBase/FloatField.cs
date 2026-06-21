// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using StarThrower.StringUtilities;

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
            ArgumentNullException.ThrowIfNull(data);
            if (this.Owner is null) throw new InvalidOperationException("Owner is not set.");

            double value;
            if (data is Single sgl)
            {
                value = sgl;
            }
            else if (data is Double dbl)
            {
                value = dbl;
            }
            else
            {
                result = "Invalid data type";
                return false;
            }

            if (Double.IsNaN(value) || Double.IsInfinity(value))
            {
                result = "Invalid data type";
                return false;
            }

            string dataStr = value.ToString("F" + this.Owner.DecimalCount.ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
            if (dataStr.Length > this.Owner.Length)
            {
                result = "Data exceeds length defined for this field";
                return false;
            }

            result = StringUtil.AppendSpaces(dataStr, this.Owner.Length);
            return true;
        }

        public override object Translate(string data)
        {
            return double.Parse(data, CultureInfo.InvariantCulture);
        }

    }
}
