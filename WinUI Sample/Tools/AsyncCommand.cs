using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tools
{
    public class AsyncCommand : ICommand
    {
        private Func<Task> _func;

        public AsyncCommand(Func<Task> function)
        {
            _func = function;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async Task ExecuteAsync()
        {
            await _func();
        }

        public void Execute(object parameter)
        {
            ExecuteAsync();
        }
    }

    public class AsyncCommand<T> : ICommand
    {
        private Func<T, Task> _function;

        public AsyncCommand(Func<T, Task> function)
        {
            _function = function;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async Task ExecuteAsync(T parameter)
        {
            await _function(parameter);
        }

        public void Execute(object parameter)
        {
            _function((T)parameter);
        }
    }

}
