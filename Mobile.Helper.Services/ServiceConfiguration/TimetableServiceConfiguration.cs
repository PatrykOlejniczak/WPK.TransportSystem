using System.ServiceModel;
using Mobile.Helper.Services.TimetableService;

namespace Mobile.Helper.Services.ServiceConfiguration
{
    public class TimetableServiceConfiguration
    {
        public TimetableServiceClient TimetableServiceClient { get; private set; }

        public TimetableServiceConfiguration()
        {
            BasicHttpBinding httpBinding = new BasicHttpBinding();

            TimetableServiceClient =
                new TimetableServiceClient(httpBinding, EndPoints.TimetableService);
        }
    }
}