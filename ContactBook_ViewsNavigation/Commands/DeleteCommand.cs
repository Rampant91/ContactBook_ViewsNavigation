using ContactBook_ViewsNavigation.DbRealization;
using ContactBook_ViewsNavigation.Models;
using ContactBook_ViewsNavigation.ViewModels;
using System.Linq;

namespace ContactBook_ViewsNavigation.Commands
{
    public class DeleteCommand : BaseCommand
    {
        private readonly BaseViewModel _currentViewModel;

        public DeleteCommand(BaseViewModel currentViewModel)
        {
            _currentViewModel = currentViewModel;
            _currentViewModel.PropertyChanged += CurrentViewModelPropertyChanged;
        }

        private void CurrentViewModelPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ContactsViewModel.SelectedContact)
                || e.PropertyName == nameof(OrdersViewModel.SelectedOrder))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            if (_currentViewModel is ContactsViewModel)
            {
                return ((ContactsViewModel)_currentViewModel).SelectedContact != null;
            }
            else if (_currentViewModel is OrdersViewModel)
            {
                return ((OrdersViewModel)_currentViewModel).SelectedOrder != null;
            }
            return true;
        }

        public override void Execute(object? parameter)
        {
            using (DataContext db = new DataContext())
            {
                if (_currentViewModel is ContactsViewModel)
                {
                    Contact? contact = ((ContactsViewModel)_currentViewModel).SelectedContact;
                    var contactDb = db.Contacts?.FirstOrDefault(x => x.ContactId == contact!.ContactId);
                    if (contactDb != null)
                    {
                        db.Contacts?.Remove(contactDb);
                        ((ContactsViewModel)_currentViewModel).Contacts?.Remove(contact!);
                    }
                }
                else if (_currentViewModel is OrdersViewModel)
                {
                    Order? order = ((OrdersViewModel)_currentViewModel).SelectedOrder;
                    var orderDb = db.Orders?.FirstOrDefault(x => x.OrderId == order!.OrderId);
                    if (orderDb != null)
                    {
                        db.Orders?.Remove(orderDb);
                        ((OrdersViewModel)_currentViewModel).Orders?.Remove(order!);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}