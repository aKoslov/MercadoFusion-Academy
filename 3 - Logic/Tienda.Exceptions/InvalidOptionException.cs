using System;

namespace Tienda.Exceptions
{

    [System.Serializable]
    public class InvalidOptionException : System.Exception
    {
        public InvalidOptionException()
        {

        }
        public InvalidOptionException(string message) : base(message)
        {
            message = "- Opción Invalida -\nIntentá de nuevo";
        }
        public InvalidOptionException(string message, System.IndexOutOfRangeException inner) : base(message, inner) { }
        protected InvalidOptionException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        public void PrintMessage()
        {
            System.Console.WriteLine(this.Message);
        }
    }
}

