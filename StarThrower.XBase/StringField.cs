using System;
using StarThrower.StringUtilities;

namespace StarThrower.XBase
{
    public class StringField : FieldType
    {
        public StringField()
            : base()
        {
            this.Text = Resources.String;
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
