// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;

namespace StarThrower.XBase
{
    public class DateField : FieldType
    {
        public DateField()
            : base()
        {
            this.Text = "Date";
            this.Code = 'D';
        }

        public override XBaseField? Owner
        {
            get { return base.Owner; }
            set
            {
                ArgumentNullException.ThrowIfNull(value);

                base.Owner = value;
                value.Length = 8;
                value.DecimalCount = 0;
            }
        }

        public override int MinLength
        {
            get { return 8; }
        }

        public override int MaxLength
        {
            get { return 8; }
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
            if (!(data is DateTime))
            {
                result = "Invalid data type";
                return false;
            }

            DateTime temp = (DateTime)data;
            string yr = temp.Year.ToString(CultureInfo.InvariantCulture);
            string mo = String.Empty;
            string day = String.Empty;
            if (temp.Month < 10)
            {
                mo = "0" + temp.Month.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                mo = temp.Month.ToString(CultureInfo.InvariantCulture);
            }
            if (temp.Day < 10)
            {
                day = "0" + temp.Day.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                day = temp.Day.ToString(CultureInfo.InvariantCulture);
            }
            result = yr + mo + day;

            return true;
        }

        public override object Translate(string data)
        {
            ArgumentNullException.ThrowIfNull(data);

            int yr = int.Parse(data.AsSpan(0, 4), CultureInfo.InvariantCulture);
            int mo = int.Parse(data.AsSpan(4, 2), CultureInfo.InvariantCulture);
            int day = int.Parse(data.AsSpan(6, 2), CultureInfo.InvariantCulture);

            return new DateTime(yr, mo, day);
        }

    }
}
