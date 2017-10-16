using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BasicSportsStoreWpfApp.Products
{
    public class RelayCommand : ICommand
    {
        Action _tabrgatExecuteMethod;
        Func<bool> _targatCanExecuteMethod;

        public RelayCommand(Action ExecuteMethod) {
            _tabrgatExecuteMethod = ExecuteMethod;
        }

        public RelayCommand(Action ExecuteMethod, Func<bool> canExecuteMethod)
        {
            _tabrgatExecuteMethod = ExecuteMethod;
            _targatCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged() {
            CanExecuteChanged(this, EventArgs.Empty);
        }



        #region Icommand Members
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_targatCanExecuteMethod != null) {
                return _targatCanExecuteMethod();
            }
            if (_tabrgatExecuteMethod != null) {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            if (_tabrgatExecuteMethod != null) {
                _tabrgatExecuteMethod();
            }
        } 
        #endregion
    }


    public class RelayCommand<T> : ICommand
    {
        Action<T> _tabrgatExecuteMethod;
        Func<T,bool> _targatCanExecuteMethod;

        public RelayCommand(Action<T> ExecuteMethod)
        {
            _tabrgatExecuteMethod = ExecuteMethod;
        }

        public RelayCommand(Action<T> ExecuteMethod, Func<T, bool> canExecuteMethod)
        {
            _tabrgatExecuteMethod = ExecuteMethod;
            _targatCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }



        #region Icommand Members
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_targatCanExecuteMethod != null)
            {
                T TempParameter = (T)parameter;
                return _targatCanExecuteMethod(TempParameter);
            }
            if (_tabrgatExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            if (_tabrgatExecuteMethod != null)
            {
                T TempParameter = (T)parameter;
                _tabrgatExecuteMethod(TempParameter);
            }
        }
        #endregion
    }
}
