using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceGestionBooks.DB;
using WCFServiceGestionBooks.Dto;

namespace WCFServiceGestionBooks.ReservationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReservationService" in both code and config file together.
    [ServiceContract]
    public interface IReservationService
    {
        [OperationContract]
        IEnumerable<ReservationDto> GetReservations();

        [OperationContract]
        void DeleteReservation(int ReservationId);

        [OperationContract]
        void AddReservation(ReservationDto reservation);

        [OperationContract]
        void UpdateReservation(ReservationDto reservation);

        [OperationContract]
        ReservationDto GetReservation(int ReservationId);
        
    }
}
