using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Networking.Proximity;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Mobile.ViewModel.Helpers;
using Mobile.Model;

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

            PurchaseTickets = new ObservableCollection<PurchaseTicket>();
            
            PurchaseTicketsTask 
                = new NotifyTaskCompletion<ObservableCollection<PurchaseTicket>>
                (_customerOperationProvider.GetAllPurchaseTicketAsync());            
        }

        private ObservableCollection<PurchaseTicket> _purchaseTickets;

        public ObservableCollection<PurchaseTicket> PurchaseTickets
        {
            get
            {
                return _purchaseTickets;
            }
            private set
            {
                if (value != null)
                {
                    _purchaseTickets = value;
                }
                RaisePropertyChanged();
            }
        }

        public NotifyTaskCompletion<ObservableCollection<PurchaseTicket>> PurchaseTicketsTask { get; private set; }
             
    }
}