using FullApp2.Core;
using FullApp2.Core.Mvvm;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ServiceReference4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullApp2.Modules.ModuleName.ViewModels
{
    public class ViewUserFormViewModel : RegionViewModelBase
    {
        private string saveType;
        public string SaveType
        {
            get { return saveType; }
            set { SetProperty(ref saveType, value); }
        }

        private DelegateCommand cancelCommand;
        public DelegateCommand CancelCommand =>
            cancelCommand ?? (cancelCommand = new DelegateCommand(ExecuteCancelCommand));

        private DelegateCommand<string> saveCommand;
        public DelegateCommand<string> SaveCommand =>
            saveCommand ?? (saveCommand = new DelegateCommand<string>(ExecuteSaveCommand));

         void  ExecuteSaveCommand(string saveType)
        {
            if (saveType == "Add")
                UserService.AddUser(User);
            else
                UserService.Update(User);
            //Task.Run(async () => await ViewUsersViewModel.RefreshUsersAsync()).Wait();
             ViewUsersViewModel.RefreshUsers();
            RegionManager.RequestNavigate(RegionNames.ContentRegion, "ViewHome");
        }
        void ExecuteCancelCommand()
        {
            RegionManager.RequestNavigate(RegionNames.ContentRegion, "ViewHome");

        }
    
        private User user;
        public User User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        public IUserService UserService { get; }
        public ViewUsersViewModel ViewUsersViewModel { get; }

        public ViewUserFormViewModel(IRegionManager regionManager,
            IUserService userService,
            ViewUsersViewModel viewUsersViewModel
            ) 
            : base(regionManager)
        {
            UserService = userService;
            ViewUsersViewModel = viewUsersViewModel;
        }


        override public void OnNavigatedTo(NavigationContext navigationContext)
        {

            if (navigationContext.Parameters.ContainsKey("User"))
            {
                User = navigationContext.Parameters.GetValue<User>("User");
                SaveType = "Update";
            }
            else
            {
                User = new User();
                SaveType = "Add";
            }
        }
    }
}
