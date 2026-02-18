using System;
using CompanyApp.Presentation.ViewModels;

namespace CompanyApp.Presentation.Navigation
{
    public interface INavigationService
    {
        ViewModelBase CurrentViewModel { get; }
        event Action CurrentViewModelChanged;
        void NavigateTo<TViewModel>() where TViewModel : ViewModelBase;
        void NavigateTo(ViewModelBase viewModel);
    }

    public class NavigationService : INavigationService
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            private set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            ViewModelBase viewModel = (ViewModelBase)Activator.CreateInstance(typeof(TViewModel));
            viewModel.Navigation = this;
            CurrentViewModel = viewModel;
        }

        public void NavigateTo(ViewModelBase viewModel)
        {
            viewModel.Navigation = this;
            CurrentViewModel = viewModel;
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
