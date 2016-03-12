using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Mobile.Helper.Services.CustomerOperationService;
using Mobile.Helper.Services.ServiceConfiguration;
using Mobile.ViewModel.Helpers;

namespace Mobile.Helper.Services.InjectProviders
{
    public class CustomerOperationProvider : ICustomerOperationProvider
    {
        private readonly IAccountManager _accountManager;
        private readonly CustomerOperationServiceClient _customerOperationServiceClient;

        public CustomerOperationProvider(IAccountManager accountManager)
        {
            _accountManager = accountManager;
            var config = new CustomerOperationServiceConfiguration(_accountManager);
            
            _customerOperationServiceClient = config.CustomerOperationServiceClient;
        }

        public async Task<ObservableCollection<Model.BoostAccount>> GetAllBoostAccountAsync()
        {
            var boostAccount = await _customerOperationServiceClient
                .GetAllBoostAccountAsync(_accountManager.ActualLoggedUser.Email, _accountManager.ActualLoggedUser.Password);

            AutoMapper.Mapper.CreateMap<Model.BoostAccount, BoostAccount>();
            AutoMapper.Mapper.CreateMap<BoostAccount, Model.BoostAccount>();

            return new ObservableCollection<Model.BoostAccount>(AutoMapper.Mapper.Map<IEnumerable<Model.BoostAccount>>(boostAccount));
        }

        public async Task<ObservableCollection<Model.PurchaseTicket>> GetAllPurchaseTicketAsync()
        {
            var purchaseTickets = await _customerOperationServiceClient
                                    .GetAllPurchaseTicketAsync(_accountManager.ActualLoggedUser.Email, _accountManager.ActualLoggedUser.Password);

            AutoMapper.Mapper.CreateMap<Model.PurchaseTicket, ExpandedPurchaseTicket>();
            AutoMapper.Mapper.CreateMap<ExpandedPurchaseTicket, Model.PurchaseTicket>();
       
            return new ObservableCollection<Model.PurchaseTicket>(AutoMapper.Mapper.Map<IEnumerable<Model.PurchaseTicket>>(purchaseTickets.OrderByDescending(p => p.DateOfPurchase)));
        }

        public async Task<ObservableCollection<Model.PurchaseTicket>> GetActivePurchaseTicketsAsync()
        {
            var purchaseTickets = await _customerOperationServiceClient
                        .GetActivePurchaseTicketAsync(_accountManager.ActualLoggedUser.Email, _accountManager.ActualLoggedUser.Password, "hababa");

            AutoMapper.Mapper.CreateMap<Model.PurchaseTicket, ExpandedPurchaseTicket>();
            AutoMapper.Mapper.CreateMap<ExpandedPurchaseTicket, Model.PurchaseTicket>();

            var collection = new ObservableCollection<Model.PurchaseTicket>(AutoMapper.Mapper.Map<IEnumerable<Model.PurchaseTicket>>(purchaseTickets.OrderByDescending(p => p.DateOfPurchase)));
            return collection;
        }

        public async Task CreateNewBoostAccount(string code)
        {
            await _customerOperationServiceClient.CreateNewBoostAccountAsync(_accountManager.ActualLoggedUser.Email, _accountManager.ActualLoggedUser.Password, code);

            await _accountManager.RefreshCustomerAccount();
        }

        public async Task CreateNewPurchaseTicket(Model.PurchaseTicket purchaseTicket, int howManyTickets)
        {
            AutoMapper.Mapper.CreateMap<Model.PurchaseTicket, PurchaseTicket>();

            await _customerOperationServiceClient
                .CreateNewPurchaseTicketAsync(
                _accountManager.ActualLoggedUser.Email, _accountManager.ActualLoggedUser.Password,
                AutoMapper.Mapper.Map<PurchaseTicket>(purchaseTicket), 
                howManyTickets);

            await _accountManager.RefreshCustomerAccount();

            await Task.Delay(1000);
        }
    }
}