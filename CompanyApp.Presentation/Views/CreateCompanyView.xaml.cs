using System.Windows;
using CompanyApp.Presentation.ViewModels;
using CompanyApp.Presentation;

namespace CompanyApp.Presentation.Views
{
    /// <summary>
    /// Interaction logic for CreateCompanyView.xaml
    /// </summary>
    public partial class CreateCompanyView : Window
    {
        private CreateCompanyViewModel _viewModel;

        public CreateCompanyView()
        {
            InitializeComponent();
            _viewModel = new CreateCompanyViewModel();
            this.DataContext = _viewModel;

            // Subscribe to close event
            _viewModel.RequestClose += ViewModel_RequestClose;
        }

        private void ViewModel_RequestClose()
        {
            // Open Main Menu again
            MainWindow mainMenu = new MainWindow();
            mainMenu.Show();

            this.Close();
        }
    }
}
