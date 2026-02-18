using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CompanyApp.Application.Services;
using CompanyApp.Domain.Entity;
using CompanyApp.Presentation.Commands;

namespace CompanyApp.Presentation.ViewModels
{
    public class LoadCompanyViewModel : ViewModelBase
    {
        private readonly CompanyService _companyService;
        private readonly UserService _userService;

        private ObservableCollection<CompanyEntity> _companies;
        public ObservableCollection<CompanyEntity> Companies
        {
            get { return _companies; }
            set { _companies = value; OnPropertyChanged(); }
        }

        private CompanyEntity _selectedCompany;
        public CompanyEntity SelectedCompany
        {
            get { return _selectedCompany; }
            set 
            { 
                _selectedCompany = value; 
                OnPropertyChanged(); 
            }
        }

        public ICommand OpenCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        public LoadCompanyViewModel()
        {
            _companyService = new CompanyService();
            _userService = new UserService();
            _companies = new ObservableCollection<CompanyEntity>(_companyService.GetAllCompanies());

            OpenCommand = new RelayCommand(OpenCompany, CanOpenCompany);
            GoBackCommand = new RelayCommand(GoBack);
        }

        private bool CanOpenCompany(object obj)
        {
            return SelectedCompany != null;
        }

        private void OpenCompany(object obj)
        {
            if (SelectedCompany == null) return;

            try
            {
                // Set global company context
                _companyService.OpenCompany(SelectedCompany.PK_Comp_Id);

                // Check if users exist in this company
                bool userExists = _userService.CheckIfUserExists(SelectedCompany.PK_Comp_Id);

                if (userExists)
                {
                    // If users exist, go to Login Page
                    Navigation?.NavigateTo<LoginViewModel>();
                }
                else
                {
                    // If NO users exist, go directly to Dashboard
                    Navigation?.NavigateTo<CompanyDashboardViewModel>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening company: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoBack(object obj)
        {
            Navigation?.NavigateTo<MainMenuViewModel>();
        }
    }
}

