using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceGestionBooks.DB;
using WCFServiceGestionBooks.Dto;

namespace WCFServiceGestionBooks.ReservationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReservationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Cli
    // ent for testing this service, please select ReservationService.svc or ReservationService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]

    public class ReservationService : IReservationService
    {
        private ZakDbEntities zakDb;

        public ReservationService()
        {
            zakDb = new ZakDbEntities();
            zakDb.Configuration.LazyLoadingEnabled = false;
            zakDb.Configuration.ProxyCreationEnabled = false;
        }

        public void AddReservation(ReservationDto reservationDto)
        {
            Book book = zakDb.Books.Where<Book>(b => b.Id == reservationDto.BookId).FirstOrDefault();
            if (book.Copies > 0)
            {
                zakDb.Reservations.Add(
                    new Reservation()
                    {
                        UserId = reservationDto.UserId,
                        BookId = reservationDto.BookId,
                        StartDate = reservationDto.StartDate,
                        EndDate = reservationDto.EndDate
                    }
                     );
                book.Copies--;
                zakDb.SaveChanges();

            }



        }



        public void DeleteReservation(int reservationId)
        {
            Reservation reservationToDelete = zakDb.Reservations
                .FirstOrDefault(r => r.Id == reservationId);
            if (reservationToDelete != null)
            {
                zakDb.Reservations.Remove(reservationToDelete);
                zakDb.SaveChanges();
            }
        }

        public ReservationDto GetReservation(int reservationId)
        {
            ReservationDto reservationDto = zakDb.Reservations
                .Where(r => r.Id == reservationId)
                .Select(re => new ReservationDto()
                {
                    Id = re.Id,
                    BookId = re.BookId,
                    UserId = re.UserId,
                    StartDate = re.StartDate,
                    EndDate = re.EndDate,
                    Book = zakDb.Books.Where(b => b.Id == re.BookId).FirstOrDefault(),
                    User = zakDb.Users.Where(u => u.Id == re.UserId).FirstOrDefault()
                }).FirstOrDefault();

            return reservationDto;

        }

        public IEnumerable<ReservationDto> GetReservations()
        {
            return zakDb.Reservations.Select(r =>
            new ReservationDto()
            {
                Id = r.Id,
                BookId = r.BookId,
                UserId = r.UserId,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                Book = zakDb.Books.Where(b => b.Id == r.BookId).FirstOrDefault(),
                User = zakDb.Users.Where(u => u.Id == r.UserId).FirstOrDefault()
            });




        }


        public void UpdateReservation(ReservationDto reservationDto)
        {
            Reservation reservation = zakDb.Reservations.Where(r => r.Id == reservationDto.Id).FirstOrDefault();
            reservation.StartDate = reservationDto.StartDate;
            reservation.EndDate = reservationDto.EndDate;
            reservation.BookId = reservationDto.BookId;
            reservation.UserId = reservationDto.UserId;

            zakDb.Entry(reservation).State = EntityState.Modified;
            zakDb.SaveChanges();
        }
    }

}
