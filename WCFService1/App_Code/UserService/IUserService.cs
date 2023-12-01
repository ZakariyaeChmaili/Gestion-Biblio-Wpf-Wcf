using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;



    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User Login(string username, string password);

        [OperationContract]
        User AddUser(User user);



        [OperationContract]
        User DeleteUser(User user);

        [OperationContract]
        IEnumerable<User> GetUsers();

        [OperationContract]
        IEnumerable<User> findByUsername(string username);
    }
