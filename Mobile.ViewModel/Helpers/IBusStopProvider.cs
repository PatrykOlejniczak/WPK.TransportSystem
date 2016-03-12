using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mobile.Model;

namespace Mobile.ViewModel.Helpers
{
    public interface IBusStopProvider
    {
        Task<ObservableCollection<BusStop>> GetAllOnLine(int lineId, bool direction);
    }
}