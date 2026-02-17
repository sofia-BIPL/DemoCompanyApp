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
    public class LoadAccountViewModel : INotifyPropertyChanged
    {
        private readonly AccountService _accountService;

        private ObservableCollection<AccountEntity> _accounts;
        public ObservableCollection<AccountEntity> Accounts
        {
            get { return _accounts; }
            set { _accounts = value; OnPropertyChanged(); }
        }

        private AccountEntity _selectedAccount;
        public AccountEntity SelectedAccount
        {
            get { return _selectedAccount; }
            set 
            { 
                _selectedAccount = value; 
                OnPropertyChanged(); 
            }
        }

        public ICommand SelectCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        public event Action RequestClose;

        public LoadAccountViewModel()
        {
            _accountService = new AccountService();
            _accounts = new ObservableCollection<AccountEntity>(_accountService.GetAccounts());

            SelectCommand = new RelayCommand(SelectAccount, CanSelectAccount);
            GoBackCommand = new RelayCommand(GoBack);
        }

        private bool CanSelectAccount(object obj)
        {
            return SelectedAccount != null;
        }

        private void SelectAccount(object obj)
        {
            if (SelectedAccount == null) return;

            try
            {
                MessageBox.Show($"Selected Account: {SelectedAccount.Acc_Name}\n" +
                    $"Group: {SelectedAccount.Acc_Group}\n" +
                    $"Balance: {SelectedAccount.Acc_Balance:C}", 
                    "Account Selected", MessageBoxButton.OK, MessageBoxImage.Information);
                
                // In a real application, you might navigate to an edit form or perform other actions
                RequestClose?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting account: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
