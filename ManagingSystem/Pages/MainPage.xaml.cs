using ManagingSystem.Class;
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
using ManagingSystem.EmployeeAuthenticationService;

namespace ManagingSystem.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private EmployeeAuthenticationClient EmployeeAuth { get; set; }
        UserControlManager ucm;
        DatabaseProvider databaseProvider;

        public MainPage(EmployeeAuthenticationClient employeeAuth)
        {
            InitializeComponent();

            EmployeeAuth = employeeAuth;
            ucm = new UserControlManager();
            databaseProvider = new DatabaseProvider();
        }

        private void NewsButton_Click(object sender, RoutedEventArgs e)
        {
            ucm.OpenNews(EmployeeAuth.ClientCredentials.UserName.UserName, EmployeeAuth.ClientCredentials.UserName.Password);
            this.MainContentControl.Content = ucm.News;
        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            this.MainContentControl.Content = ucm.Schedule;
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            ucm.OpenEmployees(EmployeeAuth.ClientCredentials.UserName.UserName,EmployeeAuth.ClientCredentials.UserName.Password);
            this.MainContentControl.Content = ucm.Employees;
        }

        private void TicketsMainButton_Click(object sender, RoutedEventArgs e)
        {
            ucm.OpenTickets(EmployeeAuth.ClientCredentials.UserName.UserName, EmployeeAuth.ClientCredentials.UserName.Password);
            this.MainContentControl.Content = ucm.Tickets;
            
        }

        private void ClientsMainButton_Click(object sender, RoutedEventArgs e)
        {
            ucm.OpenClients(EmployeeAuth.ClientCredentials.UserName.UserName, EmployeeAuth.ClientCredentials.UserName.Password);
            this.MainContentControl.Content = ucm.Clients;
        }
    }
}
