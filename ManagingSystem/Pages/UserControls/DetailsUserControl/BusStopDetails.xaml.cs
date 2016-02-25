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
using ManagingSystem.BusStopTypeService;
using ManagingSystem.BusStopService;
using System.ServiceModel.Description;

namespace ManagingSystem.Pages.UserControls.DetailsUserControl
{
    /// <summary>
    /// Interaction logic for BusStopDetails.xaml
    /// </summary>
    public partial class BusStopDetails : UserControl
    {
        public BusStopService.BusStopServiceClient busStopService;
        public BusStopService.BusStopSecureServiceClient busStopSecureService;
        public BusStopTypeService.BusStopServiceClient busStopTypeService;
        public BusStopTypeService.BusStopSecureServiceClient busStopTypeSecureService;
        public BusStopService.BusStop ActualBusStop { get; set; }
        public BusStopDetails(ClientCredentials clientCredentials)
        {
            InitializeComponent();
            ActualBusStop = new BusStopService.BusStop();

            busStopService = new BusStopService.BusStopServiceClient();

            busStopSecureService = new BusStopService.BusStopSecureServiceClient();
            busStopSecureService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            busStopSecureService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            busStopTypeService = new BusStopTypeService.BusStopServiceClient();
            busStopTypeService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            busStopTypeService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            busStopTypeSecureService = new BusStopTypeService.BusStopSecureServiceClient();
            busStopTypeSecureService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            busStopTypeSecureService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;


            OpenAllTextBoxes();
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
        }

        public BusStopDetails(ClientCredentials clientCredentials, BusStopService.BusStop busStop)
        {
            InitializeComponent();
            ActualBusStop = busStop;

            busStopService = new BusStopService.BusStopServiceClient();

            busStopSecureService = new BusStopService.BusStopSecureServiceClient();
            busStopSecureService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            busStopSecureService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            busStopTypeService = new BusStopTypeService.BusStopServiceClient();
        }

        private void OpenAllTextBoxes()
        {
            NameTextBox.IsEnabled = true;
            StreetTextBox.IsEnabled = true;
            BusStopTypeListView.IsEnabled = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
