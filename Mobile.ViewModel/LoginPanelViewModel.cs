using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Mobile.Model;
using Mobile.ViewModel.Helpers;

namespace Mobile.ViewModel
{
    public class LoginPanelViewModel : ViewModelBase
    {
        private readonly IExpandedNavigation _navigationService;
        private readonly IAccountManager _accountManager;

        private Customer _customer;
        public Customer Customer
        {
            get
            {
                RefreshCustomer();
                return _customer;
            }
        }

        public LoginPanelViewModel(IExpandedNavigation navigationService, 
            IAccountManager accountManager)
        {
            _accountManager = accountManager;
            _navigationService = navigationService;
        }

        private void RefreshCustomer()
        {
            _accountManager.RefreshCustomerAccount();
            _customer = _accountManager.ActualLoggedUser;
        }
    }
}