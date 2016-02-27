using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Mobile.Helper.Services.BusStopOnLineService;
using Mobile.Helper.Services.TimetableService;
using Mobile.Model;
using Mobile.ViewModel.Helpers;

namespace Mobile.Helper.Services.InjectProviders
{
    public class TimetableProvider : ITimetableProvider
    {
        private readonly TimetableServiceClient _client;
        private readonly BusStopOnLineServiceClient _busStopClient;

        public TimetableProvider()
        {
            _client = new TimetableServiceClient();
            _busStopClient = new BusStopOnLineServiceClient();
        }

        public async Task<ObservableCollection<TimeSpan>> GetTimetable(int actualBusStopId, int LineId, bool direction)
        {
            var timetable = await _client.GetAllAsync();
            var busStopOnLine = await _busStopClient.GetAllAsync();
            var returnValue = new List<TimeSpan>();

            foreach (var _timetable in timetable)
            {
                if (_timetable.BusStopOnLineId == busStopOnLine.First(b => b.BusStopId == actualBusStopId && b.LineId == LineId && b.Direction == direction).Id)
                {
                    returnValue.Add(_timetable.DepartureTime);
                }
            }

            return new ObservableCollection<TimeSpan>(returnValue);
        }
    }
}