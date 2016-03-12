using System.ServiceModel;
using Mobile.Helper.Services.BusStopService;

namespace Mobile.Helper.Services.ServiceConfiguration
{
    public class BusStopServiceConfiguration
    {
        public BusStopServiceClient BusStopServiceClient { get; private set; }

        public BusStopServiceConfiguration()
        {
            BasicHttpBinding httpBinding = new BasicHttpBinding();

            BusStopServiceClient =
                new BusStopServiceClient(httpBinding, EndPoints.BusStopOnLineService);
        }
    }
}