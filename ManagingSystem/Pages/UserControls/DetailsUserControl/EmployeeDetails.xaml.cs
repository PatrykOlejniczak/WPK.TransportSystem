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

namespace ManagingSystem.Pages.UserControls.DetailsUserControl
{
    /// <summary>
    /// Interaction logic for EmployeeDetails.xaml
    /// </summary>
    public partial class EmployeeDetails : UserControl
    {
        public EmployeeSecureServiceClient employeeService { get; set; }
        Employee actualEmployee;
        public EmployeeDetails(Employee newEmployee)
        {
            InitializeComponent();
            actualEmployee = newEmployee;
            UpdateUserDetails();
        }

        void UpdateUserDetails()
        {
            SelectedUserName.Text = actualEmployee.FirstName;
            SelectedUserSecondName.Text = actualEmployee.SecondName;
            SelectedUserStreet.Text = actualEmployee.Street;
            SelectedUserCity.Text = actualEmployee.City;
            SelectedUserSurname.Text = actualEmployee.LastName;
            SelectedUserWorksite.Text = actualEmployee.Street;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            NewEmployee newEmployee = new NewEmployee(employeeService, actualEmployee);
            this.Content = newEmployee;
        }
    }
}
