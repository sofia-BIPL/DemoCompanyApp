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
    public class CreateAccountViewModel : INotifyPropertyChanged
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

        public event Action RequestClose;

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
                // Debug: Show current session values
                MessageBox.Show(
                    $"Current Session:\nCompany ID: {CompanyApp.Domain.GlobalVar.SessionGlobal.Comp_Id}\nUser ID: {CompanyApp.Domain.GlobalVar.SessionGlobal.User_Id}", 
                    "Debug - Session Info", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Information);

                var dto = new AccountDTO
                {
                    Acc_Name = AccountName,
                    Acc_Group = AccountGroup,
                    Acc_Balance = AccountBalance
                    // FK_User_Id and FK_Comp_Id are handled in AccountService using SessionGlobal
                };

                _accountService.SaveAccount(dto);

                MessageBox.Show("Account Created Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                RequestClose?.Invoke();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error creating account: {ex.Message}";
                
                if (ex.InnerException != null)
                {
                    errorMessage += $"\n\nInner Exception:\n{ex.InnerException.Message}";
                    
                    if (ex.InnerException.InnerException != null)
                    {
                        errorMessage += $"\n\nDeeper Exception:\n{ex.InnerException.InnerException.Message}";
                    }
                }
                
                errorMessage += $"\n\nStack Trace:\n{ex.StackTrace}";
                
                MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel(object obj)
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
