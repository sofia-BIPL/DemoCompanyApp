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
    public class CreateCompanyViewModel : ViewModelBase
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
                var dto = new CompanyDTO
                {
                    Comp_Name = CompName,
                    Comp_GSTIN = CompGSTIN,
                    Comp_Country = CompCountry,
                    Comp_State = CompState
                };

                _companyService.SaveCompany(dto);

                MessageBox.Show("Company Created Successfully!", "Success", MessageBoxButton.OK);
                Navigation?.NavigateTo<MainMenuViewModel>(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating company: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel(object obj)
        {
            Navigation?.NavigateTo<MainMenuViewModel>();
        }
    }
}

