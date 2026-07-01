// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a geoid type or type name refers to <see cref="Geoids.Undefined"/>
    /// or <see cref="Geoids.UserDefined"/>, neither of which can be resolved to a single geoid instance
    /// through <see cref="GeoidFactory.GetInstanceOfGeoid(System.Type)"/> or its string overload.
    /// </summary>
    public class AmbiguousGeoidTypeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the AmbiguousGeoidTypeException class.
        /// </summary>
        public AmbiguousGeoidTypeException() : base() { }

        /// <summary>
        /// Initializes a new instance of the AmbiguousGeoidTypeException class with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public AmbiguousGeoidTypeException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the AmbiguousGeoidTypeException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public AmbiguousGeoidTypeException(string message, Exception innerException) : base(message, innerException) { }
    }
}


