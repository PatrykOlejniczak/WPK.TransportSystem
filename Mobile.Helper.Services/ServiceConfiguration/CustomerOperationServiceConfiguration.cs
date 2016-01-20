using System.ServiceModel;
using Mobile.Helper.Services.CustomerOperationService;
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
            BasicHttpBinding httpBinding = new BasicHttpBinding();

            CustomerOperationServiceClient =
                new CustomerOperationServiceClient(httpBinding, EndPoints.CustomerOperation);

        }         
    }
}