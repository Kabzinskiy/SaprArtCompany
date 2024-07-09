using System;
using System.Windows.Input;

namespace RectanglesApp.ViewModels
{
    internal class RelayCommand : ICommand
    {
        #region Fields 

        readonly Action<object> execute;

        readonly Predicate<object> canExecute;

        #endregion 


        #region Constructors 

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if(execute == null)
            {
                throw new ArgumentNullException("execute");
            }
                
            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion


        #region ICommand Members 

        public bool CanExecute(object parameter) 
            => this.canExecute == null ? true : this.canExecute(parameter);

        public event EventHandler CanExecuteChanged
        {
            add 
            { 
                CommandManager.RequerySuggested += value; 
            }

            remove 
            { 
                CommandManager.RequerySuggested -= value; 
            }
        }

        public void Execute(object parameter) => this.execute?.Invoke(parameter);

        #endregion
    }
}
