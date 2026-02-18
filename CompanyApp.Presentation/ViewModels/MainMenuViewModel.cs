
/*
    PURPOSE OF MAIN MENU VIEW MODEL:

    This class handles UI logic of Main Menu screen.

    It binds Create Company and Load Company buttons
    to ICommand based commands.

    This ViewModel does NOT perform navigation directly.
    Instead it raises navigation events which are handled
    by the View (MainWindow.xaml.cs).

    Flow:
    Button Click → Command → ViewModel Method → Raise Event → View Navigates
*/

using System;
using System.Windows.Input;
using CompanyApp.Presentation.Commands;

namespace CompanyApp.Presentation.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        // Commands bound to buttons in View
        public ICommand CreateCompanyCommand { get; set; }
        public ICommand LoadCompanyCommand { get; set; }

        public MainMenuViewModel()
        {
            CreateCompanyCommand = new RelayCommand(OpenCreateCompany);
            LoadCompanyCommand = new RelayCommand(OpenLoadCompany);
        }

        private void OpenCreateCompany(object obj)
        {
            Navigation?.NavigateTo<CreateCompanyViewModel>();
        }

        private void OpenLoadCompany(object obj)
        {
            Navigation?.NavigateTo<LoadCompanyViewModel>();
        }
    }
}
