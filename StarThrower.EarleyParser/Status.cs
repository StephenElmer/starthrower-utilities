using System;

namespace StarThrower.EarleyParser
{
    /// <summary>
    /// Reflects the status of a parse completed by an Earley parser.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Signals that a string is rejected after parsing.
        /// </summary>
        Reject = 0,

        /// <summary>
        /// Means that a string is a valid string of a given grammar as determined by parsing.
        /// </summary>
        Accept = 1,

        /// <summary>
        /// Used for parses where an error occurs during processing.
        /// </summary>
        Error = 2
    }
}
