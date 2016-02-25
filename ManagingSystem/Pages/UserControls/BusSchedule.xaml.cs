﻿using ManagingSystem.Interface;
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
using System.ServiceModel.Description;
using ManagingSystem.BusStopService;
using ManagingSystem.Pages.UserControls.DetailsUserControl;

namespace ManagingSystem.Pages.UserControls
{
    /// <summary>
    /// Interaction logic for BusSchedule.xaml
    /// </summary>
    public partial class BusSchedule : UserControl
    {
        private BusStopSecureServiceClient BusStopSecureService { get; set; }
        private BusStopServiceClient BusStopService { get; set; }
        private BusStop[] BusStopList { get; set; }
        private BusScheduleDetails BusStopDetails { get; set; }

        public BusSchedule(ClientCredentials clientCredentials)
        {
            InitializeComponent();

            BusStopService = new BusStopServiceClient();
            BusStopService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            BusStopService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;
        }

        public void FillData()
        {
            try
            {
                BusStopList = BusStopService.GetAll();
                ListBox.ItemsSource = BusStopList;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Wystąpił błąd", MessageBoxButton.OK);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BusStopDetails = new BusScheduleDetails((BusStop)ListBox.SelectedItem);
            this.DetailsContentControl.Content = BusStopDetails;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
