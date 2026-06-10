// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.XBase
{
    public abstract class FieldType
    {
        #region Private Instance Variables

        private XBaseField? _owner;
        private string _text = "Undefined";
        private char _code = 'U';

        #endregion


        #region IFieldType Members

        public string Text
        {
            get { return _text; }
            protected set { _text = value; }
        }

        public char Code
        {
            get { return _code; }
            protected set { _code = value; }
        }

        public virtual XBaseField? Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public abstract bool IsValidLength(int length);

        public abstract bool IsValidDecimalCount(int decimalCount);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#")]
        public abstract bool IsValidData(object data, out string result);

        public abstract object Translate(string data);

        public abstract int MaxLength { get; }

        public abstract int MinLength { get; }

        public abstract int MaxDecimalCount { get; }

        public abstract int MinDecimalCount { get; }

        #endregion
    }
}
