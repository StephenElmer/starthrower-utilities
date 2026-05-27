using System;

namespace StarThrower.XBase
{
    /// <summary>
    /// The exception that is thrown when a bad field length is encountered.
    /// </summary>
    [Serializable]
    public class InvalidFieldLengthException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the InvalidFieldLengthException class.
        /// </summary>
        public InvalidFieldLengthException() : base() { }

        /// <summary>
        /// Initializes a new instance of the InvalidFieldLengthException class with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public InvalidFieldLengthException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the InvalidFieldLengthException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public InvalidFieldLengthException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the InvalidFieldLengthException class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected InvalidFieldLengthException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
