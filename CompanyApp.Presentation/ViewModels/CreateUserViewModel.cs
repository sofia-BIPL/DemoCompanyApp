using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CompanyApp.Application.Services;
using CompanyApp.Domain.DTO;
using CompanyApp.Presentation.Commands;

namespace CompanyApp.Presentation.ViewModels
{
    public class CreateUserViewModel : ViewModelBase
    {
        private readonly UserService _userService;

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(); }
        }

        private string _userPassword;
        public string UserPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public CreateUserViewModel()
        {
            _userService = new UserService();
            SaveCommand = new RelayCommand(SaveUser, CanSave);
            CancelCommand = new RelayCommand(Cancel);
        }

        private bool CanSave(object obj)
        {
            return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(UserPassword);
        }

        private void SaveUser(object obj)
        {
            try
            {
                // Check if username already exists for this company
                if (_userService.CheckIfUsernameExists(UserName))
                {
                    MessageBox.Show(
                        $"Username '{UserName}' already exists!\n\nPlease choose a different username.",
                        "Duplicate Username",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return; // Stop execution, don't save
                }

                var dto = new UserDTO
                {
                    User_Name = UserName,
                    User_Password = UserPassword
                };

                _userService.SaveUser(dto);

                MessageBox.Show("User Created Successfully!", "Success", MessageBoxButton.OK);
                Navigation?.NavigateTo<CompanyDashboardViewModel>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating user: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel(object obj)
        {
            Navigation?.NavigateTo<CompanyDashboardViewModel>();
        }
    }
}

