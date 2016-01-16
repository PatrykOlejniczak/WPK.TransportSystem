using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Mobile.Model;
using Mobile.ViewModel.Helpers;

namespace Mobile.ViewModel
{
    public class ChooseTicketTypeViewModel : ViewModelBase
    {
        public IExpandedNavigation NavigationService { get; private set; }
        public ITicketProvider TicketProvider { get; private set; }

        private ObservableCollection<Ticket> _oneTimeTickets;
        public ObservableCollection<Ticket> OneTimeTickets
        {
            get { return _oneTimeTickets; }
            set
            {
                if (_oneTimeTickets != null && _oneTimeTickets != value)
                {
                    _oneTimeTickets = value;
                }

                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Ticket> _seasonTickets;

        public ObservableCollection<Ticket> SeasonTickets
        {
            get { return _seasonTickets; }
            set
            {
                if (_seasonTickets != null && _seasonTickets != value)
                {
                    _seasonTickets = value;
                }

                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Ticket> _downloadedTickets; 

        public ChooseTicketTypeViewModel(
            IExpandedNavigation navigationService, ITicketProvider ticketProvider)
        {
            NavigationService = navigationService;
            TicketProvider = ticketProvider;
            
            OneTimeTickets = new ObservableCollection<Ticket>();
            SeasonTickets = new ObservableCollection<Ticket>();

            SeasonTickets = new ObservableCollection<Ticket>();
            OneTimeTickets = new ObservableCollection<Ticket>();

            DownloadTickets();
        }

        private async void DownloadTickets()
        {
            _downloadedTickets = await TicketProvider.GetAllAsync();

            if (_downloadedTickets != null)
            {
                SeparateToGroups();
            }
        }

        private void SeparateToGroups()
        {
            foreach (var downloadedTicket in _downloadedTickets)
            {
                if (downloadedTicket.TicketTypeId == 1)
                {
                    SeasonTickets.Add(downloadedTicket);
                }
                else
                {
                    OneTimeTickets.Add(downloadedTicket);
                }
            }
        }
    }
}