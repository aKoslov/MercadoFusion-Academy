using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Exceptions
{
  
    public class NotOnListException : InvalidOperationException
    {
        public NotOnListException()
        {

        }

        public NotOnListException(string message) : base(message)
        {
            message = "No está ese";
        }
        public NotOnListException(string message, System.IndexOutOfRangeException inner) : base(message, inner) { }
        protected NotOnListException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        public void PrintMessage()
        {
            System.Console.WriteLine(this.Message);
        }
    }

}