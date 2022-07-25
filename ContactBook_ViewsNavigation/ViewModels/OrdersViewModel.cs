using ContactBook_ViewsNavigation.DbRealization;
using ContactBook_ViewsNavigation.Models;
using System.Collections.ObjectModel;

namespace ContactBook_ViewsNavigation.ViewModels
{
    internal class OrdersViewModel : BaseViewModel
    {
        #region Commands

        #endregion

        #region Orders
        private ObservableCollection<Order>? _orders;
        public ObservableCollection<Order>? Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }
        #endregion

        #region SelectedOrder
        private Order? _selectedOrder;
        public Order? SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }
        #endregion

        #region ContactProperties
        private int _contactId;
        public int ContactId
        {
            get => _contactId;
            set
            {
                _contactId = value;
                OnPropertyChanged(nameof(ContactId));
            }
        }

        private string? _name;
        public string? Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string? _date;
        public string? Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private string? _price;
        public string? Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private string? _amount;
        public string? Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        private string? _discription;
        public string? Discription
        {
            get => _discription;
            set
            {
                _discription = value;
                OnPropertyChanged(nameof(Discription));
            }
        }
        #endregion

        #region Constructor
        public OrdersViewModel()
        {

            using (DataContext db = new DataContext())
            {
                if (db.Orders != null)
                {
                    Orders = new ObservableCollection<Order>(db.Orders);
                }
                else
                {
                    Orders = new ObservableCollection<Order>();
                }
            }
        }
        #endregion
    }
}
