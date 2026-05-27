using System;

namespace StarThrower.ByteUtilities
{
    /// <summary>
    /// The exception that is thrown when an invalid version format is encountered.
    /// </summary>
    public class InvalidEndianException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the InvalidEndianException class.
        /// </summary>
        public InvalidEndianException() : base() { }

        /// <summary>
        /// Initializes a new instance of the InvalidEndianException class with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public InvalidEndianException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the InvalidEndianException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public InvalidEndianException(string message, Exception innerException) : base(message, innerException) { }
    }
}
