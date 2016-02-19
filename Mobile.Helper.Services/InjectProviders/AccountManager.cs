using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Mobile.Helper.Services.CustomerAuthenticationService;
using Mobile.Helper.Services.ServiceConfiguration;
using Mobile.ViewModel.Helpers;
using Mobile.ViewModel.Messages;
using Customer = Mobile.Helper.Services.CustomerAuthenticationService.Customer;

namespace Mobile.Helper.Services.InjectProviders
{
    public class AccountManager : IAccountManager
    {
        private string _password;
        private string _login;

        private Model.Customer _actualLoggedUser;
        public Model.Customer ActualLoggedUser
        {
            get
            {
                return _actualLoggedUser;
            }
            private set
            {
                _actualLoggedUser = value;
                Messenger.Default.Send(new CustomerStatus(_actualLoggedUser));
            }
        }
        private readonly CustomerAuthenticationServiceClient _customerAuthenticationService;

        public AccountManager()
        {
            _customerAuthenticationService = new CustomerAuthenticationServiceConfiguration().CustomerAuthenticationServiceClient;
        }

        public async Task LogUser(string login, string password)
        {
            if (await _customerAuthenticationService.IsCorrectCredentialsCorrectAsync(login, password))
            {
                await GetInfo(login, password);
                _password = password;
                _login = login;
            }
            else
            {
                throw new ArgumentException("Incorrect login or password.");
            }
        }  

        public async Task RefreshCustomerAccount()
        {
            var converted = await _customerAuthenticationService.GetInfoAboutCustomerAsync(_login, _password);

            ActualLoggedUser = AutoMapper.Mapper.Map<Mobile.Model.Customer>(converted);

            Messenger.Default.Send(ActualLoggedUser);
        }

        public async Task GetInfo(string login, string password)
        {
            AutoMapper.Mapper.CreateMap<CustomerAuthenticationService.Customer, Mobile.Model.Customer>();
            AutoMapper.Mapper.CreateMap<Mobile.Model.Customer, Customer>();
            var converted = await _customerAuthenticationService.GetInfoAboutCustomerAsync(login, password);

            ActualLoggedUser =  AutoMapper.Mapper.Map<Mobile.Model.Customer>(converted);

            Messenger.Default.Send(ActualLoggedUser);
        }

        public async Task RegisterUser(string login, string password)
        {
            await _customerAuthenticationService.RegisterAsync(login, password);
        }
    }
}