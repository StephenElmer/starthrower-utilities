// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

namespace StarThrower.EarleyParser
{
    /// <summary>
    /// Configuration options controlling the behavior of a <see cref="Parser"/>.
    /// </summary>
    public class ParserOptions
    {
        #region [ Private Instance Variables ]

        private bool _ignoreCase;
        private bool _predictPreterminals;

        #endregion


        #region [ Public Properties ]

        /// <summary>
        /// Gets or sets whether token and terminal-category name matching during scanning
        /// is case-insensitive. Defaults to false (case-sensitive).
        /// </summary>
        public bool IgnoreCase
        {
            get { return _ignoreCase; }
            set { _ignoreCase = value; }
        }

        /// <summary>
        /// Gets or sets whether the prediction step adds edges for preterminal rules (rules whose
        /// right-hand side contains a terminal category) at every index, rather than only
        /// just-in-time when a matching token is scanned. Defaults to true.
        /// </summary>
        /// <remarks>
        /// Setting this to false can reduce the number of edges added to the chart for grammars
        /// with many preterminal rules, since edges are only predicted for a preterminal rule once
        /// a token matching it has actually been scanned. However, a grammar containing a
        /// preterminal rule whose right-hand side has more than one category (a terminal combined
        /// with other categories) is incompatible with just-in-time prediction; <see cref="Parser.Parse"/>
        /// detects this case and forces this option back to true for that parse.
        /// </remarks>
        public bool PredictPreterminals
        {
            get { return _predictPreterminals; }
            set { _predictPreterminals = value; }
        }

        #endregion


        #region [ Construction ]

        /// <summary>
        /// Creates a new set of parser options with case-sensitive matching and preterminal
        /// prediction enabled.
        /// </summary>
        public ParserOptions() : this(false, true) { }

        /// <summary>
        /// Creates a new set of parser options with the specified settings.
        /// </summary>
        /// <param name="ignoreCase">Whether token and terminal-category name matching should be case-insensitive.</param>
        /// <param name="predictPreterminals">Whether the prediction step should add edges for preterminal rules at every index.</param>
        public ParserOptions(bool ignoreCase, bool predictPreterminals)
        {
            _ignoreCase = ignoreCase;
            _predictPreterminals = predictPreterminals;
        }

        #endregion
    }
}
