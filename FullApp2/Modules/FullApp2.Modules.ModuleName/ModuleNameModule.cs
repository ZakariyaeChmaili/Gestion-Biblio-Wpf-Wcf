using FullApp2.Core;
using FullApp2.Modules.ModuleName.ViewModels;
using FullApp2.Modules.ModuleName.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ServiceReference1;
using ServiceReference4;
using ServiceReference3;
using System.Windows.Controls;
using Prism.Services.Dialogs;



namespace FullApp2.Modules.ModuleName
{
    public class ModuleNameModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleNameModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "ViewAuth");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewAuth>();
            containerRegistry.RegisterForNavigation<ViewHome>();
            containerRegistry.RegisterForNavigation<ViewBooks>();
            containerRegistry.RegisterForNavigation<ViewUsers>();
            containerRegistry.RegisterForNavigation<ViewBookForm>();
            containerRegistry.RegisterForNavigation<ViewUserForm>();
            containerRegistry.RegisterForNavigation<ViewReservations>();
            containerRegistry.RegisterForNavigation<ViewReservationForm>();
            containerRegistry.RegisterForNavigation<ViewReservationDialog>();

            containerRegistry.RegisterSingleton<IBookService,BookServiceClient>();
            containerRegistry.RegisterSingleton<IUserService, UserServiceClient>();
            containerRegistry.RegisterSingleton<IReservationService, ReservationServiceClient>();
            containerRegistry.Register<IDialogService, DialogService>();



            containerRegistry.RegisterSingleton(typeof(ViewBooksViewModel));
            containerRegistry.RegisterSingleton(typeof(ViewUsersViewModel));
            containerRegistry.RegisterSingleton(typeof(ViewReservationsViewModel));

        }
    }
}