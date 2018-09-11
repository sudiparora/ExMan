
using PerFin.Desktop.Core;
using Prism.Commands;
using System;

namespace PerFin.Desktop.ViewModels
{
    public class ShellViewModel: ViewModelBase
    {

        #region Fields & Properties

        public DelegateCommand ShellLoadedCommand { get; private set; }

        #endregion

        #region Methods

        public ShellViewModel()
        {
            ShellLoadedCommand = new DelegateCommand(ShellLoadedCommandExecute);
        }

        private void ShellLoadedCommandExecute()
        {
            RegionManager.RequestNavigate(RegionNames.MainRegion, new Uri(ViewNames.LoginView, UriKind.Relative), NavigationCompleted);
        }

        #endregion

    }
}
