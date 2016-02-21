using ManagingSystem.Class;
using ManagingSystem.Pages.UserControls.DetailsUserControl;
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
using ManagingSystem.EmployeeAuthenticationService;
using System.ServiceModel.Description;
using ManagingSystem.Interface;

namespace ManagingSystem.Pages.UserControls
{
    /// <summary>
    /// Interaction logic for EmployeesControl.xaml
    /// </summary>
    public partial class EmployeesControl : UserControl, IPages
    {
        private EmployeeSecureServiceClient employeeService;
        private Employee[] EmployeesList;
        private Employee SelectedEmployee;
        private EmployeeDetails employeeDetails;

        public EmployeesControl()
        {

            InitializeComponent();
            employeeService = new EmployeeSecureServiceClient();
        }

        public void UpdateUserCredentials(ClientCredentials cc)
        {
            try
            {
                employeeService.ClientCredentials.UserName.UserName = cc.UserName.UserName;
                employeeService.ClientCredentials.UserName.Password = cc.UserName.Password;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Wystąpił błąd", MessageBoxButton.OK);
            }

        }

        public void FillData()
        {
            try
            {
                EmployeesList = employeeService.GetAll();
                EmployeesListBox.ItemsSource = EmployeesList;
        }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Wystąpił błąd", MessageBoxButton.OK);
            }

}

        private void EmployeesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            employeeDetails = new EmployeeDetails(employeeService.ClientCredentials,(Employee)EmployeesListBox.SelectedItem);
            this.EmployeeDetailsContentControl.Content = employeeDetails;
        }

        private string[] SplitText(string text)
        {
            string[] resultArray = new string[2]; //0 - surname; 1 - Name

            for (int i = 0; i < text.Length; i++)
            {
                if (!(text[i] == ';'))
                {
                    resultArray[0] += text[i];
                }
                else
                    break;
            }
            if(resultArray[0] == null)
                resultArray[1] = text.Substring(1);
            else if(text.Length-1 > resultArray[0].Length)
                resultArray[1] = text.Substring(resultArray[0].Length+1);

            return resultArray;
        }

        private bool IsEmployeeAsTarget(Employee tempEmployee, string LastName, string FirstName)
        {
            bool employeeTarget = true;

            if (LastName == null)
            {
                if (tempEmployee.FirstName != FirstName)
                    employeeTarget = false;
            }
            else if (FirstName == null)
            {
                if (tempEmployee.LastName != LastName)
                    employeeTarget = false;
            }
            else
                if (tempEmployee.FirstName != FirstName &&
                tempEmployee.LastName != LastName)
                    employeeTarget = false;

            return employeeTarget;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text.Length != 0)
            {
                string[] SearchingText = SplitText(SearchTextBox.Text);
                List<Employee> searchedEmployees = new List<Employee>();
                for (int i = 0; i < EmployeesList.Length; i++)
                {
                    Employee actualEmployee = EmployeesList[i];
                    
                    if(IsEmployeeAsTarget(actualEmployee,SearchingText[0],SearchingText[1]))
                    {
                        searchedEmployees.Add(actualEmployee);
                    }
                }

                EmployeesListBox.ItemsSource = null;
                EmployeesListBox.ItemsSource = searchedEmployees;
            }
            else
            {
                FocusManager.SetFocusedElement(TopEmployeesButtons, SearchTextBox);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDetails newEmployee = new EmployeeDetails(employeeService.ClientCredentials);
            this.EmployeeDetailsContentControl.Content = newEmployee;
        }
    }
}
