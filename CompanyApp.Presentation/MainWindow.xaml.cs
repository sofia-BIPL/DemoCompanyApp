
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

namespace CompanyApp.Presentation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainMenuViewModel vm = new MainMenuViewModel();

            vm.OpenCreateCompanyRequested += OpenCreateCompanyView;
            vm.OpenLoadCompanyRequested += OpenLoadCompanyView;

            this.DataContext = vm;
        }

        private void OpenCreateCompanyView()
        {
            CreateCompanyView view = new CreateCompanyView();
            view.Show();
            this.Close();
        }

        private void OpenLoadCompanyView()
        {
            LoadCompanyView view = new LoadCompanyView();
            view.Show();
            this.Close();
        }
    }
}
