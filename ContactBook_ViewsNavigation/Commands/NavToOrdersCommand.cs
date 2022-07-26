using ContactBook_ViewsNavigation.Store;
using ContactBook_ViewsNavigation.ViewModels;
using System.ComponentModel;

namespace ContactBook_ViewsNavigation.Commands
{
    public class NavToOrdersCommand : BaseCommand
    {
        private readonly ContactsViewModel _contactsViewModel;

        public NavToOrdersCommand(ContactsViewModel contactsViewModel, NavigationStore navigationStore) : base(navigationStore)
        {
            _contactsViewModel = contactsViewModel;
            _contactsViewModel.PropertyChanged += ContactsViewModelPropertyChanged;
        }

        private void ContactsViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ContactsViewModel.SelectedContact))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _contactsViewModel.SelectedContact != null;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new OrdersViewModel(_navigationStore, _contactsViewModel.SelectedContact.ContactId);
        }
    }
}