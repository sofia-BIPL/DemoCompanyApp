using System;
using System.Windows;
using CompanyApp.Presentation.ViewModels;

namespace CompanyApp.Presentation.Views
{
    public partial class LoadUserView : Window
    {
        private LoadUserViewModel _viewModel;

        public LoadUserView()
        {
            InitializeComponent();
            _viewModel = new LoadUserViewModel();
            this.DataContext = _viewModel;
            _viewModel.RequestClose += ViewModel_RequestClose;
        }

        private void ViewModel_RequestClose()
        {
            // Return to the dashboard
            CompanyDashboardView dashboard = new CompanyDashboardView();
            dashboard.Show();
            
            this.Close();
        }
    }
}
