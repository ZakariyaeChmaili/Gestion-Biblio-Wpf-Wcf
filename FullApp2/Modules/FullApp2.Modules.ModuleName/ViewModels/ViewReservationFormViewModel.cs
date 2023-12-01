using FullApp2.Core;
using FullApp2.Core.Mvvm;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
//using ServiceReference4;
using ServiceReference3;


//using ServiceReference1;
//using ServiceReference3;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace FullApp2.Modules.ModuleName.ViewModels
{
    public class ViewReservationFormViewModel : RegionViewModelBase
    {
        private string saveType;
        public string SaveType
        {
            get { return saveType; }
            set { SetProperty(ref saveType, value); }
        }

        private ServiceReference3.ReservationDto selectedReservation;
        public ServiceReference3.ReservationDto SelectedReservation
        {
            get { return selectedReservation; }
            set { SetProperty(ref selectedReservation, value); }
        }


        private ServiceReference4.User selectedUser;
        public ServiceReference4.User SelectedUser
        {
            get { return selectedUser; }
            set { SetProperty(ref selectedUser, value); }
        }

        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set { SetProperty(ref startDate, value); }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set { SetProperty(ref endDate, value); }
        }


        private ServiceReference4.User[] users;
        public ServiceReference4.User[] Users
        {
            get { return users; }
            set { SetProperty(ref users, value); }
        }


        private DelegateCommand reserveCommand;
        public DelegateCommand ReserveCommand =>
            reserveCommand ?? (reserveCommand = new DelegateCommand(ExecuteReserveCommand));


        private DelegateCommand cancelCommand;
        public DelegateCommand CancelCommand =>
            cancelCommand ?? (cancelCommand = new DelegateCommand(ExecuteCancelCommand));

        void ExecuteCancelCommand()
        {
            RegionManager.RequestNavigate(RegionNames.ContentRegion, "ViewHome");
        }
        void ExecuteReserveCommand()
        {
            SelectedReservation.UserId = SelectedUser.Id;

            if (SaveType == "Add")
            {

                ReservationService.AddReservation(SelectedReservation);
            }
            else
            {
                ReservationService.UpdateReservation(SelectedReservation);
            }
            ViewBooksViewModel.RefreshBooks();
            ViewReservationsViewModel.RefreshReservations();
            RegionManager.RequestNavigate(RegionNames.ContentRegion, "ViewHome");

        }




        public ServiceReference4.IUserService UserService { get; }
        public IReservationService ReservationService { get; }
        public ViewBooksViewModel ViewBooksViewModel { get; }
        public ViewReservationsViewModel ViewReservationsViewModel { get; }

        public ViewReservationFormViewModel(IRegionManager regionManager,
            ServiceReference4.IUserService userService,
            IReservationService reservationService,
            ViewBooksViewModel viewBooksViewModel,
            ViewReservationsViewModel viewReservationsViewModel
            
            ) : base(regionManager)
        {
            UserService = userService;
            ReservationService = reservationService;
            ViewBooksViewModel = viewBooksViewModel;
            ViewReservationsViewModel = viewReservationsViewModel;
        }


        public override void OnNavigatedTo(NavigationContext navigationContext) 
        {
            Users = UserService.GetUsers();

            if (navigationContext.Parameters.ContainsKey("Reservation"))
            {
                SaveType = "Update";
                SelectedReservation = navigationContext.Parameters.GetValue<ServiceReference3.ReservationDto>("Reservation");
                SelectedUser = Users.Where(u => u.Id == SelectedReservation.UserId).FirstOrDefault();
            }
            else
            {
                SaveType = "Add";
                SelectedUser = new ServiceReference4.User();
                ServiceReference3.ReservationDto r = new ServiceReference3.ReservationDto();
                ServiceReference1.Book book = navigationContext.Parameters.GetValue<ServiceReference1.Book>("Book");
                r.BookId = book.Id;
                //SelectedReservation.Book.Title = book.Title;
                r.Book = new Book()
                {
                    Author = book.Author,
                    Copies = book.Copies,
                    Id = book.Id,
                    Title = book.Title

                };
                selectedUser = new ServiceReference4.User();

                SelectedReservation = r;
            }
        }
    }   
}
