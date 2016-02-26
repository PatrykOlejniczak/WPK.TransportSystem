using ManagingSystem.BusStopService;
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

using ManagingSystem.BusStopOnLineService;
using ManagingSystem.LineService;
using System.ServiceModel.Description;

namespace ManagingSystem.Pages.UserControls.DetailsUserControl
{
    /// <summary>
    /// Interaction logic for BusScheduleDetails.xaml
    /// </summary>
    public partial class BusScheduleDetails : UserControl
    {
        public event EventHandler RefreshAll;
        BusStopOnLineServiceClient BusStopOnLineService { get; set; }
        BusStopOnLineSecureServiceClient BusStopOnLineSecureService { get; set; }
        BusStopServiceClient BusStopService { get; set; }
        LineServiceClient LineService { get; set; }
        LineSecureServiceClient LineSecureService { get; set; }

        Line SelectedLine { get; set; }
        BusStopOnLine[] SelectedBSOL;
        BusStop[] SelectedBusStopArray;
        bool IsNewObjectEnable;
        public BusScheduleDetails(ClientCredentials clientCredentials)
        {
            InitializeComponent();
            SelectedLine = new Line();
            BusStopService = new BusStopServiceClient();
            LineService = new LineServiceClient();
            LineSecureService = new LineSecureServiceClient();
            LineSecureService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            LineSecureService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;
            BusStopOnLineSecureService = new BusStopOnLineSecureServiceClient();
            BusStopOnLineSecureService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            BusStopOnLineSecureService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            FillListView(BusStopService.GetAll(),AllBusStops);

            DeleteButton.IsEnabled = false;
            EditButton.IsEnabled = false;

            SetEnabled();
            BlockListButtons();
            IsNewObjectEnable = true;
        }

        public BusScheduleDetails(ClientCredentials clientCredentials, Line line)
        {
            InitializeComponent();

            BusStopService = new BusStopServiceClient();
            BusStopOnLineService = new BusStopOnLineServiceClient();
            LineService = new LineServiceClient();
            LineSecureService = new LineSecureServiceClient();
            LineSecureService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            LineSecureService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;
            BusStopOnLineSecureService = new BusStopOnLineSecureServiceClient();
            BusStopOnLineSecureService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            BusStopOnLineSecureService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            this.SelectedLine = line;
            SelectedBSOL = GetbyLineId(line.Id.Value, BusStopOnLineService.GetAll());

            LineNumberTextBox.Text = line.Name;

            SelectedBusStopArray = ConvertToBusStop(SelectedBSOL);
            FillListView(BusStopService.GetAll(), AllBusStops);
            FillListView(SelectedBusStopArray, ActualBusStops);
            SetRelations();
            if(SelectedBSOL.First().Direction)
            {
                RelationTextBox.SelectedIndex = 0;
            }
            else
            {
                RelationTextBox.SelectedIndex = 1;
            }

            BlockButtons();

            SaveButton.IsEnabled = false;
            IsNewObjectEnable = false;
        }

        private void FillListView(BusStop[] bsolArray, ListView listView)
        {
            foreach (var item in bsolArray)
            {
                listView.Items.Add(item);
            }
        }

        private BusStopOnLine[] GetbyLineId(int lineId, BusStopOnLine[] allBusStops)
        {
            List<BusStopOnLine> resultArray = new List<BusStopOnLine>();

            foreach(BusStopOnLine item in allBusStops)
            {
                if(item.LineId == lineId)
                {
                    resultArray.Add(item);
                }
            }

            return resultArray.ToArray();
        }

        private BusStop[] ConvertToBusStop(BusStopOnLine[] bsolArray)
        {
            List<BusStop> resultArray = new List<BusStop>();

            foreach(BusStopOnLine item in bsolArray)
            {
                resultArray.Add(BusStopService.GetById(item.BusStopId));
            }

            return resultArray.ToArray();
        }

        private void AddBusStopsOnLine(int id)
        {
            foreach (BusStop busStop in ActualBusStops.Items)
            {
                BusStopOnLine newBusStopOnLine = new BusStopOnLine();
                newBusStopOnLine.LineId = id;
                newBusStopOnLine.NumberStopOnLine = ActualBusStops.Items.IndexOf(busStop) + 1;

                if (RelationTextBox.SelectedIndex == 0)
                {
                    newBusStopOnLine.Direction = true;
                }
                else
                {
                    newBusStopOnLine.Direction = false;
                }

                newBusStopOnLine.BusStopId = busStop.Id.Value;
                BusStopOnLineSecureService.Create(newBusStopOnLine);
            }
        }

        private void DeleteBusStopsOnLine(BusStopOnLine[] bsol)
        {
            foreach(BusStopOnLine item in bsol)
            {
                BusStopOnLineSecureService.DeleteById(item.Id.Value);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(IsNewObjectEnable)
            {
                Line newLine = new Line();
                newLine.Name = LineNumberTextBox.Text;
                LineSecureService.Create(newLine);
                newLine = LineService.GetAll().First(l => l.Name == newLine.Name);

                AddBusStopsOnLine(newLine.Id.Value);
            }
            else
            {
                SelectedLine.Name = LineNumberTextBox.Text;
                DeleteBusStopsOnLine(SelectedBSOL);
                AddBusStopsOnLine(SelectedLine.Id.Value);
                LineSecureService.Update(SelectedLine);
            }
            RefreshAll(this, new EventArgs());
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            SetEnabled();
            BlockListButtons();

            SaveButton.IsEnabled = true;
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteBusStopsOnLine(SelectedBSOL);
            LineSecureService.DeleteById(SelectedLine.Id.Value);
            RefreshAll(this, new EventArgs());
        }

        private void ListUpBusStop_Click(object sender, RoutedEventArgs e)
        {
            int? index = ActualBusStops.SelectedIndex;
            if(index != -1)
            {
                BusStop item = (BusStop)ActualBusStops.Items[index.Value];
                ActualBusStops.Items.Remove(item);
                ActualBusStops.Items.Insert(index.Value - 1, item);

                SetRelations();
            }
        }

        private void ListDownBusStop_Click(object sender, RoutedEventArgs e)
        {
            int? index = ActualBusStops.SelectedIndex;
            if (index != -1)
            {
                BusStop item = (BusStop)ActualBusStops.Items[index.Value];
                ActualBusStops.Items.Remove(item);
                ActualBusStops.Items.Insert(index.Value + 1, item);

                SetRelations();
            }
        }

        private void ListAddBusStop_Click(object sender, RoutedEventArgs e)
        {
            int index = AllBusStops.SelectedIndex;
            if (index != -1)
            {
                BusStop transfered = (BusStop)AllBusStops.SelectedItem;
                AllBusStops.Items.Remove(transfered);
                ActualBusStops.Items.Add(transfered);

                BlockListButtons();
                SetRelations();
            }
        }

        private void ListDeleteBusStop_Click(object sender, RoutedEventArgs e)
        {
            int? index = ActualBusStops.SelectedIndex;
            if (index != -1)
            {
                BusStop transfered = (BusStop)ActualBusStops.SelectedItem;
                ActualBusStops.Items.Remove(transfered);
                AllBusStops.Items.Add(transfered);

                BlockListButtons();
                SetRelations();
            }
        }

        private void ActualBusStops_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListUpBusStop.IsEnabled = true;
            ListDownBusStop.IsEnabled = true;
            int index = ActualBusStops.SelectedIndex;
            if(index == 0)
            {
                ListUpBusStop.IsEnabled = false;
            }

            if (index == ActualBusStops.Items.Count-1)
            {
                ListDownBusStop.IsEnabled = false;
            }
        }

        private void BlockListButtons()
        {
            ListUpBusStop.IsEnabled = true;
            ListDownBusStop.IsEnabled = true;
            ListAddBusStop.IsEnabled = true;
            ListDeleteBusStop.IsEnabled = true;

            if (AllBusStops.Items.Count == 0)
                ListAddBusStop.IsEnabled = false;

            if (ActualBusStops.Items.Count == 0)
            {
                ListUpBusStop.IsEnabled = false;
                ListDownBusStop.IsEnabled = false;
                ListDeleteBusStop.IsEnabled = false;
            }
                
        }

        private void BlockButtons()
        {
            ListAddBusStop.IsEnabled = false;
            ListDeleteBusStop.IsEnabled = false;
            ListUpBusStop.IsEnabled = false;
            ListDownBusStop.IsEnabled = false;
        }

        private void SetEnabled()
        {
            LineNumberTextBox.IsEnabled = true;

            ActualBusStops.IsEnabled = true;
            AllBusStops.IsEnabled = true;
        }

        private void SetRelations()
        {
            if(ActualBusStops.Items.Count != 0)
            {
                BusStop busStopA = (BusStop)ActualBusStops.Items[0];
                BusStop busStopB = (BusStop)ActualBusStops.Items[ActualBusStops.Items.Count - 1];

                RelationTextBox.Items.Clear();

                RelationTextBox.Items.Add(busStopA.Name + "=>" + busStopB.Name);
                RelationTextBox.Items.Add(busStopB.Name + "=>" + busStopA.Name);
                RelationTextBox.SelectedIndex = 0;
            }
            else
            {
                RelationTextBox.Items.Clear();
            }
        }
    }
}
