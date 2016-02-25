using System.ServiceModel;
using Mobile.Helper.Services.LineService;

namespace Mobile.Helper.Services.ServiceConfiguration
{
    public class LineServiceConfiguration
    {
        public LineServiceClient LineServiceClient { get; private set; }

        public LineServiceConfiguration()
        {
            BasicHttpBinding httpBinding = new BasicHttpBinding();

            LineServiceClient =
                new LineServiceClient(httpBinding, EndPoints.LineService);
        }
    }
}