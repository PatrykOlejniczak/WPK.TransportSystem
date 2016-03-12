using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Mobile.ViewModel.Helpers;
using Mobile.ViewModel.Messages;

namespace Mobile.ViewModel
{
    public class BuyTicketCountViewModel : ViewModelBase
    {
        public ICommand NavigateToFinalizationTransaction { get; private set; }
        
        private ObservableCollection<int> _ticketCounts;
        public ObservableCollection<int> TicketCounts
        {
            get { return _ticketCounts; }
            set
            {
                if (value != null && _ticketCounts != value)
                {
                    _ticketCounts = value;
                    RaisePropertyChanged();
                }               
            }
        }

        private int _selectedItem;
        public int SelectedCount
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged();
                ExecuteNavigateToFinalizationTransaction();
            }
        }

        private readonly IExpandedNavigation _navigationService;
        private PurchaseTicketStatus _actualPurchaseStatus;

        public BuyTicketCountViewModel(
            IExpandedNavigation navigationService)
        {
            _navigationService = navigationService;

            TicketCounts = new ObservableCollection<int>();
            InitTicketCounts();

            Messenger.Default.Register<PurchaseTicketStatus>(this,
               (message) =>
               {
                   _actualPurchaseStatus = message;
               });

            NavigateToFinalizationTransaction
                    = new RelayCommand(ExecuteNavigateToFinalizationTransaction);
        }

        private void InitTicketCounts()
        {
            for (int i = 1; i < 10; i++)
            {
                _ticketCounts.Add(i);
            }
        }

        private void ExecuteNavigateToFinalizationTransaction()
        {
            SendMessage();
            _navigationService.NavigateTo("FinalizationTransactionView");
        }

        private void SendMessage()
        {
            Messenger.Default.Send(new PurchaseTicketStatus()
            {
                TicketCount = SelectedCount,
                Ticket = _actualPurchaseStatus.Ticket
            });
        }
    }
}
