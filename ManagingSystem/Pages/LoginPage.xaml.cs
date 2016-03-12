using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ManagingSystem.UserAccountService;
using System.Security.Policy;
using ManagingSystem.EmployeeAuthenticationService;

namespace ManagingSystem.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private UserAccountSecureServiceClient UserAccountSC;
        EmployeeAuthenticationClient employeeAuthentication;
        private MainWindow thisWindow;
        public LoginPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            employeeAuthentication = new EmployeeAuthenticationClient();
            UserAccountSC = new UserAccountSecureServiceClient();
            thisWindow = _mainWindow;
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string qwer = PasswordTextBox.Password;
            try
            {
                //employeeAuthentication.IsAccountExists(LoginTextBox.Text);
                //if (employeeAuthentication.IsCorrectCredentialsCorrect(LoginTextBox.Text, PasswordTextBox.Text))
                //{
                //    UserAccountSC.ClientCredentials.UserName.UserName = LoginTextBox.Text;
                //    UserAccountSC.ClientCredentials.UserName.Password = PasswordTextBox.Text;
                //    MainPage mainPage = new MainPage(UserAccountSC.ClientCredentials);
                //    thisWindow.Content = mainPage;
                //}
                employeeAuthentication.IsAccountExists(LoginTextBox.Text);
                if (employeeAuthentication.IsCorrectCredentialsCorrect(LoginTextBox.Text, PasswordTextBox.Password))
                {
                    UserAccountSC.ClientCredentials.UserName.UserName = LoginTextBox.Text;
                    UserAccountSC.ClientCredentials.UserName.Password = PasswordTextBox.Password;
                    MainPage mainPage = new MainPage(UserAccountSC.ClientCredentials);
                    thisWindow.Content = mainPage;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informacja", MessageBoxButton.OK);
            }



        }
    }
}
