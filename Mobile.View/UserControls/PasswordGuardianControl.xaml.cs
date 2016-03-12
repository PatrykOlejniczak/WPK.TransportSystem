using Windows.UI.Xaml.Controls;
using Mobile.ViewModel.Helpers;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Mobile.View.UserControls
{
    public sealed partial class PasswordGuardianControl : UserControl, IPasswordGuardian
    {
        public PasswordGuardianControl()
        {
            this.InitializeComponent();
        }

        public string Password => PasswordBox.Password;
    }
}
