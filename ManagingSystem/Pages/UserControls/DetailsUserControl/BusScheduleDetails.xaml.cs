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
using System.Windows.Shapes;

namespace ManagingSystem.Pages.UserControls.DetailsUserControl
{
    /// <summary>
    /// Interaction logic for BusScheduleDetails.xaml
    /// </summary>
    public partial class BusScheduleDetails : UserControl
    {
        BusStop FocusingBusStop { get; set; }
        public BusScheduleDetails(BusStop focusingBusStop)
        {
            InitializeComponent();
            FocusingBusStop = focusingBusStop;
        }

        private void UpdateDetails()
        {

        }

    }
}
