using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraClient.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an operation is attempted on a camera that is not open.
    /// </summary>
    internal class CameraNotOpenException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CameraNotOpenException"/> class.
        /// </summary>
        public CameraNotOpenException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraNotOpenException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CameraNotOpenException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraNotOpenException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a <c>null</c> reference if no inner exception is specified.</param>
        public CameraNotOpenException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
