
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
    public class MainMenuViewModel
    {
        // Commands bound to buttons in View
        public ICommand CreateCompanyCommand { get; set; }
        public ICommand LoadCompanyCommand { get; set; }

        // Navigation events (View will subscribe to these)
        public event Action OpenCreateCompanyRequested;
        public event Action OpenLoadCompanyRequested;

        public MainMenuViewModel()
        {
            CreateCompanyCommand = new RelayCommand(OpenCreateCompany);
            LoadCompanyCommand = new RelayCommand(OpenLoadCompany);
        }

        private void OpenCreateCompany(object obj)
        {
            OpenCreateCompanyRequested?.Invoke();
        }

        private void OpenLoadCompany(object obj)
        {
            OpenLoadCompanyRequested?.Invoke();
        }
    }
}
