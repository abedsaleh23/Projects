using PayPal.Api;
using System.Collections.Generic;

namespace GProject2.Models
{
    public static class PaypalConfiguration
    {
        //Variables for storing the clientID and clientSecret key  
        public readonly static string ClientId;
        public readonly static string ClientSecret;
        //Constructor  
        static PaypalConfiguration()
        {
            var config = GetConfig();
            ClientId = config["AWx7HM9X_-vCIcZq70086jK9CpIxoSf3ZQ1gXs-FcIZI-REdg1J66Q16ryff-RYw0BdiBzp06ddzH4Cw"];
            ClientSecret = config["EF4yTQpSbvklpDE6eS3ot4DAJO7eNO14UXOyflmXDi51RoOK9LC4IegCFwl-xu0wRkyCyJyS1_pN6Eb"];
        }
        // getting properties from the web.config  
        public static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }
        private static string GetAccessToken()
        {
            // getting accesstocken from paypal  
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            // return apicontext object by invoking it with the accesstoken  
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }
    }


}
