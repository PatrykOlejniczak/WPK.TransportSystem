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
using ManagingSystem.EmployeeSecureService;
using ManagingSystem.Interface;
using System.ServiceModel.Description;

namespace ManagingSystem.Pages.UserControls.DetailsUserControl
{
    /// <summary>
    /// Interaction logic for EmployeeDetails.xaml
    /// </summary>
    public partial class EmployeeDetails : UserControl
    {
        public event EventHandler RefreshAll;
        private EmployeeSecureServiceClient employeeService { get; set; }

        Employee actualEmployee;
        bool isNewEmployeeEnable;

        //Add new Employee.
        public EmployeeDetails(ClientCredentials cc)
        {
            InitializeComponent();
            isNewEmployeeEnable = true;
            employeeService = new EmployeeSecureServiceClient();
            actualEmployee = new Employee();

            employeeService.ClientCredentials.UserName.UserName = cc.UserName.UserName;
            employeeService.ClientCredentials.UserName.Password = cc.UserName.Password;

            OpenAllTextBoxes();
            EditButton.IsEnabled = false;
        }

        public EmployeeDetails(ClientCredentials cc, Employee employee)
        {
            InitializeComponent();
            isNewEmployeeEnable = false;
            SaveButton.IsEnabled = false;
            employeeService = new EmployeeSecureServiceClient();

            employeeService.ClientCredentials.UserName.UserName = cc.UserName.UserName;
            employeeService.ClientCredentials.UserName.Password = cc.UserName.Password;

            actualEmployee = employee;
            UpdateUserDetails();
        }

        private void OpenAllTextBoxes()
        {
            SelectedUserName.IsEnabled = true;
            SelectedUserSurname.IsEnabled = true;
            SelectedUserStreet.IsEnabled = true;
            SelectedUserCity.IsEnabled = true;
            SelectedUserSurname.IsEnabled = true;
            SelectedUserWorksite.IsEnabled = true;
        }

        void UpdateUserDetails()
        {
            SelectedUserName.Text = actualEmployee.FirstName;
            SelectedUserSurname.Text = actualEmployee.SecondName;
            SelectedUserStreet.Text = actualEmployee.Street;
            SelectedUserCity.Text = actualEmployee.City;
            SelectedUserSurname.Text = actualEmployee.LastName;
            SelectedUserWorksite.Text = actualEmployee.Street;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            OpenAllTextBoxes();
            SaveButton.IsEnabled = true;
            EditButton.IsEnabled = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            actualEmployee.FirstName = SelectedUserName.Text;
            actualEmployee.Street = SelectedUserStreet.Text;
            actualEmployee.City = SelectedUserCity.Text;
            actualEmployee.LastName = SelectedUserSurname.Text;
            actualEmployee.Street = SelectedUserWorksite.Text;
            actualEmployee.StartDate = DateTime.Now;

            if (isNewEmployeeEnable)
                employeeService.Create(actualEmployee);
            else
                employeeService.Update(actualEmployee);

            RefreshAll(this, new EventArgs());
        }
    }
}
