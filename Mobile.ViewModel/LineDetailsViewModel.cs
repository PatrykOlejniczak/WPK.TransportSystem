using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Mobile.Model;
using Mobile.ViewModel.Helpers;
using Mobile.ViewModel.Messages;

namespace Mobile.ViewModel
{
    public class LineDetailsViewModel : ViewModelBase
    {
        private readonly IBusStopProvider _lineDetailsProvider;
        private readonly IExpandedNavigation _navigationService;
        private bool _returnTrip;

        public ICommand AddToFavouriteCommand { get; private set; }
        public ICommand ReturnTripCommand { get; private set; }

        private Line _line;
        public Line Line {
            get { return _line; }
            private set
            {
                if (value != null)
                {
                    _line = value;
                    DownloadBusStops();
                    RaisePropertyChanged();
                }                
            }
        }

        private BusStop _lastBusStop;
        public BusStop LastBusStop
        {
            get { return _lastBusStop; }
            private set
            {
                if (value != null)
                {
                    _lastBusStop = value;
                    RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<BusStop> _busStops;
        public ObservableCollection<BusStop> BusStops
        { 
            get { return _busStops; }
            private set
            {
                if (value != null && value != _busStops)
                {
                    _busStops = value;
                    LastBusStop = value.Last();
                    RaisePropertyChanged();
                }
            }
        }

        private BusStop _selectedBusStop;
        public BusStop SelectedBusStop
        {
            get { return _selectedBusStop; }
            set
            {
                if (value != _selectedBusStop)
                {
                    _selectedBusStop = value;
                    if (value != null)
                    {
                        NavigateToTimetable();
                    }
                    RaisePropertyChanged();
                }
            }
        }

        public LineDetailsViewModel(IExpandedNavigation navigationService,
            IBusStopProvider lineDetailsProvider)
        {
            _navigationService = navigationService;
            _lineDetailsProvider = lineDetailsProvider;

            Messenger.Default.Register<LineStatus>(this, (message) => Line = message.Line);

            AddToFavouriteCommand = new RelayCommand(AddToFavourtieExecute);
            ReturnTripCommand = new RelayCommand(ReturnTripExecute);
        }

        private void NavigateToTimetable()
        {
            Messenger.Default.Send(new TimetableStatus()
            {
                Line = Line,
                StartBusStop = BusStops.First(),
                LastBusStop = BusStops.Last(),
                ActualBusStop = SelectedBusStop
            });

            _navigationService.NavigateTo("TimetableView");
        }

        private async void DownloadBusStops()
        {
            BusStops = await _lineDetailsProvider.GetAllOnLine(Line.Id, _returnTrip);
        }

        private async void ReturnTripExecute()
        {
            _returnTrip = !_returnTrip;
            BusStops = await _lineDetailsProvider.GetAllOnLine(Line.Id, _returnTrip);
        }

        private void AddToFavourtieExecute()
        {
            //TODO
        }
    }
}