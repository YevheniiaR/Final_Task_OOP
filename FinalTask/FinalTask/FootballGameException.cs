using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FinalTask
{
    class FootballGameException : Exception
    {
        public FootballGameException()
        {
            Console.WriteLine("Возникла какая-то проблема");
        }

        public FootballGameException(string message) : base(message)
        {
            Console.WriteLine(message);
        }

        public FootballGameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FootballGameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
