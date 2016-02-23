using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Views;
using Mobile.ViewModel.Helpers;

namespace Mobile.View.Helpers
{
    public class ExpandedNavigation : NavigationService, IExpandedNavigation
    {
        public bool CanGoBack
        {
            get
            {
                var frame = GetMainFrame();
                if (frame != null)
                    return frame.CanGoBack;

                return false;
            }
        }

        public bool RemoveBackEntry()
        {
            var frame = GetMainFrame();

            if (frame.CanGoBack)
            {
                frame.BackStack.RemoveAt(frame.BackStackDepth - 1);
                return true;
            }

            return false;
        }

        private Frame GetMainFrame()
        {
            return (Frame)Window.Current.Content;
        }
    }
}