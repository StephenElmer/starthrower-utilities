// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.XBase
{
    public class UndefinedField : FieldType
    {
        public UndefinedField()
            : base()
        {
            this.Text = "Undefined";
            this.Code = 'U';
        }


        public override int MinLength
        {
            get { return 0; }
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
            get { return 20; }
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
            result = "Invalid Data Type";
            return false;
        }

        public override object Translate(string data)
        {
            return String.Empty;
        }

    }
}
