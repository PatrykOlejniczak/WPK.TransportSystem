using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Mobile.Model;
using Mobile.ViewModel.Helpers;

namespace Mobile.ViewModel
{
    public class ChooseTicketTypeViewModel : ViewModelBase
    {
        public IAccountManager AccountManager { get; private set; }
        public IExpandedNavigation NavigationService { get; private set; }
        public ITicketProvider TicketProvider { get; private set; }

        private ObservableCollection<Ticket> _oneTimeTickets;
        public ObservableCollection<Ticket> OneTimeTickets
        {
            get { return _oneTimeTickets; }
            set
            {
                if (value != null && _oneTimeTickets != value)
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
                if (value != null && _seasonTickets != value)
                {
                    _seasonTickets = value;
                }

                RaisePropertyChanged();
            }
        }

        private Ticket _selectedTicket;
        public Ticket SelectedTicket
        {
            get
            {
                return _selectedTicket;
            }
            set
            {
                _selectedTicket = value;
                Messenger.Default.Send(_selectedTicket);
                RaisePropertyChanged();
                NavigateToBuyTicketCount.Execute(null);
            }
        }

        private ObservableCollection<Ticket> _downloadedTickets;
        public ICommand NavigateToBuyTicketCount { get; private set; }
        public ChooseTicketTypeViewModel(
            IExpandedNavigation navigationService, ITicketProvider ticketProvider, IAccountManager accountManager)
        {
            NavigationService = navigationService;
            TicketProvider = ticketProvider;
            AccountManager = accountManager;

            OneTimeTickets = new ObservableCollection<Ticket>();
            SeasonTickets = new ObservableCollection<Ticket>();

            DownloadTickets();
        }

        private async void DownloadTickets()
        {
            _downloadedTickets = await TicketProvider.GetAllAsync();

            if (_downloadedTickets != null)
            {
                SeparateToGroups();
            }

            NavigateToBuyTicketCount
                = new RelayCommand(ExecuteNavigateToBuyTicketCount);
        }

        private void ExecuteNavigateToBuyTicketCount()
        {
            NavigationService.NavigateTo("BuyTicketCountView");
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