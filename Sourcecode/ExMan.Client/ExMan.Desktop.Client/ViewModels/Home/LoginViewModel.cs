using ExMan.Client.Services;
using ExMan.Client.Shared.Core;
using ExMan.Desktop.Client.Core;
using ExMan.Desktop.Client.Core.Helpers;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Desktop.Client.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {

        #region Fields & Properties

        private string username;
        private LoginService loginService;


        public DelegateCommand LoginCommand { get; private set; }
        public SecureString SecurePassword { private get; set; }

        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        #endregion

        #region Methods

        public LoginViewModel(LoginService loginService)
        {
            LoginCommand = new DelegateCommand(LoginCommandExecute);
            this.loginService = loginService;
        }

        private async void LoginCommandExecute()
        {
            ResponseModel<string> bearerToken = await loginService.LoginAndFetchBearerToken(Username, 
                        PasswordHelper.Encrypt(SecurePassword.ConvertSecureStringToString()));
        }

        #endregion

    }
}
