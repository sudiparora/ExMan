using ExMan.Client.Services;
using ExMan.Client.Core;
using ExMan.Desktop.Client.Core;
using ExMan.Desktop.Client.Core.Helpers;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using ExMan.Client.Model.Login;
using ExMan.Client.Model.Components;

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
            ResponseModel<BearerTokenModel> bearerTokenResponse = await loginService.LoginAndFetchBearerToken(Username, 
                        PasswordHelper.Encrypt(SecurePassword.ConvertSecureStringToString()));
            if (bearerTokenResponse.ServiceOperationResult == ServiceOperationResult.Success && bearerTokenResponse.Data != null)
            {
                TokenManager.Instance.InitializeTokenSettings(bearerTokenResponse.Data);
                ResponseModel<List<ComponentTypeModel>> componentTypesResponse = await userService.GetAvailableComponentTypes();
                if (componentTypesResponse.ServiceOperationResult == ServiceOperationResult.Success)
                {
                    RegionManager.RequestNavigate(RegionNames.MainRegion, new Uri(ViewNames.LoginView, UriKind.Relative), NavigationCompleted);
                }
            }
            else
            {

            }
        }

        #endregion

    }
}
