using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mobile.ViewModel.Helpers;

namespace Mobile.Helper.Services.InjectProviders
{
    public class TimetableProvider : ITimetableProvider
    {
        public async Task<ObservableCollection<TimeSpan>> GetTimetable(int busStopId, int lineId, bool direction)
        {
            var timetable = new ObservableCollection<TimeSpan>()
            {
                new TimeSpan(1, 10, 0), new TimeSpan(1, 20, 0), new TimeSpan(1, 45, 0), new TimeSpan(1, 55, 0),
                new TimeSpan(2, 10, 0), new TimeSpan(2, 20, 0), new TimeSpan(2, 45, 0), new TimeSpan(2, 55, 0),
                new TimeSpan(3, 10, 0), new TimeSpan(3, 20, 0), new TimeSpan(3, 45, 0), new TimeSpan(3, 55, 0),
                new TimeSpan(4, 10, 0), new TimeSpan(4, 20, 0), new TimeSpan(4, 45, 0), new TimeSpan(4, 55, 0),
                new TimeSpan(5, 10, 0), new TimeSpan(5, 20, 0), new TimeSpan(5, 45, 0), new TimeSpan(5, 55, 0),
                new TimeSpan(6, 10, 0), new TimeSpan(6, 20, 0), new TimeSpan(6, 45, 0), new TimeSpan(6, 55, 0),
                new TimeSpan(7, 10, 0), new TimeSpan(7, 20, 0), new TimeSpan(7, 45, 0), new TimeSpan(7, 55, 0),
                new TimeSpan(8, 10, 0), new TimeSpan(8, 20, 0), new TimeSpan(8, 45, 0), new TimeSpan(8, 55, 0),
                new TimeSpan(9, 10, 0), new TimeSpan(9, 20, 0), new TimeSpan(9, 45, 0), new TimeSpan(9, 55, 0),
                new TimeSpan(10, 10, 0 ), new TimeSpan(10, 20, 0), new TimeSpan(10, 45, 0), new TimeSpan(10, 55, 0),
                new TimeSpan(11, 10, 0 ), new TimeSpan(11, 20, 0), new TimeSpan(11, 45, 0), new TimeSpan(11, 55, 0),
                new TimeSpan(12, 10, 0 ), new TimeSpan(12, 20, 0), new TimeSpan(12, 45, 0), new TimeSpan(12, 55, 0),
                new TimeSpan(13, 10, 0 ), new TimeSpan(13, 20, 0), new TimeSpan(13, 45, 0), new TimeSpan(13, 55, 0),                          
            };

            return timetable;
        }
    }
}