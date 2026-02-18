using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CompanyApp.Application.Services;
using CompanyApp.Presentation.Commands;

namespace CompanyApp.Presentation.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly UserService _userService;

        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public LoginViewModel()
        {
            _userService = new UserService();
            
            LoginCommand = new RelayCommand(Login, CanLogin);
            CancelCommand = new RelayCommand(Cancel);
        }

        private bool CanLogin(object obj)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void Login(object obj)
        {
            try
            {
                // Using SessionGlobal.Comp_Id instead of passed argument
                string result = _userService.Authenticate(Username, Password, CompanyApp.Domain.GlobalVar.SessionGlobal.Comp_Id);

                if (result == "Success")
                {
                    MessageBox.Show("Login Successful!", "Success", MessageBoxButton.OK);
                    Navigation?.NavigateTo<CompanyDashboardViewModel>();
                }
                else
                {
                    MessageBox.Show(result, "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel(object obj)
        {
            Navigation?.NavigateTo<LoadCompanyViewModel>();
        }
    }
}

