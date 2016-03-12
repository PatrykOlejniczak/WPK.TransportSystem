using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Mobile.Model;
using Mobile.ViewModel.Helpers;
using Mobile.ViewModel.Messages;

namespace Mobile.ViewModel
{
    public class BoostAccountViewModel : ViewModelBase
    {
        private readonly IExpandedNavigation _navigationService;
        private readonly ICustomerOperationProvider _customerOperation;

        public ICommand AcceptBoostAccount { get; private set; }
        public ICommand NaviagteToMainMenu { get; private set; }

        private string _code;
        public string Code
        {
            get { return _code; }
            set
            {
                if (value != null)
                {
                    _code = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            private set
            {
                if (value != _errorMessage)
                {
                    _errorMessage = value;
                    RaisePropertyChanged();
                }              
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool _isCorrect;
        public bool IsCorrect
        {
            get { return _isCorrect; }
            set
            {
                if (_isCorrect != value)
                {
                    _isCorrect = value;
                    RaisePropertyChanged();
                }
            }
        }

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

        public BoostAccountViewModel(
            IExpandedNavigation navigationService, ICustomerOperationProvider customerOperation)
        {
            _navigationService = navigationService;
            _customerOperation = customerOperation;

            AcceptBoostAccount 
                = new RelayCommand(ExecuteAcceptBoostAccount);

            NaviagteToMainMenu
                = new RelayCommand(ExecuteNaviagteToMainMenu);

            Messenger.Default.Register<CustomerStatus>(this, message => Customer = message.Customer);
        }

        private async void ExecuteAcceptBoostAccount()
        {
            try
            {
                IsLoading = true;

                await _customerOperation.CreateNewBoostAccount(Code);

                IsCorrect = true;
            }
            catch (Exception exception)
            {
                ErrorMessage = exception.Message;
            }
            finally
            {
                IsLoading = false;               
            }
        }

        private void ExecuteNaviagteToMainMenu()
        {
            IsCorrect = false;
            _navigationService.NavigateTo("MainMenuView");
        }

    }
}