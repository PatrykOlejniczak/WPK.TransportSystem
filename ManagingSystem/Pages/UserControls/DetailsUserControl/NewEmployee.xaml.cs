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

namespace ManagingSystem.Pages.UserControls.DetailsUserControl
{
    /// <summary>
    /// Interaction logic for NewEmployee.xaml
    /// </summary>
    public partial class NewEmployee : UserControl
    {
        private Employee employee;
        private EmployeeSecureServiceClient employeeService;
        private bool isInEditMode;

        public NewEmployee(EmployeeSecureServiceClient employeeService)
        {
            InitializeComponent();
            isInEditMode = false;
            employee = new Employee();
        }
        public NewEmployee(EmployeeSecureServiceClient employeeService, Employee editingEmployee)
        {
            InitializeComponent();
            isInEditMode = true;

            this.employee = editingEmployee;
            this.employeeService = employeeService;

            NameTextBox.Text = editingEmployee.FirstName;
            SecondNameTextBox.Text = editingEmployee.SecondName;
            SurnameTextBox.Text = editingEmployee.LastName;
            CityTextBox.Text = editingEmployee.City;
            StreetTextBox.Text = editingEmployee.Street;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateEmployeeData();
            if(isInEditMode)
            {
                employeeService.Update(employee);
            }
            else
            {
                employeeService.Create(employee);
            }
        }

        private void UpdateEmployeeData()
        {
            employee.FirstName = NameTextBox.Text;
            employee.SecondName = NameTextBox.Text;
            employee.LastName = NameTextBox.Text;
            employee.City = CityTextBox.Text;
            employee.Street = StreetTextBox.Text;
        }
    }
}
