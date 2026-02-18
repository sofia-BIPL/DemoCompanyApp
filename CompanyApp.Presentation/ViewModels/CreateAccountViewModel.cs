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
    public class CreateAccountViewModel : ViewModelBase
    {
        private readonly AccountService _accountService;

        private string _accountName;
        public string AccountName
        {
            get { return _accountName; }
            set { _accountName = value; OnPropertyChanged(); }
        }

        private string _accountGroup;
        public string AccountGroup
        {
            get { return _accountGroup; }
            set { _accountGroup = value; OnPropertyChanged(); }
        }

        private decimal _accountBalance;
        public decimal AccountBalance
        {
            get { return _accountBalance; }
            set { _accountBalance = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public CreateAccountViewModel()
        {
            _accountService = new AccountService();
            SaveCommand = new RelayCommand(SaveAccount, CanSave);
            CancelCommand = new RelayCommand(Cancel);
        }

        private bool CanSave(object obj)
        {
            return !string.IsNullOrWhiteSpace(AccountName) && !string.IsNullOrWhiteSpace(AccountGroup);
        }

        private void SaveAccount(object obj)
        {
            try
            {
                var dto = new AccountDTO
                {
                    Acc_Name = AccountName,
                    Acc_Group = AccountGroup,
                    Acc_Balance = AccountBalance
                };

                _accountService.SaveAccount(dto);

                MessageBox.Show("Account Created Successfully!", "Success", MessageBoxButton.OK);
                Navigation?.NavigateTo<CompanyDashboardViewModel>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating account: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel(object obj)
        {
            Navigation?.NavigateTo<CompanyDashboardViewModel>();
        }
    }
}

