using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mobile.Model;

namespace Mobile.ViewModel.Helpers
{
    public interface ILineProvider
    {
        Task<Line> GetLineInfo();
        Task<ObservableCollection<BusStop>> GetAllBusStopOnLine(Line line);
    }
}