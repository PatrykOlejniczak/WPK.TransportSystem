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
using ManagingSystem.UserAccountService;

namespace ManagingSystem.Pages.UserControls.DetailsUserControl
{
    /// <summary>
    /// Interaction logic for EmployeeDetails.xaml
    /// </summary>
    public partial class EmployeeDetails : UserControl
    {
        public event EventHandler RefreshAll;
        private EmployeeSecureServiceClient employeeService { get; set; }
        private UserAccountSecureServiceClient UserAccountSecureService { get; set; }

        Employee actualEmployee;
        bool isNewEmployeeEnable;
        bool UserAccountCreated;
        //Add new Employee.
        public EmployeeDetails(ClientCredentials cc)
        {
            InitializeComponent();
            isNewEmployeeEnable = true;
            employeeService = new EmployeeSecureServiceClient();
            UserAccountSecureService = new UserAccountSecureServiceClient();
            actualEmployee = new Employee();

            employeeService.ClientCredentials.UserName.UserName = cc.UserName.UserName;
            employeeService.ClientCredentials.UserName.Password = cc.UserName.Password;

            UserAccountSecureService.ClientCredentials.UserName.UserName = cc.UserName.UserName;
            UserAccountSecureService.ClientCredentials.UserName.Password = cc.UserName.Password;

            OpenAllTextBoxes();
            EditButton.IsEnabled = false;
        }

        public EmployeeDetails(ClientCredentials cc, Employee employee)
        {
            InitializeComponent();
            isNewEmployeeEnable = false;
            SaveButton.IsEnabled = false;
            UserAccountSecureService = new UserAccountSecureServiceClient();
            employeeService = new EmployeeSecureServiceClient();

            employeeService.ClientCredentials.UserName.UserName = cc.UserName.UserName;
            employeeService.ClientCredentials.UserName.Password = cc.UserName.Password;

            //CreateNewUserAccount.IsEnabled = true;
            actualEmployee = employee;
            UpdateUserDetails();
            //GetUserAccount(actualEmployee.Id.Value);
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
            //LoginNameUA.IsEnabled = true;
            //PasswordUA.IsEnabled = true;
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

            //if(CreateNewUserAccount.IsChecked.Value)
            //{
            //    if(!UserAccountCreated)
            //    {
            //        CreateUserAccount(LoginNameUA.Text, PasswordUA.Text);
            //    }
            //}

            RefreshAll(this, new EventArgs());
        }

        //private void GetUserAccount(int employeeId)
        //{
        //    try
        //    {
        //        UserAccount userAccount = UserAccountSecureService.GetByEmployeeId(employeeId);
        //        if (userAccount != null)
        //        {
        //            LoginNameUA.Text = userAccount.Login;
        //            UserAccountCreated = true;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        UserAccountCreated = false;
        //    }
        //}

        //private void CreateUserAccount(string login, string password)
        //{
        //    if(login.Length != 0 || password.Length != 0)
        //    {
        //        UserAccount newUserAccount = new UserAccount();
        //        newUserAccount.Login = login;
        //        newUserAccount.HashPassword = password;
        //        newUserAccount.EmployeeId = actualEmployee.Id.Value;

        //        UserAccountSecureService.Create(newUserAccount);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Uzupełnij dane do logowania.", "Błąd", MessageBoxButton.OK);
        //    }
            
        //}
    }
}
