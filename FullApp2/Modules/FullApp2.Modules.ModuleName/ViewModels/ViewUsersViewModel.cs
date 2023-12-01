using FullApp2.Core;
using FullApp2.Core.Mvvm;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ServiceReference1;
using ServiceReference4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FullApp2.Modules.ModuleName.ViewModels
{
    public class ViewUsersViewModel : RegionViewModelBase
    {

        private ServiceReference4.User selectedItem;
        public ServiceReference4.User SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty(ref selectedItem, value); }
        }

        private DelegateCommand<string> userFormCommand;
        public DelegateCommand<string> UserFormCommand =>
            userFormCommand ?? (userFormCommand = new DelegateCommand<string>(ExecuteUserFormCommand));


        private DelegateCommand deleteCommand;
        public DelegateCommand DeleteCommand =>
            deleteCommand ?? (deleteCommand = new DelegateCommand(ExecuteDeleteCommand));

        void ExecuteDeleteCommand()
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Please select an item first", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this User?", "Confirmation", MessageBoxButton.YesNo,MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                if(UserService.DeleteUser(SelectedItem.Id)!=null)
                RefreshUsers();
                else
                {
                    MessageBox.Show("The user has a reservation cannot be deleted, Delete the concerning reservation first",
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error
                        );
                }
            }
        }

        void ExecuteUserFormCommand(string Formtype)
        {
          
            NavigationParameters parameters = new NavigationParameters();
            if (Formtype == "Add")
            {
                RegionManager.RequestNavigate(
                RegionNames.ContentRegion,
                "ViewUserForm"
                );
            }
            else
            {
                if (SelectedItem == null)
                {
                    MessageBox.Show("Please select an item first", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                parameters.Add("User", SelectedItem);
                RegionManager.RequestNavigate(
               RegionNames.ContentRegion,
               "ViewUserForm",
               parameters

               );
            }
        }


        private ServiceReference4.User[] users;
        public ServiceReference4.User[] Users
        {
            get { return users; }
            set { SetProperty(ref users, value); }
        }

        public IUserService UserService { get; }

        public ViewUsersViewModel(IRegionManager regionManager,
            IUserService userService


            ) : base(regionManager)
        {
            UserService = userService;
        }


        override public void OnNavigatedTo(NavigationContext navigationContext)
        {
            RefreshUsers();
        }

        public void RefreshUsers()
        {
            Users = UserService.GetUsers();
        }
    }
}
