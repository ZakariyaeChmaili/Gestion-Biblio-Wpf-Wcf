using FullApp2.Core;
using FullApp2.Core.Mvvm;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using ServiceReference3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FullApp2.Modules.ModuleName.ViewModels
{
    public class ViewReservationsViewModel : RegionViewModelBase
    {
        private DelegateCommand<string> reservationFormCommand;
        public DelegateCommand<string> ReservationFormCommand =>
            reservationFormCommand ?? (reservationFormCommand = new DelegateCommand<string>(ReservationFormExecuteMethod));

        private DelegateCommand deleteCommand;
        public DelegateCommand DeleteCommand =>
            deleteCommand ?? (deleteCommand = new DelegateCommand(ExecuteDeleteCommand));

        private DelegateCommand<ReservationDto> viewReservationCommand;
        public DelegateCommand<ReservationDto> ViewReservationCommand =>
            viewReservationCommand ?? (viewReservationCommand = new DelegateCommand<ReservationDto>(ExecuteViewReservationCommand));

        void ExecuteViewReservationCommand(ReservationDto reservation)
        {
                                                       
            var parameters = new DialogParameters { { "Reservation", reservation } };

            DialogService.ShowDialog("ViewReservationDialog", parameters, null);

        }

        void ExecuteDeleteCommand()
        {

            if(SelectedItem == null)
            {
                MessageBox.Show("Please select an item first", "Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this reservation?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                ReservationService.DeleteReservation(SelectedItem.Id);
                RefreshReservations();
            }


        }

        void ReservationFormExecuteMethod(string formType)
        {

            if (SelectedItem == null)
            {
                MessageBox.Show("Please select an item first", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            NavigationParameters parameters = new NavigationParameters();
            if (formType == "Add")
            {
                RegionManager.RequestNavigate(
                    RegionNames.ContentRegion,
                    "ViewReservationForm"
                );
            }
            else
            {
                parameters.Add("Reservation", SelectedItem);
                RegionManager.RequestNavigate(
                    RegionNames.ContentRegion,
                    "ViewReservationForm",
                    parameters
                );
            }
        }

        private List<ReservationDto> reservations;

        public List<ReservationDto> Reservations
        {
            get { return reservations; }
            set { SetProperty(ref reservations, value); }
        }

        public IReservationService ReservationService { get; }
        public IDialogService DialogService { get; }

        private ReservationDto selectedItem;
        public ReservationDto SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty(ref selectedItem, value); }
        }

        public ViewReservationsViewModel(IRegionManager regionManager,
            IReservationService reservationService,
            IDialogService dialogService
            ) : base(regionManager)
        {
            ReservationService = reservationService;
            DialogService = dialogService;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            RefreshReservations();
        }

        public void RefreshReservations()
        {
            Reservations = ReservationService.GetReservations().ToList();
        }
    }

}
