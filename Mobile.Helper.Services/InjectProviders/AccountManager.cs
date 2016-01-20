using System.Threading.Tasks;
using Mobile.Helper.Services.CustomerAuthenticationService;
using Mobile.Helper.Services.ServiceConfiguration;
using Mobile.ViewModel.Helpers;
using Customer = Mobile.Helper.Services.CustomerAuthenticationService.Customer;

namespace Mobile.Helper.Services.InjectProviders
{
    public class AccountManager : IAccountManager
    {
        public bool IsUserLogged { get; }

        private string _password;
        private string _login;

        private Model.Customer _actualLoggedUser;
        public Model.Customer ActualLoggedUser {
            get
            {
                return _actualLoggedUser;
            }
            private set { _actualLoggedUser = value; } }
        public double AccountBallance { get; private set; }
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
                _password = password;
                _login = login;
                return true;
            }
            return false;
        }  

        public async Task RefreshCustomerAccount()
        {
            var converted = await _customerAuthenticationService.GetInfoAboutCustomerAsync(_login, _password);

            ActualLoggedUser = AutoMapper.Mapper.Map<Mobile.Model.Customer>(converted);
        }

        public async Task GetInfo(string login, string password)
        {
            AutoMapper.Mapper.CreateMap<CustomerAuthenticationService.Customer, Mobile.Model.Customer>();
            AutoMapper.Mapper.CreateMap<Mobile.Model.Customer, Customer>();
            var converted = await _customerAuthenticationService.GetInfoAboutCustomerAsync(login, password);

            ActualLoggedUser =  AutoMapper.Mapper.Map<Mobile.Model.Customer>(converted);
        }

        public async Task RegisterUser(string login, string password)
        {
            await _customerAuthenticationService.RegisterAsync(login, password);
        }
    }
}