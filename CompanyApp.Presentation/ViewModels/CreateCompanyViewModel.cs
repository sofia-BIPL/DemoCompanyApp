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
    public class CreateCompanyViewModel : INotifyPropertyChanged
    {
        private readonly CompanyService _companyService;

        // Properties bound to TextBoxes
        private string _compName;
        public string CompName
        {
            get { return _compName; }
            set { _compName = value; OnPropertyChanged(); }
        }

        private string _compGSTIN;
        public string CompGSTIN
        {
            get { return _compGSTIN; }
            set { _compGSTIN = value; OnPropertyChanged(); }
        }

        private string _compCountry;
        public string CompCountry
        {
            get { return _compCountry; }
            set { _compCountry = value; OnPropertyChanged(); }
        }

        private string _compState;
        public string CompState
        {
            get { return _compState; }
            set { _compState = value; OnPropertyChanged(); }
        }

        // Commands
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        // Events for View navigation
        public event Action RequestClose;

        public CreateCompanyViewModel()
        {
            _companyService = new CompanyService();
            SaveCommand = new RelayCommand(SaveCompany, CanSave);
            CancelCommand = new RelayCommand(Cancel);
        }

        private bool CanSave(object obj)
        {
            // Basic client-side validation: Fields should not be empty
            return !string.IsNullOrWhiteSpace(CompName) &&
                   !string.IsNullOrWhiteSpace(CompGSTIN) &&
                   !string.IsNullOrWhiteSpace(CompCountry) &&
                   !string.IsNullOrWhiteSpace(CompState);
        }

        private void SaveCompany(object obj)
        {
            try
            {
                MessageBox.Show("Starting save process...", "Debug", MessageBoxButton.OK, MessageBoxImage.Information);
                
                var dto = new CompanyDTO
                {
                    Comp_Name = CompName,
                    Comp_GSTIN = CompGSTIN,
                    Comp_Country = CompCountry,
                    Comp_State = CompState
                };

                MessageBox.Show($"DTO Created:\nName: {dto.Comp_Name}\nGSTIN: {dto.Comp_GSTIN}\nCountry: {dto.Comp_Country}\nState: {dto.Comp_State}", "Debug", MessageBoxButton.OK, MessageBoxImage.Information);

                _companyService.SaveCompany(dto);

                MessageBox.Show("Service.SaveCompany completed!", "Debug", MessageBoxButton.OK, MessageBoxImage.Information);

                MessageBox.Show("Company Created Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                RequestClose?.Invoke(); // Trigger close event
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error creating company:\n\n{ex.Message}";
                
                if (ex.InnerException != null)
                {
                    errorMessage += $"\n\nInner Error:\n{ex.InnerException.Message}";
                    
                    if (ex.InnerException.InnerException != null)
                    {
                        errorMessage += $"\n\nDeeper Error:\n{ex.InnerException.InnerException.Message}";
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
