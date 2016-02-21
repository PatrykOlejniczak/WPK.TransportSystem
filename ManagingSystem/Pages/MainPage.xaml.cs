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
using System.ServiceModel.Description;

namespace ManagingSystem.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        UserControlManager ucm;

        public MainPage(ClientCredentials cc)
        {
            InitializeComponent();

            ucm = new UserControlManager();
            ucm.SetClientCredentials(cc);

            LoggedUsername.Text = cc.UserName.UserName;
        }

        private void NewsButton_Click(object sender, RoutedEventArgs e)
        {
            ucm.OpenNews();
            this.MainContentControl.Content = ucm.News;
        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            ucm.OpenSchedule();
            this.MainContentControl.Content = ucm.BusSchedule;
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            ucm.OpenEmployees();
            this.MainContentControl.Content = ucm.Employees;
        }

        private void TicketsMainButton_Click(object sender, RoutedEventArgs e)
        {
            ucm.OpenTickets();
            this.MainContentControl.Content = ucm.Tickets;
            
        }

        private void ClientsMainButton_Click(object sender, RoutedEventArgs e)
        {
            ucm.OpenClients();
            this.MainContentControl.Content = ucm.Clients;
        }

        private void StatisticsMainButton_Click(object sender, RoutedEventArgs e)
        {
            ucm.OpenStatistics();
            this.MainContentControl.Content = ucm.Statistics;
        }

        private void CareerMainButton_Click(object sender, RoutedEventArgs e)
        {
            ucm.OpenCareer();
            this.MainContentControl.Content = ucm.Career;
        }

        private void QuestionnaireMainButton_Click(object sender, RoutedEventArgs e)
        {
            ucm.OpenQuestionnaire();
            this.MainContentControl.Content = ucm.Questionnaire;
        }
    }
}
