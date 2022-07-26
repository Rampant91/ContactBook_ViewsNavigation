using ContactBook_ViewsNavigation.Store;
using ContactBook_ViewsNavigation.ViewModels;
using System;

namespace ContactBook_ViewsNavigation.Commands
{
    public class NavToContactsCommand : BaseCommand
    {
        public NavToContactsCommand(NavigationStore? navigationStore = null) : base(navigationStore)
        {
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new ContactsViewModel(_navigationStore);
        }
    }
}