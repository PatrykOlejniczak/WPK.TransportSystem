using ManagingSystem.CustomerSecureService;
using ManagingSystem.Model;
using ManagingSystem.PurchaseTicketSecureService;
using ManagingSystem.TicketTypeService;
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


namespace ManagingSystem.Pages.UserControls.DetailsUserControl
{
    /// <summary>
    /// Interaction logic for CustomerDetails.xaml
    /// </summary>
    public partial class CustomerDetails : UserControl
    {
        private CustomerSecureServiceClient customerService { get; set; }
        private TicketTypeServiceClient ticketTypeService { get; set; }
        private PurchaseTicketSecureServiceClient ticketService { get; set; }
        private Customer customer{ get; set; }

        public CustomerDetails(Customer _customer, ClientCredentials clientCredentials)
        {
            InitializeComponent();

            ticketTypeService = new TicketTypeServiceClient();
            
            customerService = new CustomerSecureServiceClient();
            customerService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            customerService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            ticketService = new PurchaseTicketSecureServiceClient();
            ticketService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            ticketService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            customer = _customer;

            FillLabels();
        }

        private void OpenAllTextBoxes()
        {
            
        }

        private void FillLabels()
        {
            //TODO
            CustomerEmail.Content = customer.Email;

            PurchaseTicket[] ticketListFromDB = ticketService.GetByCustomerId(customer.Id.Value);
            

            TicketInfo[] ticket = new TicketInfo[ticketListFromDB.Length];

            for (int i = 0; i < ticketListFromDB.Length; i++)
            {
                ticket[i] = new TicketInfo();
                ticket[i].Type = ticketTypeService.GetById(ticketListFromDB[i].TicketId).Name;
                ticket[i].Time = ticketListFromDB[i].DateOfPurchase;
            }

            TicketHistory.ItemsSource = ticket;
        }
    }
}
