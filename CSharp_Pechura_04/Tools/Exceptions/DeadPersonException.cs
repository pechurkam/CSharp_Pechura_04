using System;

namespace CSharp_Pechura02_03.Tools.Exceptions
{
    class DeadPersonException : Exception
    {
        public DeadPersonException() : base("Людині не може бути більше 135 років")
        {
        }
    }
}
