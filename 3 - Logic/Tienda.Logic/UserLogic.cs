using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tienda.DapperDA;
using Tienda.Dto;
using Tienda.Interfaces;

namespace Tienda.Logic
{
    public class UserLogic : IUserLogic
    {
        public DapperDataAccess dataAccess { get; }
        public UserSession sessionUser { get; set; }
        public User userData { get; set; }

        public UserLogic()
        {
            sessionUser = new UserSession() { UserId = 1, UserType = 1 };
            this.dataAccess = new DapperDataAccess();
        }

        public UserLogic(UserSession sessionUser, int userId)
        {
            this.dataAccess = new DapperDataAccess();
            this.sessionUser = sessionUser;
            this.userData = this.DisplayUserInfo(userId);

        }
        public UserSession UserLogin(string username, string password)
        {
            //DataHashing hash = new DataHashing();
            //string[] credentials = new string[dataAccess.UserLogin(username, password)];

            // Username : credentials[0]
            // Password : credentials[1]
            //Salt      : credentials[2]
            //Hash      : credentials[3]
            //UserID    : credentials[4]
            //if (
            //    credentials[0].ToString() == username &&
            //    credentials[1].ToString() == "1")
                //return 0;
            return dataAccess.UserLogin(username, password);

        }
        public bool UserSignup(User newUserData, string password)
        {
            return dataAccess.UserSignup(newUserData, password);
        }

        public List<User> ListUsers ()
        {
            return this.dataAccess.ListUsers(); 
        }

        public User RetrieveUser ()
        {
            return this.userData;
        }
        public UserSession RetrieveSession ()
        {
            return this.sessionUser;
        }
        public User DisplayUserInfo(int userId)
        {
            return dataAccess.DisplayUserInfo(userId);
        }

        public string DontDoThisAtHome (string username)
        {
            return dataAccess.RetrievePassword(username);
        }
        public bool UpdateUserInfo(User newUserData, string session)
        {
            return dataAccess.UpdateUserInfo(newUserData, session);
        }

        public bool ComparePassword(string username, string password)
        {
            return dataAccess.ComparePassword(username, password);
        }

        public string UpdateUserPassword(string session, string storePassword)
        {
            return dataAccess.UpdateUserPassword(session, storePassword);
        }
        public UserTypes ValidateUserType (string username)
        {
            return dataAccess.ValidateUserType(username);
        }
        public User NewUser()
        {
            return new User();
        }

    }
}
