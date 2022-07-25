using ContactBook_ViewsNavigation.Store;
using ContactBook_ViewsNavigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ContactBook_ViewsNavigation
{
    public partial class App : Application
    {
        private readonly NavigationStore navigationStore = new();

        protected override void OnStartup(StartupEventArgs startupEventArgs)
        {
            navigationStore.CurrentViewModel = new ContactsViewModel(navigationStore);
            MainWindow = new MainWindow() 
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();
        }
    }
}
