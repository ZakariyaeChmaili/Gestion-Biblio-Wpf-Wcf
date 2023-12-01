using FullApp2.Core;
using FullApp2.Core.Mvvm;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ServiceReference4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace FullApp2.Modules.ModuleName.ViewModels
{
    public class ViewAuthViewModel : RegionViewModelBase
    {

        private User user;
        public User User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        public ICommand SignInCommand { get; set; }
        public IUserService UserService { get; }

        public ViewAuthViewModel(
            IRegionManager regionManager,
            IUserService userService
            ):base(regionManager)
        {
            SignInCommand = new DelegateCommand(SignInMethod);
            UserService = userService;
            User = new User();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
        private void SignInMethod()
        {
            if(UserService.Login(User.Username, User.Password)==null)
            {
                System.Windows.MessageBox.Show("Wrong username or password", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return;
            }
            else
            {
                RegionManager.RequestNavigate(RegionNames.ContentRegion, "ViewHome");
                RegionManager.RequestNavigate(RegionNames.HomeContentRegion, "ViewBooks");
            }   
    
            
        }
    }
}
