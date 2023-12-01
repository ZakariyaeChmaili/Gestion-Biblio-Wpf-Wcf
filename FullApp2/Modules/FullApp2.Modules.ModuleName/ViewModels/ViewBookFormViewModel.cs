using FullApp2.Core;
using FullApp2.Core.Mvvm;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FullApp2.Modules.ModuleName.ViewModels
{
    public class ViewBookFormViewModel : RegionViewModelBase
    {

        private Book book;
        public Book Book
        {
            get { return book; }
            set { SetProperty(ref book, value); }
        }

            private string saveType;
            public string SaveType
            {
                get { return saveType; }
                set { SetProperty(ref saveType, value); }
            }


        private DelegateCommand<string> _saveCommand;
        public DelegateCommand<string> SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand<string>(ExecuteSaveCommand));

        private DelegateCommand _cancelCommand;
        public DelegateCommand CancelCommand =>
            _cancelCommand ?? (_cancelCommand = new DelegateCommand(ExecuteCancelCommand));

        public IBookService BookService { get; }
        public ViewBooksViewModel ViewBooksViewModel { get; }

        void ExecuteCancelCommand()
        {
            RegionManager.RequestNavigate(RegionNames.ContentRegion, "ViewHome");

        }
        void ExecuteSaveCommand(string type)
        {
            if (type == "Add") 
                BookService.AddBook(Book);



            else
            
                BookService.UpdateBook(Book);
            
            ViewBooksViewModel.RefreshBooks();

            RegionManager.RequestNavigate(RegionNames.ContentRegion, "ViewHome");
        }
        public ViewBookFormViewModel(IRegionManager regionManager,
            IBookService bookService,
            ViewBooksViewModel viewBooksViewModel

            )
            : base(regionManager)
        {
            BookService = bookService;
            ViewBooksViewModel = viewBooksViewModel;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("Book"))
            {
                SaveType = "Update";
                Book = navigationContext.Parameters.GetValue<Book>("Book");
            }
            else
            {
                SaveType = "Add";
                Book = new Book();
            }
        }
    }


}
