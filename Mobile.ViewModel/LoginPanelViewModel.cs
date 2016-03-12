using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Mobile.Model;
using Mobile.ViewModel.Helpers;
using Mobile.ViewModel.Messages;

namespace Mobile.ViewModel
{
    public class LoginPanelViewModel : ViewModelBase
    {
        private readonly IExpandedNavigation _navigationService;

        private Customer _customer;
        public Customer Customer
        {
            get
            {
                return _customer;
            }
            private set
            {
                if (_customer != value)
                {
                    _customer = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand LogOutCommand { get; private set; }

        public LoginPanelViewModel(IExpandedNavigation navigationService)
        {
            _navigationService = navigationService;

            LogOutCommand = new RelayCommand(ExecuteLogOutCommand);

            Messenger.Default.Register<CustomerStatus>(this, action => Customer = action.Customer);
        }

        private void ExecuteLogOutCommand()
        {
            _navigationService.NavigateTo("LoginView");
        }

    }
}