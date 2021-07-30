using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.WebAPI.Models
{


    public class UserForAuth
    {
        //public int UserID { get; }

        public string Username { get; set; }

        public string Password { get; set; }

    }
    public class UserForSign
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int DNI { get; set; }

    }
        public class UserBase
    {
        public int UserID { get; }

        public string Username { get; set; }

        public string Password { get; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int DNI { get; set; }

        public DateTime CreationDate { get; }

        public UserBase(/*int userID,*/ string username, string name, string lastName, int dni, DateTime creationDate)
        {
            //UserID = userID;
            Username = username;
            Name = name;
            LastName = lastName;
            DNI = dni;
            CreationDate = creationDate;
        }
    }
}
