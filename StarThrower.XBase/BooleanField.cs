using System;

namespace StarThrower.XBase
{
    public class BooleanField : FieldType
    {
        public BooleanField()
            : base()
        {
            this.Text = Resources.Boolean;
            this.Code = 'L';
        }

        public override XBaseField? Owner
        {
            get { return base.Owner; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");

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
            if (data == null) throw new ArgumentNullException("data");

            if (String.Compare(data, "y", StringComparison.OrdinalIgnoreCase) == 0 ||
                String.Compare(data, "t", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return true;
            }
            else if (String.Compare(data, "n", StringComparison.OrdinalIgnoreCase) == 0 ||
                     String.Compare(data, "f", StringComparison.OrdinalIgnoreCase) == 0 ||
                     String.Compare(data, "?", StringComparison.OrdinalIgnoreCase) == 0)
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
