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
    public class FinalizationTransactionViewModel : ViewModelBase
    {
        private readonly IExpandedNavigation _navigationService;
        private readonly ICustomerOperationProvider _customerOperation;
        private readonly IAccountManager _accountManager;

        private Ticket _ticket;
        public Ticket Ticket
        {
            get
            {
                return _ticket;
            }
            private set
            {
                if (value != _ticket)
                {
                    _ticket = value;
                    CalculateActualTicketPrice();
                    RaisePropertyChanged();
                }
            }
        }

        private int _count;
        public int Count
        {
            get
            {
                return _count;
            }
            private set
            {
                if (value != _count)
                {
                    _count = value;
                    CalculateActualTicketPrice();
                    RaisePropertyChanged();
                }                              
            }
        }

        private bool _discount;
        public bool Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                if (value != _discount)
                {
                    _discount = value;
                    CalculateActualTicketPrice();
                    RaisePropertyChanged();
                }
            }
        }

        private double _price;
        public double Price
        {
            get
            {
                return _price;
            }
            private set
            {
                if (Math.Abs(value - _price) > 0.01)
                {
                    _price = value;
                    CalculateNewAccountBalance();
                    RaisePropertyChanged();
                }                
            }
        }

        private double _balanceAfterTransaction;
        public double BalanceAfterTransaction
        {
            get
            {
                return _balanceAfterTransaction;
            }
            private set
            {
                if (Math.Abs(value - _balanceAfterTransaction) > 0.01)
                {
                    _balanceAfterTransaction = value;
                    RaisePropertyChanged();
                }               
            }
        }

        private PurchaseTicket _purchaseTicket;
        public PurchaseTicket PurchaseTicket
        {
            get
            {
                return _purchaseTicket;
            }
            set
            {
                if (value != null)
                {
                    _purchaseTicket = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            private set
            {
                if (_errorMessage != value)
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

        public ICommand AcceptTransaction { get; private set; }

        public FinalizationTransactionViewModel(
            IExpandedNavigation navigationService, 
            ICustomerOperationProvider customerOperation, 
            IAccountManager accountManager)
        {
            _navigationService = navigationService;
            _customerOperation = customerOperation;
            _accountManager = accountManager;

            AcceptTransaction = 
                new RelayCommand(ExecuteAcceptTransaction);

            Messenger.Default.Register<PurchaseTicketStatus>(this,
                message =>
                {
                    PurchaseTicket.TicketId = message.Ticket.Id;
                    Ticket = message.Ticket;
                    Count = message.TicketCount;
                });

            PurchaseTicket = new PurchaseTicket()
            {
                DeviceId = "sampledeviceId",
            };
        }

        private async void ExecuteAcceptTransaction()
        {
            try
            {
                if (Discount)
                {
                    PurchaseTicket.DiscountId = 1;
                }
                else
                {
                    PurchaseTicket.DiscountId = null;
                }

                IsLoading = true;

                await _customerOperation.CreateNewPurchaseTicket(PurchaseTicket, Count);

                _navigationService.NavigateTo("MainMenuView");
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

        private void CalculateActualTicketPrice()
        {
            var discount = Discount ? 0.5 : 1;
            Price = Count * discount * Ticket.Price;            
        }

        private void CalculateNewAccountBalance()
        {
            BalanceAfterTransaction = _accountManager.ActualLoggedUser.AccountBallance - Price;
        }

    }
}