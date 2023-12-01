using FullApp2.Core;
using FullApp2.Core.Mvvm;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;

namespace FullApp2.Modules.ModuleName.ViewModels;

public class ViewBooksViewModel : RegionViewModelBase
{

    private DelegateCommand<string> bookFormCommand;
    public DelegateCommand<string> BookFormCommand =>
        bookFormCommand ?? (bookFormCommand = new DelegateCommand<string>(BookFormExecuteMethod));

    private DelegateCommand deleteCommand;
    public DelegateCommand DeleteCommand =>
        deleteCommand ?? (deleteCommand = new DelegateCommand(ExecuteDeleteCommand));

    private DelegateCommand<Book> reservationFormCommand;
    public DelegateCommand<Book> ReservationFormCommand =>
        reservationFormCommand ?? (reservationFormCommand = new DelegateCommand<Book>(ExecuteReservationFormCommand,CanExecuteReservationFormCommand));




    private bool CanExecuteReservationFormCommand(Book book)
    {
        if(book.Copies==0)
        {
            return false;
        }
        else
        {
            return true;
        }   
    }

    void ExecuteReservationFormCommand(Book book )
    {
 
        NavigationParameters parameters = new NavigationParameters();
        parameters.Add("Book", book);
        RegionManager.RequestNavigate(
                  RegionNames.ContentRegion,
                        "ViewReservationForm",
                              parameters

                                    );
    }



    void ExecuteDeleteCommand()
    {
        if (SelectedItem == null)
        {
            MessageBox.Show("Please select an item first", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        MessageBoxResult res = MessageBox.Show("Are you sure you want to delete this book?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (res == MessageBoxResult.Yes)
        {
            if (BookService.DeleteBook(SelectedItem.Id) != null)
                RefreshBooks();
            else
            {
                MessageBox.Show("Book is reserved, you can't delete it unless you delete the reservation concerning this book",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error
                    );
            }
        }

      
   
    }

    void BookFormExecuteMethod(string FormType)
    {
     
        NavigationParameters parameters = new NavigationParameters();
        if (FormType == "Add")
        {
            RegionManager.RequestNavigate(
            RegionNames.ContentRegion,
            "ViewBookForm"
            );
        }
        else
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Please select an item first", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            parameters.Add("Book", SelectedItem);
            RegionManager.RequestNavigate(
           RegionNames.ContentRegion,
           "ViewBookForm",
           parameters

           );
        }

    }
    private List<Book> books;

    public List<Book> Books
    {
        get { return books; }
        set { SetProperty(ref books, value); }
    }

    public IBookService BookService { get; }


    private Book selectedItem;
    public Book SelectedItem
    {
        get { return selectedItem; }
        set { SetProperty(ref selectedItem, value); }
    }

    public ViewBooksViewModel(IRegionManager regionManager, IBookService bookService) : base(regionManager)
    {
        BookService = bookService;;
    }
    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        RefreshBooks();

    }


    public void RefreshBooks()
    {
        Books = BookService.GetBooks().ToList();
    }
}

