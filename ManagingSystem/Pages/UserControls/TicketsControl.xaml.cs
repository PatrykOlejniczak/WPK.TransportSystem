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
using ManagingSystem.TicketTypeService;
using ManagingSystem.TicketService;
using ManagingSystem.Pages.UserControls.DetailsUserControl;
using System.ServiceModel.Description;

namespace ManagingSystem.Pages.UserControls
{
    /// <summary>
    /// Interaction logic for TicketsControl.xaml
    /// </summary>
    public partial class TicketsControl : UserControl
    {
        private TicketTypeServiceClient TicketTypeService { get; set; }
        private TicketServiceClient TicketService { get; set; }
        private TicketType[] ticketTypeArray;
        private Ticket[] ticketsArray;

        public TicketsControl()
        {
            InitializeComponent();
            TicketTypeService = new TicketTypeServiceClient();
            TicketService = new TicketServiceClient();
        }

        public void UpdateUserCredentials(ClientCredentials cc)
        {
            try
            {
                TicketTypeService.ClientCredentials.UserName.UserName = cc.UserName.UserName;
                TicketTypeService.ClientCredentials.UserName.Password = cc.UserName.Password;

                TicketService.ClientCredentials.UserName.UserName = cc.UserName.UserName;
                TicketService.ClientCredentials.UserName.Password = cc.UserName.Password;
            }
            catch(Exception ex)
            {

            }
        }

        public void FillData()
        {
            FillTicketTypes();
            FillTickets();
        }


        private void FillTicketTypes()
        {
            ticketTypeArray = TicketTypeService.GetAll();
            TicketTypesComboBox.ItemsSource = ticketTypeArray;
        }

        private void FillTickets()
        {
            ticketsArray = TicketService.GetAll();
        }

        private void TicketTypesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TicketType selectedTicketType = (TicketType)TicketTypesComboBox.SelectedItem;
            var TicketsByType = from ticket in ticketsArray
                                where ticket.TicketTypeId == selectedTicketType.Id
                                select ticket;
            TicketsListBox.ItemsSource = TicketsByType;
        }

        private void TicketsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TicketDetails ticketDetails = new TicketDetails();
                this.TicketDetailsContentControl.Content = ticketDetails;
                ticketDetails.SetActualTicket((Ticket)TicketsListBox.SelectedItem);
            }
            catch(Exception ex)
            {

            }
            
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
