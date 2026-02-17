using System;
using System.Windows;
using System.Windows.Controls;
using CompanyApp.Presentation.ViewModels;

namespace CompanyApp.Presentation.Views
{
    public partial class LoginView : Window
    {
        private LoginViewModel _viewModel;

        public LoginView(int companyId)
        {
            InitializeComponent();
            _viewModel = new LoginViewModel(companyId);
            this.DataContext = _viewModel;
            
            _viewModel.RequestClose += ViewModel_RequestClose;
            _viewModel.LoginSuccessful += ViewModel_LoginSuccessful;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Bind PasswordBox value to ViewModel
            if (this.DataContext != null)
            {
                _viewModel.Password = ((PasswordBox)sender).Password;
            }
        }

        private void ViewModel_RequestClose()
        {
            // Return to company selection
            LoadCompanyView loadCompanyView = new LoadCompanyView();
            loadCompanyView.Show();
            
            this.Close();
        }

        private void ViewModel_LoginSuccessful()
        {
            // Navigate to Dashboard after successful login
            CompanyDashboardView dashboard = new CompanyDashboardView();
            dashboard.Show();
            
            this.Close();
        }
    }
}
