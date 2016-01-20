using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public async Task<ObservableCollection<BoostAccount>> GetAllBoostAccountAsync()
        {
            var boostAccount = await _customerOperationServiceClient
                .GetAllBoostAccountAsync("basia.kowalska@onet.eu", "kowalska");

            AutoMapper.Mapper.CreateMap<BoostAccount, CustomerOperationService.BoostAccount>();
            AutoMapper.Mapper.CreateMap<CustomerOperationService.BoostAccount, BoostAccount>();

            return new ObservableCollection<BoostAccount>(AutoMapper.Mapper.Map<IEnumerable<BoostAccount>>(boostAccount));
        }

        public async Task<ObservableCollection<PurchaseTicket>> GetAllPurchaseTicketAsync()
        {
            var purchaseTickets = await _customerOperationServiceClient
                                    .GetAllPurchaseTicketAsync("basia.kowalska@onet.eu", "kowalska");

            AutoMapper.Mapper.CreateMap<PurchaseTicket, CustomerOperationService.ExpandedPurchaseTicket>();
            AutoMapper.Mapper.CreateMap<CustomerOperationService.ExpandedPurchaseTicket, PurchaseTicket>();
       
            return new ObservableCollection<PurchaseTicket>(AutoMapper.Mapper.Map<IEnumerable<PurchaseTicket>>(purchaseTickets.OrderByDescending(p => p.DateOfPurchase)));
        }

        public Task UpdateCustomerEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateNewBoostAccount(string code)
        {
            throw new System.NotImplementedException();
        }

        public async Task CreateNewPurchaseTicket(PurchaseTicket purchaseTicket, int howManyTickets)
        {
            var w = await _customerOperationServiceClient
                .GetAllPurchaseTicketAsync("basia.kowalska@onet.eu", "kowalska");

            AutoMapper.Mapper.CreateMap<PurchaseTicket, CustomerOperationService.PurchaseTicket>();

            await _customerOperationServiceClient
                .CreateNewPurchaseTicketAsync(
                "basia.kowalska@onet.eu", "kowalska", 
                AutoMapper.Mapper.Map<CustomerOperationService.PurchaseTicket>(purchaseTicket), 
                howManyTickets);

            var w2 = await _customerOperationServiceClient
                .GetAllPurchaseTicketAsync("basia.kowalska@onet.eu", "kowalska");
        }
    }
}