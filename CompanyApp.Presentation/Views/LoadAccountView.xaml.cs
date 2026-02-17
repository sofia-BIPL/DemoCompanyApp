using System;
using System.Windows;
using CompanyApp.Presentation.ViewModels;

namespace CompanyApp.Presentation.Views
{
    public partial class LoadAccountView : Window
    {
        private LoadAccountViewModel _viewModel;

        public LoadAccountView()
        {
            InitializeComponent();
            _viewModel = new LoadAccountViewModel();
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
