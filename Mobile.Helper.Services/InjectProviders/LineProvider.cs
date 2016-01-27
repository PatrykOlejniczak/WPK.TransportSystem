using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mobile.Model;
using Mobile.ViewModel.Helpers;

namespace Mobile.Helper.Services.InjectProviders
{
    public class LineProvider : ILineProvider
    {
        public Task<Line> GetLineInfo()
        {
            throw new System.NotImplementedException();
        }

        public Task<ObservableCollection<BusStop>> GetAllBusStopOnLine(Line line)
        {
            throw new System.NotImplementedException();
        }
    }
}