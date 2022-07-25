using ContactBook_ViewsNavigation.DbRealization;
using ContactBook_ViewsNavigation.ViewModels;
using System.ComponentModel;
using System.Linq;

namespace ContactBook_ViewsNavigation.Commands
{
    public class SaveCommand : BaseCommand
    {
        private readonly BaseViewModel _currentViewModel;

        public SaveCommand(BaseViewModel currentViewModel)
        {
            _currentViewModel = currentViewModel;
            _currentViewModel.PropertyChanged += CurrentViewModelPropertyChanged;
        }

        private void CurrentViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ContactsViewModel.SelectedContact)
                || e.PropertyName == nameof(ContactsViewModel.FirstName)
                || e.PropertyName == nameof(ContactsViewModel.LastName)
                || e.PropertyName == nameof(ContactsViewModel.Patronymic)
                || e.PropertyName == nameof(ContactsViewModel.City)
                || e.PropertyName == nameof(ContactsViewModel.Address)
                || e.PropertyName == nameof(ContactsViewModel.Phone)
                || e.PropertyName == nameof(ContactsViewModel.Email)
                || e.PropertyName == nameof(OrdersViewModel.SelectedOrder)
                || e.PropertyName == nameof(OrdersViewModel.Name)
                || e.PropertyName == nameof(OrdersViewModel.Date)
                || e.PropertyName == nameof(OrdersViewModel.Price)
                || e.PropertyName == nameof(OrdersViewModel.Amount)
                || e.PropertyName == nameof(OrdersViewModel.Discription))
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
                    var contact = ((ContactsViewModel)_currentViewModel).SelectedContact;
                    var contactDb = db.Contacts?.FirstOrDefault(x => x.ContactId == contact.ContactId);
                    if (contactDb != null)
                    {
                        contactDb.FirstName = contact.FirstName;
                        contactDb.LastName = contact.LastName;
                        contactDb.Patronymic = contact.Patronymic;
                        contactDb.City = contact.City;
                        contactDb.Address = contact.Address;
                        contactDb.Phone = contact.Phone;
                        contactDb.Email = contact.Email;
                    }
                }
                else if (_currentViewModel is OrdersViewModel)
                {
                    var order = ((OrdersViewModel)_currentViewModel).SelectedOrder;
                    var orderDb = db.Orders?.FirstOrDefault(x => x.ContactId == order.ContactId);
                    if (orderDb != null)
                    {
                        orderDb.Name = order.Name;
                        orderDb.Date = order.Date;
                        orderDb.Price = order.Price;
                        orderDb.Amount = order.Amount;
                        orderDb.Discription = order.Discription;
                    }
                }
                db.SaveChanges();
            }
        }
    }
}