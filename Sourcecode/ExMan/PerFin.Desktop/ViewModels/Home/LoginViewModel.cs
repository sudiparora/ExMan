using PerFin.Core.Services;
using PerFin.Desktop.Core;
using PerFin.Desktop.Core.Helpers;
using PerFin.Entities.Authentication;
using PerFin.Services;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Security;

namespace PerFin.Desktop.ViewModels
{
    public class LoginViewModel: ViewModelBase
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
            ResponseModel<BearerTokenInfo> bearerTokenResponse = await loginService.LoginAndFetchBearerToken(Username, 
                        PasswordHelper.Encrypt(SecurePassword.ConvertSecureStringToString()));
            if (bearerTokenResponse.ServiceOperationResult == ServiceOperationResult.Success && bearerTokenResponse.Data != null)
            {
                UserSettings.Default.BearerToken = bearerTokenResponse.Data.AccessToken;
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
