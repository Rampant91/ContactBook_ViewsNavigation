using ContactBook_ViewsNavigation.ViewModels;
using System;

namespace ContactBook_ViewsNavigation.Store
{
    public class NavigationStore
    {
        public event Action? CurrentViewModelChanged;

        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnCurrentViewModelChanged();
                }
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}