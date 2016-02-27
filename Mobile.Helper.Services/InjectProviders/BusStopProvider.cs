using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Mobile.Model;
using Mobile.ViewModel.Helpers;

namespace Mobile.Helper.Services.InjectProviders
{
    public class BusStopProvider : IBusStopProvider
    {
        public async Task<ObservableCollection<BusStop>> GetAllOnLine(int lineId, bool direction)
        {
            var test = new ObservableCollection<BusStop>()
            {
                new BusStop() { IsFavorite = true,  Name = "Jezioraka", NumberOnLine = 0 },
                new BusStop() { IsFavorite = false, Name = "Władysława", NumberOnLine = 1 },
                new BusStop() { IsFavorite = false, Name = "Czesława", NumberOnLine = 2 },
                new BusStop() { IsFavorite = false, Name = "Marcina", NumberOnLine = 3 },
                new BusStop() { IsFavorite = true,  Name = "Tomka", NumberOnLine = 4 },
                new BusStop() { IsFavorite = false, Name = "Bolka", NumberOnLine = 5 },
                new BusStop() { IsFavorite = false, Name = "Agenta", NumberOnLine = 6 }
            };

            if (direction)
            {
                var k = test.OrderByDescending(b => b.NumberOnLine);
                return new ObservableCollection<BusStop>(k);
            }
            return test;
        }
    }
}