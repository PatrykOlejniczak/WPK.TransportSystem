using ManagingSystem.TicketService;
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
using ManagingSystem.TicketTypeService;

namespace ManagingSystem.Pages.UserControls.DetailsUserControl
{
    /// <summary>
    /// Interaction logic for TicketDetails.xaml
    /// </summary>
    public partial class TicketDetails : UserControl
    {
        TicketSecureServiceClient TicketSecureService { get; set; }
        TicketTypeServiceClient TicketTypeService { get; set; }

        public event EventHandler RefreshAll;
        Ticket actualTicket;
        bool IsNewObject;

        public TicketDetails(ClientCredentials clientCredentials)
        {
            InitializeComponent();
            TicketTypeService = new TicketTypeServiceClient();

            TicketSecureService = new TicketSecureServiceClient();
            TicketSecureService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            TicketSecureService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            actualTicket = new Ticket();
            UnlockTextBoxes();

            TicketType[] ticketTypes = TicketTypeService.GetAll();
            SelectedTicketType.ItemsSource = ticketTypes;

            IsNewObject = true;

            SaveButton.IsEnabled = true;
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
        }

        public TicketDetails(ClientCredentials clientCredentials, Ticket SelectedTicket)
        {
            InitializeComponent();
            TicketTypeService = new TicketTypeServiceClient();

            TicketSecureService = new TicketSecureServiceClient();
            TicketSecureService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            TicketSecureService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            actualTicket = SelectedTicket;
            UpdateTicketDetails();
            IsNewObject = false;

            SaveButton.IsEnabled = false;
            EditButton.IsEnabled = true;
            DeleteButton.IsEnabled = true;
        }

        private void UpdateTicketDetails()
        {
            SelectedTicketName.Text = actualTicket.Name;
            SelectedTicketPrice.Text = actualTicket.Price.ToString();
            SelectedTicketDuration.Text = actualTicket.Duration.ToString();

            TicketType[] ticketTypes = TicketTypeService.GetAll();
            SelectedTicketType.ItemsSource = ticketTypes;

            foreach (var item in ticketTypes)
            {
                if(item.Id == actualTicket.TicketTypeId)
                {
                    SelectedTicketType.SelectedItem = item;
                }
            }
        }

        private void UpdateNewTicket()
        {
            actualTicket.Name = SelectedTicketName.Text;
            actualTicket.Price = double.Parse(SelectedTicketPrice.Text);

            try
            {
                actualTicket.Duration = TimeSpan.Parse(SelectedTicketDuration.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Długość biletu ma zły format.", "Błąd", MessageBoxButton.OK);
            }
            TicketType type = (TicketType)SelectedTicketType.SelectedItem;
            actualTicket.TicketTypeId = type.Id.Value;
        }

        private void UnlockTextBoxes()
        {
            SelectedTicketName.IsEnabled = true;
            SelectedTicketDuration.IsEnabled = true;
            SelectedTicketPrice.IsEnabled = true;
            SelectedTicketRelief.IsEnabled = true;
            SelectedTicketType.IsEnabled = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateNewTicket();
            if(IsNewObject)
            {
                TicketSecureService.Create(actualTicket);
            }
            else
            {
                TicketSecureService.Update(actualTicket);
            }

            RefreshAll(this, new EventArgs());
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            UnlockTextBoxes();
            SaveButton.IsEnabled = true;
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            TicketSecureService.DeleteById(actualTicket.Id.Value);
            RefreshAll(this, new EventArgs());
        }
    }
}
