using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

/// <summary>
/// Summary description for IUserService
/// </summary>


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

