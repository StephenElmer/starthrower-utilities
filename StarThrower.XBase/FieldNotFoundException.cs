using System;

namespace StarThrower.XBase
{
    /// <summary>
    /// The exception that is thrown when a database with an incompatible schema is encountered.
    /// </summary>
    public class FieldNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the FieldNotFoundException class.
        /// </summary>
        public FieldNotFoundException() : base() { }

        /// <summary>
        /// Initializes a new instance of the FieldNotFoundException class with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public FieldNotFoundException(string? message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the FieldNotFoundException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public FieldNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
