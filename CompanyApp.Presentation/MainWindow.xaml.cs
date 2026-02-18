
/*
    PURPOSE OF MAIN WINDOW CODE BEHIND:

    This class handles navigation requests raised by MainMenuViewModel.

    ViewModel does NOT open Views directly.
    It raises navigation events.

    This View subscribes to those events and performs navigation.

    Flow:
    Button Click → Command → ViewModel raises event → View handles event → Opens new View
*/

using System.Windows;
using CompanyApp.Presentation.ViewModels;
using CompanyApp.Presentation.Views;
using CompanyApp.Presentation.Navigation;

namespace CompanyApp.Presentation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            INavigationService navigationService = new NavigationService();
            this.DataContext = new MainViewModel(navigationService);
        }
    }
}
