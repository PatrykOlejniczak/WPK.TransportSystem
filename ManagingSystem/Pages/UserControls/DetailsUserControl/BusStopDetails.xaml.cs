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
        public event EventHandler RefreshAll;
        BusStopServiceClient busStopService;
        BusStopSecureServiceClient busStopSecureService;
        BusStopTypeServiceClient busStopTypeService;
        BusStopTypeSecureServiceClient busStopTypeSecureService;
        BusStop ActualBusStop { get; set; }

        bool IsAddingNewObject;
        public BusStopDetails(ClientCredentials clientCredentials)
        {
            InitializeComponent();
            ActualBusStop = new BusStop();

            busStopService = new BusStopServiceClient();

            busStopSecureService = new BusStopSecureServiceClient();
            busStopSecureService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            busStopSecureService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            busStopTypeService = new BusStopTypeServiceClient();
            busStopTypeService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            busStopTypeService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            busStopTypeSecureService = new BusStopTypeSecureServiceClient();
            busStopTypeSecureService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            busStopTypeSecureService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            BusStopTypeComboBox.ItemsSource = busStopTypeService.GetAll();

            OpenAllTextBoxes();
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;

            IsAddingNewObject = true;
        }

        public BusStopDetails(ClientCredentials clientCredentials, BusStop busStop)
        {
            InitializeComponent();
            ActualBusStop = busStop;

            busStopService = new BusStopServiceClient();

            busStopSecureService = new BusStopSecureServiceClient();
            busStopSecureService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            busStopSecureService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            busStopTypeService = new BusStopTypeServiceClient();
            busStopTypeService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            busStopTypeService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            busStopTypeSecureService = new BusStopTypeSecureServiceClient();
            busStopTypeSecureService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            busStopTypeSecureService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            BusStopTypeComboBox.ItemsSource = busStopTypeService.GetAll();
            FillData();
        }

        private void FillData()
        {
            NameTextBox.Text = ActualBusStop.Name;
            StreetTextBox.Text = ActualBusStop.Street;

            foreach(BusStopType item in BusStopTypeComboBox.Items)
            {
                if (ActualBusStop.BusStopTypeId == item.Id)
                    BusStopTypeComboBox.SelectedItem = item;
            }
        }

        private void OpenAllTextBoxes()
        {
            NameTextBox.IsEnabled = true;
            StreetTextBox.IsEnabled = true;
            BusStopTypeComboBox.IsEnabled = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ActualBusStop.Name = NameTextBox.Text;

            BusStopType SelectedBusStopType = (BusStopType)BusStopTypeComboBox.SelectedItem;
            ActualBusStop.BusStopTypeId = SelectedBusStopType.Id.Value;
            ActualBusStop.Street = StreetTextBox.Text;

            if (IsAddingNewObject)
                busStopSecureService.Create(ActualBusStop);
            else
                busStopSecureService.Update(ActualBusStop);

            RefreshAll(this, new EventArgs());
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            OpenAllTextBoxes();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            busStopSecureService.DeleteById(ActualBusStop.Id.Value);
            RefreshAll(this, new EventArgs());
        }
    }
}
