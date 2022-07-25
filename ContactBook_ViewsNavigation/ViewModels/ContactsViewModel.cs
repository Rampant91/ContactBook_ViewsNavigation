using ContactBook_ViewsNavigation.DbRealization;
using ContactBook_ViewsNavigation.Models;
using System.Collections.ObjectModel;

namespace ContactBook_ViewsNavigation.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        #region Commands

        #endregion

        #region Contacts
        private ObservableCollection<Contact>? _contacts;
        public ObservableCollection<Contact>? Contacts
        {
            get => _contacts;
            set
            {
                _contacts = value;
                OnPropertyChanged(nameof(Contacts));
            }
        }
        #endregion

        #region SelectedContact
        private Contact? _selectedContact;
        public Contact? SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }
        #endregion

        #region ContactProperties
        private string? _firstName;
        public string? FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string? _lastName;
        public string? LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string? _patronymic;
        public string? Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }

        private string? _city;
        public string? City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        private string? _address;
        public string? Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private string? _phone;
        public string? Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        private string? _email;
        public string? Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        #endregion

        #region Constructor
        public ContactsViewModel()
        {

            using (DataContext db = new DataContext())
            {
                if (db.Contacts != null)
                {
                    Contacts = new ObservableCollection<Contact>(db.Contacts);
                }
                else
                {
                    Contacts = new ObservableCollection<Contact>();
                }
            }
        }
        #endregion
    }
}
