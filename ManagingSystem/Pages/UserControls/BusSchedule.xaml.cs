using ManagingSystem.Interface;
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
using System.ServiceModel.Description;
using ManagingSystem.BusStopOnLineService;
using ManagingSystem.Pages.UserControls.DetailsUserControl;
using ManagingSystem.LineService;

namespace ManagingSystem.Pages.UserControls
{
    /// <summary>
    /// Interaction logic for BusSchedule.xaml
    /// </summary>
    public partial class BusSchedule : UserControl
    {
        private LineServiceClient LineService;
        private Line[] LineArray { get; set; }
        private BusScheduleDetails BusStopDetails { get; set; }

        public BusSchedule(ClientCredentials clientCredentials)
        {
            InitializeComponent();

            LineService = new LineServiceClient();
            LineService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            LineService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;
        }

        public void FillData()
        {
            try
            {
                LineArray = LineService.GetAll();
                ListBox.ItemsSource = LineArray;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Wystąpił błąd", MessageBoxButton.OK);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BusStopDetails = new BusScheduleDetails(LineService.ClientCredentials, (Line)ListBox.SelectedItem);
            BusStopDetails.RefreshAll += BusStopDetails_RefreshAll;
            this.DetailsContentControl.Content = BusStopDetails;
        }

        private void BusStopDetails_RefreshAll(object sender, EventArgs e)
        {
            FillData();
            this.DetailsContentControl.Content = null;
            BusStopDetails = null;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            BusStopDetails = new BusScheduleDetails(LineService.ClientCredentials);
            BusStopDetails.RefreshAll += BusStopDetails_RefreshAll;
            this.DetailsContentControl.Content = BusStopDetails;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchedText = SearchTextBox.Text;
            List<Line> searchedCustomers = new List<Line>();

            for (int i = 0; i < LineArray.Length; i++)
            {
                if (CheckSearchedText(searchedText, LineArray[i]))
                {
                    searchedCustomers.Add(LineArray[i]);
                }
            }

            ListBox.ItemsSource = searchedCustomers;
        }

        private bool CheckSearchedText(string text, Line line)
        {
            try
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] != line.Name[i])
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
