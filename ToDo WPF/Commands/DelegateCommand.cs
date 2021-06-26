using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;

namespace ToDo_WPF.Commands
{
    public class DelegateCommand : ICommand
    {
        private readonly Func<object, bool> _canExecute;

        [NotNull] private readonly Action<object> _execute;

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}