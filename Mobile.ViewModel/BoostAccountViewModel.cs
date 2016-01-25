using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Mobile.Model;
using Mobile.ViewModel.Helpers;

namespace Mobile.ViewModel
{
    public class BoostAccountViewModel : ViewModelBase
    {
        private readonly IExpandedNavigation _navigationService;
        private readonly ICustomerOperationProvider _customerOperation;
        private readonly IAccountManager _accountManager;
        public ICommand AcceptBoostAccount { get; private set; }

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

        private bool _isError;
        public bool IsError
        {
            get
            {
                return _isError;
            }
            private set
            {
                if (value != _isError)
                {
                    _isError = value;
                }
                RaisePropertyChanged();
            }
        }

        public BoostAccountViewModel(
            IExpandedNavigation navigationService, IAccountManager accountManager, ICustomerOperationProvider customerOperation)
        {
            _navigationService = navigationService;
            _customerOperation = customerOperation;
            _accountManager = accountManager;

            AcceptBoostAccount 
                = new RelayCommand(ExecuteAcceptBoostAccount);
        }


        private async void ExecuteAcceptBoostAccount()
        {
            try
            {
                await _customerOperation.CreateNewBoostAccount(Code);

                _navigationService.NavigateTo("MainMenuView");
            }
            catch (Exception)
            {
                IsError = true;
            }           
        }

    }
}