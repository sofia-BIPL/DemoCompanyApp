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
    public class CompanyDashboardViewModel : INotifyPropertyChanged
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

        // Navigation Events
        public event Action RequestCreateAccount;
        public event Action RequestCreateUser;
        public event Action RequestLoadAccount;
        public event Action RequestLoadUser;
        public event Action RequestCloseCompany;

        public CompanyDashboardViewModel()
        {
            _companyService = new CompanyService();
            
            // Set Title
            CompanyTitle = $"Company Dashboard (ID: {SessionGlobal.Comp_Id})"; 
            // Ideally we would fetch the company name here using the ID, but for now ID is sufficient to show context.

            CreateAccountCommand = new RelayCommand(ExecuteCreateAccount);
            CreateUserCommand = new RelayCommand(ExecuteCreateUser);
            LoadAccountCommand = new RelayCommand(ExecuteLoadAccount);
            LoadUserCommand = new RelayCommand(ExecuteLoadUser);
            CloseCompanyCommand = new RelayCommand(ExecuteCloseCompany);
        }

        private void ExecuteCreateAccount(object obj)
        {
            RequestCreateAccount?.Invoke();
        }

        private void ExecuteCreateUser(object obj)
        {
            RequestCreateUser?.Invoke();
        }

        private void ExecuteLoadAccount(object obj)
        {
            RequestLoadAccount?.Invoke();
        }

        private void ExecuteLoadUser(object obj)
        {
            RequestLoadUser?.Invoke();
        }

        private void ExecuteCloseCompany(object obj)
        {
            try
            {
                _companyService.CloseCompany();
                RequestCloseCompany?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error closing company: {ex.Message}", "Error");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
