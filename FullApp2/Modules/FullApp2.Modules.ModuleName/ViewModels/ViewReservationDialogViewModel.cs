using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using ServiceReference3;
using System;

namespace FullApp2.Modules.ModuleName.ViewModels
{
    public class ViewReservationDialogViewModel : BindableBase, IDialogAware
    {
        private ReservationDto reservation;

        public event Action<IDialogResult> RequestClose;

        public ReservationDto Reservation
        {
            get { return reservation; }
            set { SetProperty(ref reservation, value); }
        }

        public string Title => "Reservation Details";

        public DelegateCommand CloseCommand { get; private set; }

        public ViewReservationDialogViewModel()
        {
            CloseCommand = new DelegateCommand(ExecuteCloseCommand);
        }

        private void ExecuteCloseCommand()
        {
            var result = ButtonResult.OK; // You can customize this based on your requirements
            RaiseRequestClose(new DialogResult(result));
        }

        protected virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public bool CanCloseDialog()
        {
            return true; // Implement any logic if needed
        }

        public void OnDialogClosed()
        {
            // Clean up or perform actions when the dialog is closed
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("Reservation"))
            {
                Reservation = parameters.GetValue<ReservationDto>("Reservation");
            }
        }
    }
}
