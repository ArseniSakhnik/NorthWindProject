using System;

namespace NorthWindProject.Application.Common.Exceptions
{
    public class ClientValidationException : Exception
    {

        public ClientValidationException(string message) : base(message)
        {
        }
    }
}