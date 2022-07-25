using ContactBook_ViewsNavigation.Store;
using System;

namespace ContactBook_ViewsNavigation.Commands
{
    public class CloseCommand : BaseCommand
    {
        public CloseCommand(NavigationStore? navigationStore = null) : base(navigationStore)
        {
        }

        public override bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
