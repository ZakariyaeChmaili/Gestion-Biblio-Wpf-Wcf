using FullApp2.Core;
using FullApp2.Core.Mvvm;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FullApp2.Modules.ModuleName.ViewModels
{
    public class ViewHomeViewModel : RegionViewModelBase
    {
        private DelegateCommand gestionBookCommand;
        public DelegateCommand GestionBookCommand =>
            gestionBookCommand ?? (gestionBookCommand = new DelegateCommand(ExecuteGestionBookCommand));

        
        private DelegateCommand gestionUserCommand;
        public DelegateCommand GestionUserCommand =>
            gestionUserCommand ?? (gestionUserCommand = new DelegateCommand(ExecuteGestionUserCommand));


        private DelegateCommand gestionReservationCommand;
        public DelegateCommand GestionReservationCommand =>
            gestionReservationCommand ?? (gestionReservationCommand = new DelegateCommand(ExecuteGestionReservationCommand));

        private DelegateCommand logoutCommand;
        public DelegateCommand LogoutCommand =>
            logoutCommand ?? (logoutCommand = new DelegateCommand(ExecuteLogoutCommand));

        void ExecuteLogoutCommand()
        {
            RegionManager.RequestNavigate(RegionNames.ContentRegion, "ViewAuth");
        }
        void ExecuteGestionReservationCommand()
        {
            RegionManager.RequestNavigate(RegionNames.HomeContentRegion, "ViewReservations");

        }

        void ExecuteGestionUserCommand()
        {
            RegionManager.RequestNavigate(RegionNames.HomeContentRegion, "ViewUsers");

        }
        void ExecuteGestionBookCommand()
        {
            RegionManager.RequestNavigate(RegionNames.HomeContentRegion, "ViewBooks");

        }
        public ViewHomeViewModel(IRegionManager regionManager) :base(regionManager)
        {

        }


       
    }
}
