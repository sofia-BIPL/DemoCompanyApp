using System;
using System.Windows;
using CompanyApp.Presentation.ViewModels;

namespace CompanyApp.Presentation.Views
{
    public partial class CreateAccountView : Window
    {
        private CreateAccountViewModel _viewModel;

        public CreateAccountView()
        {
            InitializeComponent();
            _viewModel = new CreateAccountViewModel();
            this.DataContext = _viewModel;
            _viewModel.RequestClose += ViewModel_RequestClose;
        }

        private void ViewModel_RequestClose()
        {
            // Close the Create Account window and return to the dashboard
            CompanyDashboardView dashboard = new CompanyDashboardView();
            dashboard.Show();
            
            this.Close();
        }
    }
}
