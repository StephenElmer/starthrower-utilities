/***********************************************************************************
    StarThrower Utilities / XBase
    Copyright (C) 2005-2026  Stephen Elmer

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
***********************************************************************************/

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
