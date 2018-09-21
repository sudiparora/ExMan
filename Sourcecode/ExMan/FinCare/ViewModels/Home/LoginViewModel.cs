using FinCare.Core;
using PerFin.Core.Constants;
using PerFin.Core.Services;
using PerFin.Entities.Authentication;
using PerFin.Services;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace FinCare.ViewModels.Home
{
    public class LoginViewModel : ViewModelBase
    {

        #region Fields & Properties

        private string username;
        private LoginService loginService;
        private UserService userService;

        public DelegateCommand LoginCommand { get; private set; }
        public SecureString SecurePassword { private get; set; }

        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        #endregion

        #region Methods

        public LoginViewModel(LoginService loginService, UserService userService)
        {
            LoginCommand = new DelegateCommand(LoginCommandExecute);
            this.loginService = loginService;
            this.userService = userService;
        }

        private async void LoginCommandExecute()
        {
            ResponseModel<SessionInfo> registerNewLoginResponse = await loginService.RegisterNewLogin(Username,
                        PasswordHelper.Encrypt(SecurePassword.ConvertSecureStringToString()), DesktopHelper.GetDesktopDeviceId(), DeviceType.Desktop);
            if (registerNewLoginResponse.ServiceOperationResult == ServiceOperationResult.Success && registerNewLoginResponse.Data != null)
            {
                UserSettings.Default.SessionId = registerNewLoginResponse.Data.SessionId;
                //UserSettings.Default.BearerTokenExpiry = new DateTime()
                //TokenManager.Instance.InitializeTokenSettings(bearerTokenResponse.Data);
                ResponseModel<List<ComponentType>> componentTypesResponse = await userService.GetAvailableComponentTypes(Username);
                if (componentTypesResponse.ServiceOperationResult == ServiceOperationResult.Success)
                {
                    RegionManager.RequestNavigate(RegionNames.MainRegion, new Uri(ViewNames.HomeView, UriKind.Relative), NavigationCompleted);
                }
            }
            else
            {

            }
        }

        #endregion


    }
}
