using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FloatToolBarMini.Commands
{
    public class CommandBase:ICommand
    {
        Action<object> _execute;
        Func<bool> _canExecute;
        public CommandBase(Action<object> execute, Func<bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public CommandBase(Action<object> execute)
            : this(execute, null) { }
      

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
