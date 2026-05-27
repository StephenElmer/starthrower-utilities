using System;
using System.Globalization;

namespace StarThrower.XBase
{
    public class DateField : FieldType
    {
        public DateField()
            : base()
        {
            this.Text = Resources.Date;
            this.Code = 'D';
        }

        public override XBaseField Owner
        {
            get { return base.Owner; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");

                base.Owner = value;
                base.Owner.Length = 8;
                base.Owner.DecimalCount = 0;
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
            if (data == null) throw new ArgumentNullException("data");

            int yr = int.Parse(data.Substring(0, 4), CultureInfo.InvariantCulture);
            int mo = int.Parse(data.Substring(4, 2), CultureInfo.InvariantCulture);
            int day = int.Parse(data.Substring(6, 2), CultureInfo.InvariantCulture);

            return new DateTime(yr, mo, day);
        }

    }
}
