using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CConverterClient.Components
{
    public class ActionCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly Func<Task> _action;
        private readonly Func<bool> _canExecute;

        public ActionCommand(Func<Task> action, Func<bool> canExecute)
        {
            this._action = action;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute();
        }

        public void Execute(object? parameter)
        {
            _action();
        }
    }
}
