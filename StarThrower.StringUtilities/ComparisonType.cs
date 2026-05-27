using System;

namespace StarThrower.StringUtilities
{
    /// <summary>
    /// A set of comparison "modes" for use within the StarThrower Utilities.
    /// </summary>
    public enum ComparisonType
    {
        /// <summary>
        /// Case Sensitive comparison
        /// </summary>
        CaseSensitive = 0,

        /// <summary>
        /// Case In-Sensitive comparision
        /// </summary>
        CaseInsensitive = 1,

        /// <summary>
        /// Comparison using the invariant culture 
        /// </summary>
        Database = 2
    }
}
