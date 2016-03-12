using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Mobile.Helper.Services.CustomerAuthenticationService;
using Mobile.Helper.Services.ServiceConfiguration;
using Mobile.ViewModel.Helpers;
using Mobile.ViewModel.Messages;

namespace Mobile.Helper.Services.InjectProviders
{
    public class AccountManager : IAccountManager
    {
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
                Messenger.Default.Send(new CustomerStatus() { Customer = _actualLoggedUser });
            }
        }

        private readonly CustomerAuthenticationServiceClient _customerAuthenticationService;

        public AccountManager()
        {
            _customerAuthenticationService = 
                new CustomerAuthenticationServiceConfiguration().CustomerAuthenticationServiceClient;
        }

        public async Task LogUser(string login, string password)
        {
            if (await _customerAuthenticationService.IsCorrectCredentialsCorrectAsync(login, password))
            {
                await GetInfo(login, password);
                ActualLoggedUser.Password = password;
                ActualLoggedUser.Email = login;
            }
            else
            {
                throw new ArgumentException("Incorrect login or password.");
            }
        }  

        public async Task RefreshCustomerAccount()
        {
            var updateData = await _customerAuthenticationService.GetInfoAboutCustomerAsync(ActualLoggedUser.Email, ActualLoggedUser.Password);

            ActualLoggedUser.AccountBallance = updateData.AccountBallance;

            Messenger.Default.Send(ActualLoggedUser);
        }

        public async Task GetInfo(string login, string password)
        {
            AutoMapper.Mapper.CreateMap<Customer, Model.Customer>();
            AutoMapper.Mapper.CreateMap<Model.Customer, Customer>();
            var converted = await _customerAuthenticationService.GetInfoAboutCustomerAsync(login, password);

            ActualLoggedUser =  AutoMapper.Mapper.Map<Model.Customer>(converted);

            Messenger.Default.Send(ActualLoggedUser);
        }

        public async Task RegisterUser(string login, string password)
        {
            await _customerAuthenticationService.RegisterAsync(login, password);
        }
    }
}