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
    public class LoadUserViewModel : INotifyPropertyChanged
    {
        private readonly UserService _userService;

        private ObservableCollection<UserEntity> _users;
        public ObservableCollection<UserEntity> Users
        {
            get { return _users; }
            set { _users = value; OnPropertyChanged(); }
        }

        private UserEntity _selectedUser;
        public UserEntity SelectedUser
        {
            get { return _selectedUser; }
            set 
            { 
                _selectedUser = value; 
                OnPropertyChanged(); 
            }
        }

        public ICommand SelectCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        public event Action RequestClose;

        public LoadUserViewModel()
        {
            _userService = new UserService();
            _users = new ObservableCollection<UserEntity>(_userService.GetAllUsers());

            SelectCommand = new RelayCommand(SelectUser, CanSelectUser);
            GoBackCommand = new RelayCommand(GoBack);
        }

        private bool CanSelectUser(object obj)
        {
            return SelectedUser != null;
        }

        private void SelectUser(object obj)
        {
            if (SelectedUser == null) return;

            try
            {
                MessageBox.Show($"Selected User: {SelectedUser.User_Name} (ID: {SelectedUser.PK_User_Id})", 
                    "User Selected", MessageBoxButton.OK, MessageBoxImage.Information);
                
                // In a real application, you might navigate to an edit form or perform other actions
                RequestClose?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting user: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoBack(object obj)
        {
            RequestClose?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
