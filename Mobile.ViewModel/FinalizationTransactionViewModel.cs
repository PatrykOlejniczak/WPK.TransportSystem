using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Mobile.Model;
using Mobile.ViewModel.Helpers;

namespace Mobile.ViewModel
{
    public class FinalizationTransactionViewModel : ViewModelBase
    {
        public IExpandedNavigation NavigationService { get; private set; }
        public ICustomerOperationProvider CustomerOperation { get; private set; }

        public IAccountManager AccountManager { get; private set; }

        private Customer _customer;

        public Customer Customer
        {
            get
            {
                return _customer;
            }
            private set
            {
                if (value != _customer)
                {
                    _customer = value;
                }
                RaisePropertyChanged();
            }
        }

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
                }
                CalculateActualTicketPrice();
                RaisePropertyChanged();
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
                }
                CalculateActualTicketPrice();
                RaisePropertyChanged();
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
                if (value != _price)
                {
                    _price = value;
                }
                RaisePropertyChanged();
            }
        }

        private double _ballanceAfterTransaction;

        public double BallanceAfterTransaction
        {
            get
            {
                return _ballanceAfterTransaction;
            }
            private set
            {
                if (value != _ballanceAfterTransaction)
                {
                    _ballanceAfterTransaction = value;
                }
                RaisePropertyChanged();
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
                }
                CalculateActualTicketPrice();
                RaisePropertyChanged();
            }
        }

        public ICommand AcceptTransaction { get; private set; }

        public FinalizationTransactionViewModel(
            IExpandedNavigation navigationService, 
            ICustomerOperationProvider customerOperation, 
            IAccountManager accountManager)
        {
            NavigationService = navigationService;
            CustomerOperation = customerOperation;
            AccountManager = accountManager;

            AcceptTransaction = new RelayCommand(ExecuteAcceptTransaction);

            Messenger.Default.Register<Ticket>(this, (action) => Ticket = action);

            Messenger.Default.Register<int>(this, (action) => Count = action);

            Messenger.Default.Register<Customer>(this, (action) => Customer = action);
        }

        private async void ExecuteAcceptTransaction()
        {
            try
            {
                int? tempDiscount = null;

                if (Discount)
                {
                    tempDiscount = 1;
                }
            
                //TODO DISCOUNTS!!!

                await CustomerOperation.CreateNewPurchaseTicket(
                    new PurchaseTicket()
                    {
                        CustomerId = Customer.Id,
                        DateOfPurchase = DateTime.Now,
                        DeviceId = "hababab",
                        DiscountId = tempDiscount,
                        TicketId = Ticket.Id
                    }, Count);
                await AccountManager.RefreshCustomerAccount();
                Messenger.Default.Send((Customer)AccountManager.ActualLoggedUser);
                NavigationService.NavigateTo("MainMenuView");
            }
            catch (Exception e)
            {
                
            }
        }

        private void CalculateActualTicketPrice()
        {
            var discount = Discount ? 0.5 : 1;

            Price = Count*discount*Ticket.Price;
            BallanceAfterTransaction = Customer.AccountBallance - Price;
        }
    }
}