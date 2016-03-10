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
        BusStop[] busStopArray;
        BusStopDetails busStopDetails;

        public BusStopControl(ClientCredentials clientCredentials)
        {
            InitializeComponent();

            BusStopService = new BusStopServiceClient();
            BusStopService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            BusStopService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

        }

        public void FillData()
        {
            busStopArray = BusStopService.GetAll();

            ListBox.ItemsSource = busStopArray;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListBox.SelectedItem != null)
            {
                busStopDetails = new BusStopDetails(BusStopService.ClientCredentials, (BusStop)ListBox.SelectedItem);
                busStopDetails.RefreshAll += BusStopDetails_RefreshAll;
                this.RightContentControl.Content = busStopDetails;
            }
        }

        private void BusStopDetails_RefreshAll(object sender, EventArgs e)
        {
            FillData();
            this.RightContentControl.Content = null;
            busStopDetails = null;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            busStopDetails = new BusStopDetails(BusStopService.ClientCredentials);
            busStopDetails.RefreshAll += BusStopDetails_RefreshAll;
            RightContentControl.Content = busStopDetails;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchedText = SearchTextBox.Text;
            List<BusStop> searchedCustomers = new List<BusStop>();

            for (int i = 0; i < busStopArray.Length; i++)
            {
                if (CheckSearchedText(searchedText, busStopArray[i]))
                {
                    searchedCustomers.Add(busStopArray[i]);
                }
            }

            ListBox.ItemsSource = searchedCustomers;
        }

        private bool CheckSearchedText(string text, BusStop busStop)
        {
            try
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] != busStop.Name[i])
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
