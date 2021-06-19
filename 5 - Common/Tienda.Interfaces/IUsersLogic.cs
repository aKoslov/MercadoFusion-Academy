using System.Collections.Generic;
using Tienda.Dto;

namespace Tienda.Interfaces
{
    public interface IUsersLogic
    {
        //public UserSession NewUserSession();
        public UserSession RetrieveSession();
        public User RetrieveUser();
        public string DontDoThisAtHome(string username);
        public List<User> ListUsers();
        //public User NewUser();
        //public User RetrieveUser();
        public string[] UserTryLogin(string username);
        public string[] UserLogin(string username, string password);
        public bool UserSignup(User newUserData, string password, string salt);
        public User DisplayUserInfo(string username);
        public bool UpdateUserInfo(User newUserData, string session);
        public bool ComparePassword(string username, string password);

        public string UpdateUserPassword(string session, string storePassword, string newSalt);
        public UserTypes ValidateUserType(string username);
        //public string ComputeHash(byte[] bytesToHash, byte[] salt);
        //public string NewSalt();
        
    }
}
