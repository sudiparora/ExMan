using ExMan.Client.Model.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Client.Core
{
    public sealed class TokenManager
    {

        #region Fields & Properties

        /// <summary>
        /// http://geekswithblogs.net/BlackRabbitCoder/archive/2010/05/19/c-system.lazylttgt-and-the-singleton-design-pattern.aspx
        /// The .net provided lazy initialization and singleton design pattern usage
        /// </summary>
        private static readonly Lazy<TokenManager> tokenManagerInstance
            = new Lazy<TokenManager>(() => new TokenManager());

        public static TokenManager Instance
        {
            get
            {
                return tokenManagerInstance.Value;
            }
        }

        #endregion

        public void InitializeTokenSettings(BearerTokenModel bearerTokenModel)
        {
            UserSettings.Default.BearerToken = bearerTokenModel.AccessToken;
            UserSettings.Default.BearerTokenExpiry = bearerTokenModel.ExpiryDate;
        }

        public string GetBearerToken
        {
            get
            {
                return UserSettings.Default.BearerToken;
            }
        }

    }
}
