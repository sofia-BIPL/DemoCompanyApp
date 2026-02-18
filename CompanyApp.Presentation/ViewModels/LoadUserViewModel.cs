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
    public class LoadUserViewModel : ViewModelBase
    {
        private readonly UserService _userService;

        private ObservableCollection<UserEntity> _users;
        public ObservableCollection<UserEntity> Users
        {
            get { return _users; }
            set { _users = value; OnPropertyChanged(); }
        }


        public ICommand SelectCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        public LoadUserViewModel()
        {
            _userService = new UserService();
            _users = new ObservableCollection<UserEntity>(_userService.GetAllUsers());

            GoBackCommand = new RelayCommand(GoBack);
        }


        private void GoBack(object obj)
        {
            Navigation?.NavigateTo<CompanyDashboardViewModel>();
        }
    }
}

