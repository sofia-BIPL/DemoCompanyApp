using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CompanyApp.Application.Services;
using CompanyApp.Domain.GlobalVar;
using CompanyApp.Presentation.Commands;

namespace CompanyApp.Presentation.ViewModels
{
    public class CompanyDashboardViewModel : ViewModelBase
    {
        private readonly CompanyService _companyService;
        private string _companyTitle;

        public string CompanyTitle
        {
            get { return _companyTitle; }
            set { _companyTitle = value; OnPropertyChanged(); }
        }

        public ICommand CreateAccountCommand { get; set; }
        public ICommand CreateUserCommand { get; set; }
        public ICommand LoadAccountCommand { get; set; }
        public ICommand LoadUserCommand { get; set; }
        public ICommand CloseCompanyCommand { get; set; }

        public CompanyDashboardViewModel()
        {
            _companyService = new CompanyService();
            
            // Set Title
            CompanyTitle = $"Company Dashboard (ID: {SessionGlobal.Comp_Id})"; 

            CreateAccountCommand = new RelayCommand(ExecuteCreateAccount);
            CreateUserCommand = new RelayCommand(ExecuteCreateUser);
            LoadAccountCommand = new RelayCommand(ExecuteLoadAccount);
            LoadUserCommand = new RelayCommand(ExecuteLoadUser);
            CloseCompanyCommand = new RelayCommand(ExecuteCloseCompany);
        }

        private void ExecuteCreateAccount(object obj)
        {
            Navigation?.NavigateTo<CreateAccountViewModel>();
        }

        private void ExecuteCreateUser(object obj)
        {
            Navigation?.NavigateTo<CreateUserViewModel>();
        }

        private void ExecuteLoadAccount(object obj)
        {
            Navigation?.NavigateTo<LoadAccountViewModel>();
        }

        private void ExecuteLoadUser(object obj)
        {
            Navigation?.NavigateTo<LoadUserViewModel>();
        }

        private void ExecuteCloseCompany(object obj)
        {
            try
            {
                _companyService.CloseCompany();
                Navigation?.NavigateTo<MainMenuViewModel>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error closing company: {ex.Message}", "Error");
            }
        }
    }
}

