using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest.Infrastructure
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException(string errorType, string message) : base(message)
        {
            ErrorType = errorType;
        }

        public AuthenticationException(string errorType, string message, Exception innerException) : base(message, innerException)
        {
            ErrorType = errorType;
        }

        public string ErrorType { get; }
    }
}
