using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using Mobile.Model;
using Mobile.ViewModel.Helpers;
using Mobile.ViewModel.Messages;

namespace Mobile.ViewModel
{
    public class MainMenuViewModel : ViewModelBase
    {
        private ObservableCollection<PurchaseTicket> _activePurchaseTickets;
        public ObservableCollection<PurchaseTicket> ActivePurchaseTickets
        {
            get { return _activePurchaseTickets; }
            private set
            {
                if (_activePurchaseTickets != value)
                {
                    _activePurchaseTickets = value;
                    RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<string> _favouriteLines;
        public ObservableCollection<string> FavouriteLines
        {
            get { return _favouriteLines; }
            private set
            {
                if (_favouriteLines != value)
                {
                    _favouriteLines = value;
                    RaisePropertyChanged();
                }                
            }
        }

        public ICommand NavigateToPurchaseHistory { get; private set; }
        public ICommand NavigateToTimetable { get; private set; }
        public ICommand NavigateToBuyTicket { get; private set; }
        public ICommand NavigateToBoostAccount { get; private set; }

        private readonly IExpandedNavigation _navigationService;
        private readonly ICustomerOperationProvider _customerOperationProvider;

        public MainMenuViewModel(IExpandedNavigation navigationService, 
            ICustomerOperationProvider customerOperationProvider)
        {
            _navigationService = navigationService;
            _customerOperationProvider = customerOperationProvider;

            NavigateToPurchaseHistory
                = new RelayCommand(ExecuteNavigateToPurchaseHistory);

            NavigateToBoostAccount
                = new RelayCommand(ExecuteNavigateToBoostAccount);

            NavigateToBuyTicket
                = new RelayCommand(ExecuteNavigateToBuyTicket);

            NavigateToTimetable
                = new RelayCommand(ExecuteNavigateToTimetable);

            Messenger.Default.Register<CustomerStatus>(this, message => DownloadActiveTickets());

            UpdateActiveTicketList();
        }

        private void ExecuteNavigateToPurchaseHistory()
        {
            _navigationService.NavigateTo("PurchaseHistoryView");
        }

        private void ExecuteNavigateToTimetable()
        {
            _navigationService.NavigateTo("ChooseLineView");
        }

        private void ExecuteNavigateToBuyTicket()
        {
            _navigationService.NavigateTo("ChooseTicketTypeView");
        }

        private void ExecuteNavigateToBoostAccount()
        {
            _navigationService.NavigateTo("BoostAccountView");
        }

        private async void DownloadActiveTickets()
        {
            ActivePurchaseTickets = 
                await _customerOperationProvider.GetActivePurchaseTicketsAsync();
        }

        private void UpdateActiveTicketList()
        {
            Task dowloaderTask =
                new Task(
                    async () =>
                    {
                        while(true)
                        {
                            await DispatcherHelper.RunAsync(DownloadActiveTickets);
                            await Task.Delay(new TimeSpan(0, 0, 0, 5));
                        }
                    });
            dowloaderTask.Start();
        }
    }
}