using ContactBook_ViewsNavigation.Store;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContactBook_ViewsNavigation.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region NotifyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private readonly NavigationStore _navigationStore;

        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += NavigationStoreCurrentViewModelChanged;
        }

        private void NavigationStoreCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
