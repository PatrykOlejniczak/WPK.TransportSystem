﻿using ManagingSystem.CustomerSecureService;
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


namespace ManagingSystem.Pages.UserControls.DetailsUserControl
{
    /// <summary>
    /// Interaction logic for CustomerDetails.xaml
    /// </summary>
    public partial class CustomerDetails : UserControl
    {
        private CustomerSecureServiceClient customerService { get; set; }
        private PurchaseTicketSecureServiceClient ticketService { get; set; }
        private Customer customer{ get; set; }

        public CustomerDetails(ClientCredentials clientCredentials)
        {
            InitializeComponent();

            customerService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            customerService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            customer = new Customer();
        }

        public CustomerDetails(Customer _customer, ClientCredentials clientCredentials)
        {
            InitializeComponent();

            customerService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            customerService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

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
            CustomerEmail.Content = customer.Email;

            //PurchaseTicket[] ticketList = ticketService.get
        }
    }
}
