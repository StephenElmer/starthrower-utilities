// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

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
