using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mobile.Model;
using Mobile.ViewModel.Helpers;

namespace Mobile.Helper.Services.InjectProviders
{
    public class BusStopProvider : IBusStopProvider
    {
        public async Task<ObservableCollection<BusStop>> GetAllOnLine(int lineId, bool direction)
        {
            return new ObservableCollection<BusStop>()
            {
                new BusStop() { IsFavorite = true, Name = "Blabla 1", NumberOnLine = 0 },
                new BusStop() { IsFavorite = false, Name = "Blabla 2", NumberOnLine = 1 },
                new BusStop() { IsFavorite = false, Name = "Blabla 3", NumberOnLine = 2 },
                new BusStop() { IsFavorite = false, Name = "Blabla 4", NumberOnLine = 3 },
                new BusStop() { IsFavorite = true, Name = "Blabla 5", NumberOnLine = 4 },
                new BusStop() { IsFavorite = false, Name = "Blabla 6", NumberOnLine = 5 },
                new BusStop() { IsFavorite = false, Name = "Blabla 7", NumberOnLine = 6 }
            };
        }
    }
}