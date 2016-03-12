using System.ServiceModel;
using Mobile.Helper.Services.CustomerAuthenticationService;

namespace Mobile.Helper.Services.ServiceConfiguration
{
    public class CustomerAuthenticationServiceConfiguration
    {
        public CustomerAuthenticationServiceClient CustomerAuthenticationServiceClient { get; private set; }

        public CustomerAuthenticationServiceConfiguration()
        {
            BasicHttpBinding httpBinding = new BasicHttpBinding();

            CustomerAuthenticationServiceClient =
                new CustomerAuthenticationServiceClient(httpBinding, EndPoints.CustomerAuthentication);
        }
    }
}