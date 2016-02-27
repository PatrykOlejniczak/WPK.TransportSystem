using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Mobile.Helper.Services.BusStopOnLineService;
using Mobile.Helper.Services.BusStopService;
using Mobile.ViewModel.Helpers;
using BusStop = Mobile.Model.BusStop;

namespace Mobile.Helper.Services.InjectProviders
{
    public class BusStopProvider : IBusStopProvider
    {
        private readonly BusStopServiceClient _busStopClient;
        private readonly BusStopOnLineServiceClient _busStopOnLineClient;

        public BusStopProvider()
        {
            _busStopClient = new BusStopServiceClient();
            _busStopOnLineClient = new BusStopOnLineServiceClient();
        }

        public async Task<ObservableCollection<BusStop>> GetAllOnLine(int lineId, bool direction)
        {
            var busStops = await _busStopOnLineClient.GetAllAsync();
            List<BusStopService.BusStop> returnValue = new List<BusStopService.BusStop>();

            foreach (var busStopOnLine in busStops)
            {
                if (busStopOnLine.Direction == direction && busStopOnLine.LineId == lineId)
                {
                    returnValue.Add(await _busStopClient.GetByIdAsync(busStopOnLine.BusStopId));
                }
            }

            AutoMapper.Mapper.CreateMap<BusStopService.BusStop, BusStop>();
            AutoMapper.Mapper.CreateMap<BusStop, BusStopService.BusStop>();
            var converted = AutoMapper.Mapper.Map<IEnumerable<BusStop>>(returnValue);

            return new ObservableCollection<BusStop>(converted);
        }
    }
}