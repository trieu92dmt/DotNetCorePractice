using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DotNetCorePractice.Utilities.Exceptions
{
    public class DotNetCorePracticeException : Exception
    {
        public DotNetCorePracticeException()
        {
        }

        public DotNetCorePracticeException(string message) : base(message)
        {
        }

        public DotNetCorePracticeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
