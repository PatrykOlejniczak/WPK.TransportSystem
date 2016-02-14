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
using ManagingSystem.CustomerSecureService;
using ManagingSystem.CustomerOperationService;
using ManagingSystem.Pages.UserControls.DetailsUserControl;

namespace ManagingSystem.Pages.UserControls
{
    /// <summary>
    /// Interaction logic for ClientsControl.xaml
    /// </summary>
    public partial class ClientsControl : UserControl
    {
        private CustomerSecureServiceClient CustomerSecService { get; set; }
        private CustomerOperationServiceClient CustomerOperationService { get; set; }
        private Customer[] customerArray;
        

        public ClientsControl()
        {
            InitializeComponent();

            CustomerSecService = new CustomerSecureServiceClient();
            CustomerOperationService = new CustomerOperationServiceClient();

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                
                CustomerDetails customerDetails = new CustomerDetails((Customer)ListBox.SelectedItem,CustomerSecService.ClientCredentials);
                this.DetailsContentControl.Content = customerDetails;
            }
            catch(Exception ex)
            {

            }
        }

        internal void UpdateUserCredentials(string login, string password)
        {
            try
            {
                CustomerSecService.ClientCredentials.UserName.UserName = login;
                CustomerSecService.ClientCredentials.UserName.Password = password;
            }
            catch(Exception ex)
            {

            }
        }

        internal void FillData()
        {
            FillCustomers();
        }

        private void FillCustomers()
        {
            customerArray = CustomerSecService.GetAll();
            ListBox.ItemsSource = customerArray;
        }
    }
}
