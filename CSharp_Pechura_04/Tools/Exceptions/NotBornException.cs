using System;

namespace CSharp_Pechura04.Tools.Exceptions
{
    class NotBornException : Exception
    {
        public NotBornException() : base("Людина ще не народилась!")
        {
        }
    }
}
