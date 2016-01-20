using System.Windows.Input;
using GalaSoft.MvvmLight;
using Mobile.ViewModel.Helpers;

namespace Mobile.ViewModel
{
    public class BoostAccountViewModel : ViewModelBase
    {
        private readonly IExpandedNavigation _navigationService;
        private readonly ICustomerOperationProvider _customerOperation;

        public ICommand AcceptBoostAccount { get; private set; }

        public BoostAccountViewModel(
            IExpandedNavigation navigationService, IAccountManager accountManager, ICustomerOperationProvider customerOperation)
        {
            _navigationService = navigationService;
            _customerOperation = customerOperation;
        }

        private string _code;

        public string Code
        {
            get { return _code; }
            set
            {
                if (value != null)
                {
                    _code = value;
                }
            }
        }
    }
}