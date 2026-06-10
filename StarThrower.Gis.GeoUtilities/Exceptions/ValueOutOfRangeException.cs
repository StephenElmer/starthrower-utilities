// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a bad value is encountered.
    /// </summary>
    public class ValueOutOfRangeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the ValueOutOfRangeException class.
        /// </summary>
        public ValueOutOfRangeException() : base() { }

        /// <summary>
        /// Initializes a new instance of the ValueOutOfRangeException class with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public ValueOutOfRangeException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the ValueOutOfRangeException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public ValueOutOfRangeException(string message, Exception innerException) : base(message, innerException) { }
    }
}


