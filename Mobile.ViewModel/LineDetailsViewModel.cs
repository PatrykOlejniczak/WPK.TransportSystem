using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Windows.Networking.Proximity;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Mobile.Model;
using Mobile.ViewModel.Helpers;

namespace Mobile.ViewModel
{
    public class LineDetailsViewModel : ViewModelBase
    {
        public ILineProvider LineProvider { get; private set; }
        public IExpandedNavigation NavigationService { get; private set; }
        public IDeviceManager DeviceManager { get; private set; }

        public ICommand LoadCommand { get; private set; }
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
                }
                RaisePropertyChanged();
            }
        }

        public NotifyTaskCompletion<ObservableCollection<BusStop>> BusStops
        { 
            get;
            private set;
        }

        public LineDetailsViewModel(
            ILineProvider lineProvider, IExpandedNavigation navigationService, IDeviceManager deviceManager)
        {
            LineProvider = lineProvider;
            NavigationService = navigationService;
            DeviceManager = deviceManager;

            Messenger.Default.Register<Line>(this, (choosedLine) => Line = choosedLine);

            LoadCommand = new RelayCommand(LoadExecute);
            AddToFavouriteCommand = new RelayCommand(AddToFavourtieExecute);
            ReturnTripCommand = new RelayCommand(ReturnTripExecute);
        }

        private void LoadExecute()
        {
             BusStops = 
                new NotifyTaskCompletion<ObservableCollection<BusStop>>(LineProvider.GetAllBusStopOnLine(Line));
        }

        private void ReturnTripExecute()
        {
            BusStops =
                new NotifyTaskCompletion<ObservableCollection<BusStop>>(LineProvider.GetAllBusStopOnLine(Line));
        }

        private void AddToFavourtieExecute()
        {
            //TODO
        }
    }
}