using Mobile.Model;

namespace Mobile.ViewModel.Messages
{
    public class TimetableStatus
    {
        public Line Line { get; set; }
        public BusStop StartBusStop { get; set; }
        public BusStop LastBusStop { get; set; }
        public BusStop ActualBusStop { get; set; }
    }
}