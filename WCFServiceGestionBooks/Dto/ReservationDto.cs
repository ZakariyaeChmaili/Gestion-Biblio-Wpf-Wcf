using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WCFServiceGestionBooks.DB;

namespace WCFServiceGestionBooks.Dto
{
    [DataContract]
    public class ReservationDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int BookId { get; set; }

        [DataMember]

        public Book Book { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public User User { get; set; }
        [DataMember]
        public Nullable<System.DateTime> StartDate { get; set; }
        [DataMember]
        public Nullable<System.DateTime> EndDate { get; set; }

        public ReservationDto()
        {
            
        }
    }
}