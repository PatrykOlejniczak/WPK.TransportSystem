using System.Collections.Generic;
using Mobile.Model;

namespace Mobile.ViewModel.Helpers
{
    public interface IDeviceManager
    {
        string GetDeviceId();

        List<BusStop> GetFavoriteBusStop(Line line);
        void AddLineToFavourite(Line line);
    }
}