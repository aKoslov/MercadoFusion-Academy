using System.Collections.Generic;
using Tienda.Dto;

namespace Tienda.Interfaces
{
    public interface IUserLogic
    { 
        public UserSession RetrieveSession();
        public User RetrieveUser();
        public string DontDoThisAtHome(string username);
        public List<User> ListUsers();
        public UserSession UserLogin(string username, string password);
        public bool UserSignup(User newUserData, string password);
        public User DisplayUserInfo(int userId);
        public bool UpdateUserInfo(User newUserData, string session);
        public bool ComparePassword(string username, string password);

        public string UpdateUserPassword(string session, string storePassword);
        public UserTypes ValidateUserType(string username);
        
    }
}
