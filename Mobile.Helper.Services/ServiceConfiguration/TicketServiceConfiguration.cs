using System.ServiceModel;
using Mobile.Helper.Services.TicketService;

namespace Mobile.Helper.Services.ServiceConfiguration
{
    public class TicketServiceConfiguration
    {
        public TicketServiceClient TicketServiceClient { get; private set; }

        public TicketServiceConfiguration()
        {
            BasicHttpBinding httpBinding = new BasicHttpBinding();

            TicketServiceClient =
                new TicketServiceClient(httpBinding, EndPoints.TicketService);
        } 
    }
}