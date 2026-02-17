using System;
using System.Windows;
using CompanyApp.Presentation.ViewModels;

namespace CompanyApp.Presentation.Views
{
    public partial class LoadCompanyView : Window
    {
        private LoadCompanyViewModel _viewModel;

        public LoadCompanyView()
        {
            InitializeComponent();
            _viewModel = new LoadCompanyViewModel();
            this.DataContext = _viewModel;
            
            // Event Subscriptions
            _viewModel.RequestClose += ViewModel_RequestClose;
            _viewModel.OpenCompanyDashboardRequested += ViewModel_OpenDashboard;
            _viewModel.OpenLoginRequested += ViewModel_OpenLogin;
        }


        private void ViewModel_RequestClose()
        {
            // By default, if we just close, we go nowhere.
            // We should check if we should go back to Main Menu.
            // Let's assume GoBack triggers this strictly for navigation back.
            
           MainWindow mainMenu = new MainWindow();
           mainMenu.Show();
           
           this.Close();
        }

        private void ViewModel_OpenDashboard(int companyId)
        {
            CompanyDashboardView dashboard = new CompanyDashboardView();
            dashboard.Show();
            
            this.Close();
        }

        private void ViewModel_OpenLogin(int companyId)
        {
            LoginView login = new LoginView(companyId);
            login.Show();
            
            this.Close();
        }
    }
}
