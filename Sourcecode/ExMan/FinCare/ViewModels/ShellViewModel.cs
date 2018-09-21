using FinCare.Core;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCare.ViewModels
{
    public class ShellViewModel : ViewModelBase
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
