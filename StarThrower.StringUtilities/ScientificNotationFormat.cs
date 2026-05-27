using System;

namespace StarThrower.StringUtilities
{
    /// <summary>
    /// A set of formats for representing scientific notation
    /// </summary>
    public enum ScientificNotationFormat
    {
        /// <summary>
        /// The standard scientific notation:  123E+4
        /// </summary>
        Exponential = 0,

        /// <summary>
        /// Base ten scientific notation:  123x10^+4
        /// </summary>
        Base10 = 1,

        /// <summary>
        /// Base ten scientific notation w/ spaces:  123 x 10^+4
        /// </summary>
        Base10Spaced = 2,

        /// <summary>
        /// Base ten scientific notation with superscripts:  123x10+4
        /// </summary>
        Base10Superscript = 3,

        /// <summary>
        /// Base ten scientific notation with superscripts and spaces:  123 x 10+4
        /// </summary>
        Base10SuperscriptSpaced = 4
    }
}
