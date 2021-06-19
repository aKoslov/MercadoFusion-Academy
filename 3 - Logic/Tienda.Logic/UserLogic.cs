using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tienda.Dapper;
using Tienda.Dto;
using Tienda.Interfaces;

namespace Tienda.Logic
{
    public class UserLogic : IUsersLogic
    {
        public DapperDataAccess dataAccess { get; }
        public UserSession sessionUser { get; set; }
        public User userData { get; set; }

        public UserLogic()
        {
            sessionUser = new UserSession() { SessionToken = new Guid().ToString(), SessionType = Tienda.Dto.UserTypes.Guest };
            this.dataAccess = new DapperDataAccess();
        }

        public UserLogic(UserSession sessionUser, string username)
        {
            this.dataAccess = new DapperDataAccess();
            this.sessionUser = sessionUser;
            this.userData = this.DisplayUserInfo(username);

        }
        public string[] UserTryLogin(string username)
        {
            return dataAccess.UserTryLogin(username);
        }
        public string[] UserLogin(string username, string password)
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
        public bool UserSignup(User newUserData, string password, string salt)
        {
            return dataAccess.UserSignup(newUserData, password, salt);
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
        public User DisplayUserInfo(string session)
        {
            return dataAccess.DisplayUserInfo(session);
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

        public string UpdateUserPassword(string session, string storePassword, string newSalt)
        {
            return dataAccess.UpdateUserPassword(session, storePassword, newSalt);
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
