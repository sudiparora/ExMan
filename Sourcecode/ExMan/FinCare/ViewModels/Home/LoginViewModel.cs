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
        private bool isLoginExpanderEnabled;
        private bool isRegisterExpanderEnabled;
        private bool isForgotPasswordExpanderEnabled;

        public DelegateCommand LoginCommand { get; private set; }
        public DelegateCommand RegisterCommand { get; private set; }
        public SecureString SecurePassword { private get; set; }

        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        public bool IsLoginExpanderEnabled
        {
            get { return isLoginExpanderEnabled; }
            set
            {
                if (value != isLoginExpanderEnabled)
                {
                    SetProperty(ref isLoginExpanderEnabled, value);
                    UpdateExpandersState(LoginExpander.Login);
                }
            }
        }

        public bool IsRegisterExpanderEnabled
        {
            get { return isRegisterExpanderEnabled; }
            set
            {
                if (value != isRegisterExpanderEnabled)
                {
                    SetProperty(ref isRegisterExpanderEnabled, value);
                    UpdateExpandersState(LoginExpander.Register);
                }
            }
        }

        public bool IsForgotPasswordExpanderEnabled
        {
            get { return isForgotPasswordExpanderEnabled; }
            set
            {
                if (value != isForgotPasswordExpanderEnabled)
                {
                    SetProperty(ref isForgotPasswordExpanderEnabled, value);
                    UpdateExpandersState(LoginExpander.ForgotPassword);
                }
            }
        }

        #endregion

        #region Methods

        public LoginViewModel(LoginService loginService, UserService userService)
        {
            LoginCommand = new DelegateCommand(LoginCommandExecute);
            RegisterCommand = new DelegateCommand(RegisterCommandExecute);
            this.loginService = loginService;
            this.userService = userService;
        }

        private void UpdateExpandersState(LoginExpander selectedLoginExpander)
        {
            switch (selectedLoginExpander)
            {
                case LoginExpander.Login:
                    isForgotPasswordExpanderEnabled = false;
                    isRegisterExpanderEnabled = false;
                    RaisePropertyChanged("IsForgotPasswordExpanderEnabled");
                    RaisePropertyChanged("IsRegisterExpanderEnabled");
                    break;
                case LoginExpander.Register:
                    isForgotPasswordExpanderEnabled = false;
                    isLoginExpanderEnabled = false;
                    RaisePropertyChanged("IsForgotPasswordExpanderEnabled");
                    RaisePropertyChanged("IsLoginExpanderEnabled");
                    break;
                case LoginExpander.ForgotPassword:
                    isLoginExpanderEnabled = false;
                    isRegisterExpanderEnabled = false;
                    RaisePropertyChanged("IsRegisterExpanderEnabled");
                    RaisePropertyChanged("IsLoginExpanderEnabled");
                    break;
            }
        }

        private async void LoginCommandExecute()
        {
            ResponseModel<SessionInfo> registerNewLoginResponse = await loginService.LoginExistingUser(Username,
                        PasswordHelper.Encrypt(SecurePassword.ConvertSecureStringToString()), DesktopHelper.GetDesktopDeviceId(), DeviceType.Desktop);
            if (registerNewLoginResponse.ServiceOperationResult == ServiceOperationResult.Success && registerNewLoginResponse.Data != null)
            {
                UserSettings.Default.SessionId = registerNewLoginResponse.Data.SessionId;
                //ResponseModel<List<ComponentType>> componentTypesResponse = await userService.GetAvailableComponentTypes(Username);
                //if (componentTypesResponse.ServiceOperationResult == ServiceOperationResult.Success)
                //{
                    RegionManager.RequestNavigate(RegionNames.MainRegion, new Uri(ViewNames.DashboardView, UriKind.Relative), NavigationCompleted);
                //}
            }
            else
            {

            }
        }

        private async void RegisterCommandExecute()
        {
            
        }

        #endregion


    }
}
