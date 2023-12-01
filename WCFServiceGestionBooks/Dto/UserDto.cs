using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WCFServiceGestionBooks.DB;

namespace WCFServiceGestionBooks.Dto
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public List<Reservation> Reservations { get; set; }

        public UserDto()
        {
            
        }
        //public UserDto(User user)
        //{
        //    Id = user.Id;
        //    Username = user.Username;
        //    Password = user.Password;
        //    FirstName = user.FirstName;
        //    LastName = user.LastName;
        //    if(user.Reservations != null)
        //    {
        //        Reservations = user.Reservations.ToList();
        //    }
            
        //}



    }
}