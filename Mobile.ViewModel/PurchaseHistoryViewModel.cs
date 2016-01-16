using GalaSoft.MvvmLight;
using Mobile.ViewModel.Helpers;

namespace Mobile.ViewModel
{
    public class PurchaseHistoryViewModel : ViewModelBase
    {
        private readonly IExpandedNavigation _expandedNavigation;
        private readonly ICustomerOperationProvider _customerOperationProvider;

        public PurchaseHistoryViewModel(
            IExpandedNavigation expandedNavigation, ICustomerOperationProvider customerOperationProvider)
        {
            _expandedNavigation = expandedNavigation;
            _customerOperationProvider = customerOperationProvider;
        }
    }
}