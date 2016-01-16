using GalaSoft.MvvmLight;
using Mobile.ViewModel.Helpers;

namespace Mobile.ViewModel
{
    public class TimetableViewModel : ViewModelBase
    {
        private readonly IExpandedNavigation _expandedNavigation;
        private readonly ITimetableProvider _timetableProvider;

        public TimetableViewModel(IExpandedNavigation expandedNavigation, ITimetableProvider timetableProvider)
        {
            _expandedNavigation = expandedNavigation;
            _timetableProvider = timetableProvider;
        }
    }
}