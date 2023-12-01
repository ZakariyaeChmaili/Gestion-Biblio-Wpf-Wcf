using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserService
/// </summary>


    public class UserService : IUserService
    {

        private ZakDbEntities zakDb;

        public UserService()
        {
            zakDb = new ZakDbEntities();
        }


        public User AddUser(User user)
        {
            User u = zakDb.Users.Add(user);
            zakDb.SaveChanges();
            return u;
        }

        public User DeleteUser(User user)
        {
            User u = zakDb.Users.Remove(user);
            zakDb.SaveChanges();
            return u;
        }

        public IEnumerable<User> findByUsername(string username)
        {
            List<User> users = zakDb
                .Users
                .Where<User>(z =>
                z.Username.Contains(username)
                ).ToList();

            return users;
        }

        public IEnumerable<User> GetUsers()
        {
            return zakDb.Users.ToList();
        }

        public User Login(string username, string password)
        {
            return zakDb.Users
                 .Where<User>(z => z.Username == username && z.Password == password)
                 .FirstOrDefault();


        }
    }

