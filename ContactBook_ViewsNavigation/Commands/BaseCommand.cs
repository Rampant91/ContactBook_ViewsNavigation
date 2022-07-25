using ContactBook_ViewsNavigation.Store;
using System;
using System.Windows.Input;

namespace ContactBook_ViewsNavigation.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public readonly NavigationStore? _navigationStore;
        public BaseCommand(NavigationStore? navigationStore = null)
        {
            _navigationStore = navigationStore;
        }

        public event EventHandler? CanExecuteChanged;

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public abstract bool CanExecute(object? parameter);

        public abstract void Execute(object? parameter);
    }
}