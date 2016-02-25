using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
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
using ManagingSystem.BusStopService;
using ManagingSystem.Pages.UserControls.DetailsUserControl;

namespace ManagingSystem.Pages.UserControls
{
    /// <summary>
    /// Interaction logic for BusStopControl.xaml
    /// </summary>
    public partial class BusStopControl : UserControl
    {
        BusStopServiceClient BusStopService { get; set; }

        BusStop[] busStopList;

        public BusStopControl(ClientCredentials clientCredentials)
        {
            InitializeComponent();

            BusStopService = new BusStopServiceClient();
            BusStopService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            BusStopService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

        }

        public void FillData()
        {
            busStopList = BusStopService.GetAll();

            ListBox.ItemsSource = busStopList;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            BusStopDetails newBusStop = new BusStopDetails(BusStopService.ClientCredentials);
            RightContentControl.Content = newBusStop;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
