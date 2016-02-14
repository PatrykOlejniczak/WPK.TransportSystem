using ManagingSystem.TicketService;
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
    /// Interaction logic for TicketDetails.xaml
    /// </summary>
    public partial class TicketDetails : UserControl
    {
        Ticket actualTicket;

        public TicketDetails()
        {
            InitializeComponent();
        }

        public void SetActualTicket(Ticket actualTicket)
        {
            this.actualTicket = actualTicket;
            UpdateTicketDetails();
        }

        public void UpdateTicketDetails()
        {
            SelectedTicketName.Text = actualTicket.Name;
            SelectedTicketPrice.Text = actualTicket.Price.ToString();
            SelectedTicketDuration.Text = actualTicket.Duration.ToString();
        }
    }
}
