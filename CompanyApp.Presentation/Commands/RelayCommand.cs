/*
    PURPOSE OF RELAY COMMAND:

    This class implements ICommand interface.

    It connects Button Click in View
    to Command in ViewModel.

    Instead of writing click logic in code-behind,
    MVVM uses Command binding through this class.

    Button → Command → ViewModel Method
*/
using System;
using System.Windows.Input;

namespace CompanyApp.Presentation.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}

