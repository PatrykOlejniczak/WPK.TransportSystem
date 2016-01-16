using GalaSoft.MvvmLight.Views;

namespace Mobile.ViewModel.Helpers
{
    public interface IExpandedNavigation : INavigationService
    {
        bool CanGoBack { get; }
        bool RemoveBackEntry();
    }
}