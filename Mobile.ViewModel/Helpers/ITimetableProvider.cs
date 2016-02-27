using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Mobile.ViewModel.Helpers
{
    public interface ITimetableProvider
    {
        Task<ObservableCollection<TimeSpan>> GetTimetable(int busStopId, int lineId, bool direction);
    }
}