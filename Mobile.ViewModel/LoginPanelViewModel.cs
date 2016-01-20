using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Mobile.Model;
using Mobile.ViewModel.Helpers;

namespace Mobile.ViewModel
{
    public class LoginPanelViewModel : ViewModelBase
    {
        private readonly IExpandedNavigation _navigationService;

        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            private set
            {
                if (_customer != value)
                {
                    _customer = value;
                }
                RaisePropertyChanged();
            }
        }

        public LoginPanelViewModel(IExpandedNavigation navigationService)
        {
            _navigationService = navigationService;

            Messenger.Default.Register<Customer>(this, (action) => Customer = action);
        }
    }
}