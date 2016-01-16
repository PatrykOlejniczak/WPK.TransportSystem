using GalaSoft.MvvmLight;
using Mobile.ViewModel.Helpers;

namespace Mobile.ViewModel
{
    public class BoostAccountViewModel : ViewModelBase
    {
        private readonly IExpandedNavigation _navigationService;
        private readonly IAccountManager _accountManager;
        private readonly ICustomerOperationProvider _customerOperation;

        public BoostAccountViewModel(
            IExpandedNavigation navigationService, IAccountManager accountManager, ICustomerOperationProvider customerOperation)
        {
            _navigationService = navigationService;
            _accountManager = accountManager;
            _customerOperation = customerOperation;
        }
    }
}