using System.ServiceModel;
using Mobile.Helper.Services.CustomerOperationService;
using Mobile.Helper.Services.InjectProviders;
using Mobile.ViewModel.Helpers;

namespace Mobile.Helper.Services.ServiceConfiguration
{
    public class CustomerOperationServiceConfiguration
    {
        public CustomerOperationServiceClient CustomerOperationServiceClient { get; private set; }

        private readonly IAccountManager _accountManager;

        public CustomerOperationServiceConfiguration(IAccountManager accountManager)
        {
            _accountManager = accountManager;
            BasicHttpBinding httpBinding = new BasicHttpBinding()
            {
                Security =
                {
                    Mode = BasicHttpSecurityMode.TransportWithMessageCredential,
                }
            };

            CustomerOperationServiceClient =
                new CustomerOperationServiceClient(httpBinding, EndPoints.CustomerOperation);
        }

        public void SetCredentials()
        {
            CustomerOperationServiceClient.ClientCredentials.UserName.UserName =
                _accountManager.ActualLoggedUser.Email;

            CustomerOperationServiceClient.ClientCredentials.UserName.Password =
                _accountManager.ActualLoggedUser.Password;
        }
         
    }
}