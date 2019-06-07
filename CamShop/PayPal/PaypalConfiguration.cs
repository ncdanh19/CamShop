 using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CamShop.PayPal
{
    // Get Configuration from web.config file
    public class PaypalConfiguration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;

         static PaypalConfiguration()
        {
            var config = GetConfig();
            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];
        }
        
        public static Dictionary<string,string> GetConfig()
        {
            return ConfigManager.Instance.GetProperties();
        }

        //Create token
        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret,GetConfig()).GetAccessToken();
            return accessToken;
        }

        // This will return APIContext object
        public static APIContext getAPIContext()
        {
            var apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }
    }
}