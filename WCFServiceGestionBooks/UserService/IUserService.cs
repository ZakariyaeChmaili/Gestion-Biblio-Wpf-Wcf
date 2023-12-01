using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceGestionBooks.DB;

namespace WCFServiceGestionBooks.UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User Login(string username, string password);

        [OperationContract]
        User AddUser(User user);



        [OperationContract]
        User DeleteUser(int UserId);

        [OperationContract]
        IEnumerable<User> GetUsers();

        [OperationContract]
        IEnumerable<User> FindByName(string name);

        [OperationContract]
         User Update(User user);

        [OperationContract]
        User GetUser(int id);

    }
}
