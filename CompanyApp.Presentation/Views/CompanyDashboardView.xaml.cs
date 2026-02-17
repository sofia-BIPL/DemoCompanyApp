using System;
using System.Windows;
using CompanyApp.Presentation.ViewModels;

namespace CompanyApp.Presentation.Views
{
    public partial class CompanyDashboardView : Window
    {
        private CompanyDashboardViewModel _viewModel;

        public CompanyDashboardView()
        {
            InitializeComponent();
            _viewModel = new CompanyDashboardViewModel();
            this.DataContext = _viewModel;
            
            // Event Subscriptions
            _viewModel.RequestCloseCompany += ViewModel_RequestCloseCompany;
            _viewModel.RequestCreateAccount += ViewModel_RequestCreateAccount;
            _viewModel.RequestCreateUser += ViewModel_RequestCreateUser;
            _viewModel.RequestLoadAccount += ViewModel_RequestLoadAccount;
            _viewModel.RequestLoadUser += ViewModel_RequestLoadUser;
        }

        private void ViewModel_RequestCloseCompany()
        {
            // Go back to the list of companies
            LoadCompanyView loadCompanyView = new LoadCompanyView();
            loadCompanyView.Show();
            
            this.Close();
        }

        private void ViewModel_RequestCreateUser()
        {
            CreateUserView view = new CreateUserView();
            view.Show();
            
            this.Close();
        }

        private void ViewModel_RequestCreateAccount()
        {
            CreateAccountView view = new CreateAccountView();
            view.Show();
            
            this.Close();
        }

        private void ViewModel_RequestLoadUser()
        {
            LoadUserView view = new LoadUserView();
            view.Show();
            
            this.Close();
        }

        private void ViewModel_RequestLoadAccount()
        {
            LoadAccountView view = new LoadAccountView();
            view.Show();
            
            this.Close();
        }

        private void ViewModel_Placeholder()
        {
            MessageBox.Show("This functionality is not yet implemented.", "Coming Soon");
        }
    }
}
