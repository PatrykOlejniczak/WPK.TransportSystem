using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mobile.Model;

namespace Mobile.ViewModel.Helpers
{
    public interface ITimetableProvider
    {
        Task<ObservableCollection<TimeSpan>> GetTimetable(int actualBusStopId, int LineId, bool direction);
    }
}