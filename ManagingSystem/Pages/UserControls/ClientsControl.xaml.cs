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
using System.ServiceModel.Description;

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

        internal void UpdateUserCredentials(ClientCredentials cc)
        {
            try
            {
                CustomerSecService.ClientCredentials.UserName.UserName = cc.UserName.UserName;
                CustomerSecService.ClientCredentials.UserName.Password = cc.UserName.Password;
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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchedText = SearchTextBox.Text;
            List<Customer> searchedCustomers = new List<Customer>();

            for (int i = 0; i < customerArray.Length; i++)
            {
                if(CheckSearchedText(searchedText,customerArray[i]))
                {
                    searchedCustomers.Add(customerArray[i]);
                }
            }

            ListBox.ItemsSource = searchedCustomers;
        }

        private bool CheckSearchedText(string text, Customer customer)
        {
            try
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] != customer.Email[i])
                        return false;
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}
