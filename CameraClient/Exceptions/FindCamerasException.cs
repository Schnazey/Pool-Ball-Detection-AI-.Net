using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraClient.Exceptions
{
    public class FindCamerasException:Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FindCamerasException"/> class.
        /// </summary>
        public FindCamerasException() : base()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FindCamerasException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public FindCamerasException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FindCamerasException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public FindCamerasException(string message, Exception innerException) : base(message, innerException)
        {
        }
        
    }
}
