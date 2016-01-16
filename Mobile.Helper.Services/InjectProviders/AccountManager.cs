using System.Threading.Tasks;
using Mobile.Helper.Services.CustomerAuthenticationService;
using Mobile.Helper.Services.ServiceConfiguration;
using Mobile.ViewModel.Helpers;
using Customer = Mobile.Model.Customer;

namespace Mobile.Helper.Services.InjectProviders
{
    public class AccountManager : IAccountManager
    {
        public bool IsUserLogged { get; }
        public Customer ActualLoggedUser { get; private set; }
        private readonly CustomerAuthenticationServiceClient _customerAuthenticationService;

        public AccountManager()
        {
            _customerAuthenticationService = new CustomerAuthenticationServiceConfiguration().CustomerAuthenticationServiceClient;
        }

        public async Task<bool> LogUser(string login, string password)
        {
            if (await _customerAuthenticationService.IsCorrectCredentialsCorrectAsync(login, password))
            {
                await GetInfo(login, password);

                return true;
            }
            return false;
        }
        public async Task GetInfo(string login, string password)
        {
            var customer =  await _customerAuthenticationService.GetCustomerInfoAsync(login, password);
            AutoMapper.Mapper.CreateMap<CustomerAuthenticationService.Customer, Customer>();
            

            ActualLoggedUser = AutoMapper.Mapper.Map<Customer>(customer);
            ActualLoggedUser.Password = password;
        }

        public async Task RegisterUser(string login, string password)
        {
            await _customerAuthenticationService.RegisterAsync(login, password);
        }
    }
}