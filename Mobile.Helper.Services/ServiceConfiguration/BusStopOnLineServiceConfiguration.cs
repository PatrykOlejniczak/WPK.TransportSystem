using System.ServiceModel;
using Mobile.Helper.Services.BusStopOnLineService;

namespace Mobile.Helper.Services.ServiceConfiguration
{
    public class BusStopOnLineServiceConfiguration
    {
        public BusStopOnLineServiceClient TicketServiceClient { get; private set; }

        public BusStopOnLineServiceConfiguration()
        {
            BasicHttpBinding httpBinding = new BasicHttpBinding();

            TicketServiceClient =
                new BusStopOnLineServiceClient(httpBinding, EndPoints.BusStopOnLineService);
        }
    }
}