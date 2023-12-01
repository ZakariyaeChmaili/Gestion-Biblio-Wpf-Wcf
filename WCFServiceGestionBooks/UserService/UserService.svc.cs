using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceGestionBooks.DB;

namespace WCFServiceGestionBooks.UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private ZakDbEntities zakDb;

        public UserService()
        {
            zakDb = new ZakDbEntities();
            zakDb.Configuration.LazyLoadingEnabled = false;
            zakDb.Configuration.ProxyCreationEnabled = false;
        }


        public User AddUser(User user)
        {
            User u = zakDb.Users.Add(user);
            zakDb.SaveChanges();
            return u;
        }

        public User DeleteUser(int UserId)
        {
            try
            {
                User u = zakDb.Users.Remove(this.GetUser(UserId));
                zakDb.SaveChanges();
                return u;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<User> FindByName(string name)
        {
            return zakDb.Users
                .Where(u => u.Username.Contains(name) ||
                            u.FirstName.Contains(name) ||
                            u.LastName.Contains(name))
                .ToList();
        }

        public User GetUser(int id)
        {
            return zakDb.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        

        public IEnumerable<User> GetUsers()
        {
            return zakDb.Users.ToList();

        }

   

        public User Login(string username, string password)
        {
            //return zakDb.Users
            //     .Where<User>(z => z.Username == username && z.Password == password)
            //     .FirstOrDefault();

            if(username=="admin" && password=="admin")
            {
                return new User()
                {
                    Id = 0,
                    Username = "admin",
                    Password = "admin",
                    FirstName = "admin",
                    LastName = "admin"
                };
            }
            else
            {
                return null;
            }


        }


        public User Update(User user)
        {
            zakDb.Entry(user).State = System.Data.Entity.EntityState.Modified;
            zakDb.SaveChanges();
            return user;
        }
    }
}
