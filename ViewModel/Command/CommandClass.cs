using System;
using System.Windows.Input;

namespace Ex_var_4.ViewModel.Command
{
    internal class CommandClass : ICommand
    {
        Action<object> execute;
        Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add{ CommandManager.RequerySuggested += value; }
            remove{ CommandManager.RequerySuggested -= value; }
        }

        public CommandClass(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public CommandClass(Action<object> execute) : this(execute, null)
        {
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
            {
                return canExecute(parameter);
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            execute?.Invoke(parameter);
        }
    }
}
