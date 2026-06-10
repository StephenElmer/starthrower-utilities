// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.XBase
{
    public class MemoField : FieldType
    {
        public MemoField()
            : base()
        {
            this.Text = "Memo";
            this.Code = 'M';
        }

        public override XBaseField? Owner
        {
            get { return base.Owner; }
            set
            {
                ArgumentNullException.ThrowIfNull(value);

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
