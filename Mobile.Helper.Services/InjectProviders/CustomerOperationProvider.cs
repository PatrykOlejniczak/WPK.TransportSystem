using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Threading.Tasks;
using Mobile.Helper.Services.CustomerOperationService;
using Mobile.Helper.Services.ServiceConfiguration;
using Mobile.ViewModel.Helpers;
using BoostAccount = Mobile.Model.BoostAccount;
using PurchaseTicket = Mobile.Model.PurchaseTicket;

namespace Mobile.Helper.Services.InjectProviders
{
    public class CustomerOperationProvider : ICustomerOperationProvider
    {
        private readonly IAccountManager _accountManager;
        private readonly CustomerOperationServiceClient _customerOperationServiceClient;
        private CustomerOperationServiceConfiguration config;
        public CustomerOperationProvider(IAccountManager accountManager)
        {
            _accountManager = accountManager;
            config = new CustomerOperationServiceConfiguration(_accountManager);
            
            _customerOperationServiceClient = config.CustomerOperationServiceClient;
        }

        public Task<ObservableCollection<BoostAccount>> GetAllBoostAccountAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ObservableCollection<PurchaseTicket>> GetAllPurchaseTicketAsync()
        {

            //config.SetCredentials();
            //var f = await _customerOperationServiceClient.GetAllPurchaseTicketAsync();

            //AutoMapper.Mapper.CreateMap<CustomerOperationService.PurchaseTicket, PurchaseTicket>();
            //AutoMapper.Mapper.CreateMap<PurchaseTicket, CustomerOperationService.PurchaseTicket>();
            //var converted = AutoMapper.Mapper.Map<IEnumerable<PurchaseTicket>>(f);

            BasicHttpBinding httpBinding = new BasicHttpBinding()
            {
                Security =
                {
                    Mode = BasicHttpSecurityMode.TransportWithMessageCredential,
                }
            };
            var address = new EndpointAddress("https://localhost:44300/Services/CustomerOperationService.svc/basicHttp");
            var customerOperationService =
                new CustomerOperationServiceClient(httpBinding, address);

            customerOperationService.ClientCredentials.UserName.UserName = "basia.kowalska@onet.eu";
            customerOperationService.ClientCredentials.UserName.Password = "kowalska";
            var w = await customerOperationService.GetAllPurchaseTicketAsync();

            return new ObservableCollection<PurchaseTicket>(null);
        }

        public Task UpdateCustomerEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateNewBoostAccount(string code)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateNewPurchaseTicket(PurchaseTicket purchaseTicket, int howManyTickets)
        {
            throw new System.NotImplementedException();
        }
    }
}