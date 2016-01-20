using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Mobile.ViewModel.Helpers;

namespace Mobile.ViewModel
{
    public class BuyTicketCountViewModel : ViewModelBase
    {
        public IExpandedNavigation NavigationService { get; private set; }

        private ObservableCollection<int> _ticketCounts;

        public ObservableCollection<int> TicketCounts
        {
            get { return _ticketCounts; }
            set
            {
                if (value != null && _ticketCounts != value)
                {
                    _ticketCounts = value;
                }

                RaisePropertyChanged();
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
                Messenger.Default.Send(_selectedItem);
                NavigateToFinalizationTransaction.Execute(null);
            }
        }

        public ICommand NavigateToFinalizationTransaction { get; private set; }

        public BuyTicketCountViewModel(IExpandedNavigation navigationService)
        {
            NavigationService = navigationService;
            TicketCounts = new ObservableCollection<int>();
            for (int i = 1; i < 10; i++)
            {
                _ticketCounts.Add(i);    
            }

            NavigateToFinalizationTransaction
                    = new RelayCommand(ExecuteNavigateToPurchaseHistory);
        }

        private void ExecuteNavigateToPurchaseHistory()
        {
            NavigationService.NavigateTo("FinalizationTransactionView");
        }
    }
}
