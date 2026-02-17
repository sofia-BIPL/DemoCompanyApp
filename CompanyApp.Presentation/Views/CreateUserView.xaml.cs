using System;
using System.Windows;
using CompanyApp.Presentation.ViewModels;

namespace CompanyApp.Presentation.Views
{
    public partial class CreateUserView : Window
    {
        private CreateUserViewModel _viewModel;

        public CreateUserView()
        {
            InitializeComponent();
            _viewModel = new CreateUserViewModel();
            this.DataContext = _viewModel;
            _viewModel.RequestClose += ViewModel_RequestClose;
        }

        private void ViewModel_RequestClose()
        {
            // Close the Create User window and return to the dashboard
            CompanyDashboardView dashboard = new CompanyDashboardView();
            dashboard.Show();
            
            this.Close();
        }
    }
}
