using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Mobile.ViewModel.Helpers;
using Mobile.Model;

namespace Mobile.ViewModel
{
    public class PurchaseHistoryViewModel : ViewModelBase
    {
        private readonly ICustomerOperationProvider _customerOperationProvider;

        public PurchaseHistoryViewModel(
            ICustomerOperationProvider customerOperationProvider)
        {
            _customerOperationProvider = customerOperationProvider;

            if (PurchaseTicketsTask == null)
            {
                RefreshPurchaseCollection();
            }             
        }

        public NotifyTaskCompletion<ObservableCollection<PurchaseTicket>> PurchaseTicketsTask
        {
            get;
            private set;
        }

        private void RefreshPurchaseCollection()
        {
            PurchaseTicketsTask
                = new NotifyTaskCompletion<ObservableCollection<PurchaseTicket>>
                (_customerOperationProvider.GetAllPurchaseTicketAsync());
        }
             
    }
}