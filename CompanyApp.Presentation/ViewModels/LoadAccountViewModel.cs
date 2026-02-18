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
    public class LoadAccountViewModel : ViewModelBase
    {
        private readonly AccountService _accountService;

        private ObservableCollection<AccountEntity> _accounts;
        public ObservableCollection<AccountEntity> Accounts
        {
            get { return _accounts; }
            set { _accounts = value; OnPropertyChanged(); }
        }


        public ICommand SelectCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        public LoadAccountViewModel()
        {
            _accountService = new AccountService();
            _accounts = new ObservableCollection<AccountEntity>(_accountService.GetAccounts());

            GoBackCommand = new RelayCommand(GoBack);
        }



        private void GoBack(object obj)
        {
            Navigation?.NavigateTo<CompanyDashboardViewModel>();
        }
    }
}

