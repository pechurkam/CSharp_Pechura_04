using System;

namespace CSharp_Pechura04.Tools.Exceptions
{
    internal class EmailException : Exception
    {
        public EmailException(string email)
            : base($"Неправильна адреса: {email}")

        {
        }
    }
}
