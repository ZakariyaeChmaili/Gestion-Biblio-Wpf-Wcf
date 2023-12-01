using Prism.Mvvm;

namespace FullApp2.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Biblio Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
