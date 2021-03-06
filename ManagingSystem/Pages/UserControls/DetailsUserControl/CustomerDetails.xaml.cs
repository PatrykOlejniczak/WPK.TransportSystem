﻿using ManagingSystem.CustomerSecureService;
using ManagingSystem.Model;
using ManagingSystem.TicketTypeService;
using ManagingSystem.PurchaseTicketSecureService;
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
using ManagingSystem.TicketService;

namespace ManagingSystem.Pages.UserControls.DetailsUserControl
{
    /// <summary>
    /// Interaction logic for CustomerDetails.xaml
    /// </summary>
    public partial class CustomerDetails : UserControl
    {
        private CustomerSecureServiceClient customerService { get; set; }
        private PurchaseTicketSecureServiceClient PurchaseTicketService { get; set; }
        private TicketServiceClient ticketService { get; set; }
        private TicketTypeServiceClient ticketTypeService {get; set;}
        private Customer customer{ get; set; }

        public CustomerDetails(ClientCredentials clientCredentials)
        {
            InitializeComponent();
            customerService = new CustomerSecureServiceClient();
            PurchaseTicketService = new PurchaseTicketSecureServiceClient();
            ticketService = new TicketServiceClient();
            ticketTypeService = new TicketTypeServiceClient();
            customerService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            customerService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            customer = new Customer();
        }

        public CustomerDetails(Customer _customer, ClientCredentials clientCredentials)
        {
            InitializeComponent();
            customerService = new CustomerSecureServiceClient();
            PurchaseTicketService = new PurchaseTicketSecureServiceClient();
            ticketService = new TicketServiceClient();
            ticketTypeService = new TicketTypeServiceClient();
            customerService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            customerService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            PurchaseTicketService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            PurchaseTicketService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            customer = _customer;

            FillLabels();
        }

        private void OpenAllTextBoxes()
        {
            
        }

        private void FillLabels()
        {
            CustomerEmail.Content = customer.Email;

            PurchaseTicket[] ticketList = PurchaseTicketService.GetByCustomerId(customer.Id.Value);
            List<TicketInfo> customerTickets = new List<TicketInfo>();


            foreach (var item in ticketList)
            {
                //PurchaseTicket tempTicket = PurchaseTicketService.GetById(item.TicketId);
                Ticket ticket = ticketService.GetById(item.TicketId);
                customerTickets.Add(new TicketInfo() { Type = ticket.Name, Time = item.DateOfPurchase });
            }

            TicketHistory.ItemsSource = customerTickets;
        }
    }
}
