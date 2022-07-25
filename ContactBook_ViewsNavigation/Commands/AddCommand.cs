using ContactBook_ViewsNavigation.DbRealization;
using ContactBook_ViewsNavigation.Models;
using ContactBook_ViewsNavigation.ViewModels;
using System.ComponentModel;

namespace ContactBook_ViewsNavigation.Commands
{
    public class AddCommand : BaseCommand
    {
        private readonly BaseViewModel _currentViewModel;

        public AddCommand(BaseViewModel currentViewModel)
        {
            _currentViewModel = currentViewModel;
            _currentViewModel.PropertyChanged += CurrentViewModelPropertyChanged;
        }

        private void CurrentViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ContactsViewModel.SelectedContact)
                || e.PropertyName == nameof(OrdersViewModel.SelectedOrder))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            using (DataContext db = new DataContext())
            {
                if (_currentViewModel is ContactsViewModel)
                {
                    Contact contact = new Contact();
                    db.Contacts?.Add(contact);
                    ((ContactsViewModel)_currentViewModel).SelectedContact = contact;
                    ((ContactsViewModel)_currentViewModel).Contacts?.Add(contact);
                }
                else if (_currentViewModel is OrdersViewModel)
                {
                    Order order = new Order { ContactId = ((OrdersViewModel)_currentViewModel).ContactId };
                    db.Orders?.Add(order);
                    ((OrdersViewModel)_currentViewModel).SelectedOrder = order;
                    ((OrdersViewModel)_currentViewModel).Orders?.Add(order);
                }
                db.SaveChanges();
            }
        }
    }
}
