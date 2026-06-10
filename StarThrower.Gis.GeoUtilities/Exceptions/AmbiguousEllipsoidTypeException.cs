// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a UserDefined EllipsoidType is encountered w/out a qualifying Name for the Ellipsoid.
    /// </summary>
    public class AmbiguousEllipsoidTypeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the AmbiguousEllipsoidTypeException class.
        /// </summary>
        public AmbiguousEllipsoidTypeException() : base() { }

        /// <summary>
        /// Initializes a new instance of the AmbiguousEllipsoidTypeException class with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public AmbiguousEllipsoidTypeException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the AmbiguousEllipsoidTypeException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public AmbiguousEllipsoidTypeException(string message, Exception innerException) : base(message, innerException) { }
    }
}


