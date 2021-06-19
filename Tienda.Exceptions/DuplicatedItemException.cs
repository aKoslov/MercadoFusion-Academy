using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Exceptions
{

    [System.Serializable]
    public class DuplicatedItem : System.Exception
    {
        public DuplicatedItem()
        {

        }
        public DuplicatedItem(string message) : base(message)
        {
            message = "Lorem ipsum dolor sit amet. Dupplicated ID";
        }
        public DuplicatedItem(string message, System.IndexOutOfRangeException inner) : base(message, inner) { }
        protected DuplicatedItem(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        public void PrintMessage()
        {
            System.Console.WriteLine(this.Message);
        }
    }

}