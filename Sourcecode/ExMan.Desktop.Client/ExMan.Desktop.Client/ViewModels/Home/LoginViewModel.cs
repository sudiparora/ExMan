using ExMan.Client.Core;
using ExMan.Client.Services;
using ExMan.Desktop.Client.Core;
using ExMan.Desktop.Client.Core.Helpers;
using ExMan.Shared.DTO;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Security;

namespace ExMan.Desktop.Client.ViewModels
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
            ResponseModel<BearerTokenDTO> bearerTokenResponse = await loginService.LoginAndFetchBearerToken(Username, 
                        PasswordHelper.Encrypt(SecurePassword.ConvertSecureStringToString()));
            if (bearerTokenResponse.ServiceOperationResult == ServiceOperationResult.Success && bearerTokenResponse.Data != null)
            {
                UserSettings.Default.BearerToken = bearerTokenResponse.Data.AccessToken;
                UserSettings.Default.BearerTokenExpiry = bearerTokenResponse.Data.ExpiryDate;
                //TokenManager.Instance.InitializeTokenSettings(bearerTokenResponse.Data);
                ResponseModel<List<ComponentTypeDTO>> componentTypesResponse = await userService.GetAvailableComponentTypes();
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
