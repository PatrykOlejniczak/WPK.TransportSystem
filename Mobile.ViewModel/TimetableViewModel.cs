using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Mobile.Model;
using Mobile.ViewModel.Helpers;
using Mobile.ViewModel.Messages;

namespace Mobile.ViewModel
{
    public class TimetableViewModel : ViewModelBase
    {
        private BusStop _actualBusStop;
        public BusStop ActualBusStop
        {
            get { return _actualBusStop;}
            private set
            {
                if (value != _actualBusStop)
                {
                    _actualBusStop = value;
                    RaisePropertyChanged();
                }
            }
        }

        private BusStop _firstBusStop;
        public BusStop FirstBusStop
        {
            get { return _firstBusStop; }
            private set
            {
                if (_firstBusStop != value)
                {
                    _firstBusStop = value;
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
                if (_lastBusStop != value)
                {
                    _lastBusStop = value;
                    RaisePropertyChanged();
                }
            }
        }

        private Line _line;
        public Line Line
        {
            get { return _line; }
            private set
            {
                if (value != _line)
                {
                    _line = value;
                    RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<ObservableCollection<TimeSpan>> _timetable;
        public ObservableCollection<ObservableCollection<TimeSpan>> Timetable
        {
            get { return _timetable; }
            private set
            {
                if (Timetable != value)
                {
                    _timetable = value;
                    RaisePropertyChanged();
                }
            }
        }  

        private readonly ITimetableProvider _timetableProvider;
        

        public TimetableViewModel(ITimetableProvider timetableProvider)
        {
            _timetableProvider = timetableProvider;

            Messenger.Default.Register<TimetableStatus>(this, UpdateVariables);
        }

        private void UpdateVariables(TimetableStatus timetableStatus)
        {
            ActualBusStop = timetableStatus.ActualBusStop;
            FirstBusStop = timetableStatus.StartBusStop;
            LastBusStop = timetableStatus.LastBusStop;
            Line = timetableStatus.Line;
            UpdateTimetable();
        }

        private async void UpdateTimetable()
        {
            var timetable = await _timetableProvider.GetTimetable(ActualBusStop.Id, Line.Id, Line.Direction);

            Timetable = new ObservableCollection<ObservableCollection<TimeSpan>>();

            for (int i = 0; i < 24; i++)
            {
                Timetable.Add(new ObservableCollection<TimeSpan>());
            }

            foreach (var timeSpan in timetable)
            {
                Timetable[timeSpan.Hours].Add(timeSpan);
            }
        }
    }
}