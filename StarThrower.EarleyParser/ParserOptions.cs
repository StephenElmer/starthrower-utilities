/***********************************************************************************
    StarThrower Utilities / EarleyParser
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

namespace StarThrower.EarleyParser
{
    public class ParserOptions
    {
        #region [ Private Instance Variables ]

        private bool _ignoreCase;
        private bool _predictPreterminals;

        #endregion


        #region [ Public Properties ]

        public bool IgnoreCase
        {
            get { return _ignoreCase; }
            set { _ignoreCase = value; }
        }

        public bool PredictPreterminals
        {
            get { return _predictPreterminals; }
            set { _predictPreterminals = value; }
        }

        #endregion


        #region [ Construction ]

        public ParserOptions() : this(false, true) { }

        public ParserOptions(bool ignoreCase, bool predictPreterminals)
        {
            _ignoreCase = ignoreCase;
            _predictPreterminals = predictPreterminals;
        }

        #endregion
    }
}
