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
using ManagingSystem.QuestionnaireService;
using System.ServiceModel.Description;

namespace ManagingSystem.Pages.UserControls.DetailsUserControl
{
    /// <summary>
    /// Interaction logic for QuestionnaireDetails.xaml
    /// </summary>
    public partial class QuestionnaireDetails : UserControl
    {
        public event EventHandler RefreshAll;
        QuestionnaireServiceClient questionnaireService { get; set; }
        QuestionnaireSecureServiceClient questionnaireSecureService { get; set; }

        Questionnaire SelectedQuestionnaire;
        bool IsNewObject;
        public QuestionnaireDetails(ClientCredentials clientCredentials)
        {
            InitializeComponent();
            questionnaireSecureService = new QuestionnaireSecureServiceClient();
            questionnaireSecureService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            questionnaireSecureService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            SelectedQuestionnaire = new Questionnaire();
            StartCalendar.SelectedDate = DateTime.Now;
            EndCalendar.SelectedDate = DateTime.Now.AddDays(7);
            UnlockAllDataValues();

            SaveButton.IsEnabled = true;

            IsNewObject = true;
        }

        public QuestionnaireDetails(ClientCredentials clientCredentials, Questionnaire questionnaire)
        {
            InitializeComponent();
            questionnaireSecureService = new QuestionnaireSecureServiceClient();
            questionnaireSecureService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            questionnaireSecureService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

            this.SelectedQuestionnaire = questionnaire;
            FillData(SelectedQuestionnaire);
            BlockAllDataValues();

            EditButton.IsEnabled = true;
            DeleteButton.IsEnabled = true;

            IsNewObject = false;
        }

        private void FillData(Questionnaire questionnaire)
        {
            QuestionTextBox.Text = questionnaire.Question;
            StartCalendar.SelectedDate = questionnaire.StartDate;
            StartCalendar.DisplayDate = questionnaire.StartDate;
            EndCalendar.SelectedDate = questionnaire.EndDate;
            EndCalendar.DisplayDate = questionnaire.EndDate;
        }

        private void BlockAllDataValues()
        {
            QuestionTextBox.IsEnabled = false;
            StartCalendar.IsEnabled = false;
            EndCalendar.IsEnabled = false;
        }

        private void UnlockAllDataValues()
        {
            QuestionTextBox.IsEnabled = true;
            StartCalendar.IsEnabled = true;
            EndCalendar.IsEnabled = true;
        }

        private void SetNewQuestionnaire()
        {
            if (EndCalendar.SelectedDate.Value > StartCalendar.SelectedDate.Value)
            {
                SelectedQuestionnaire.Question = QuestionTextBox.Text;
                SelectedQuestionnaire.StartDate = StartCalendar.SelectedDate.Value;
                SelectedQuestionnaire.EndDate = EndCalendar.SelectedDate.Value;
                SelectedQuestionnaire.EmployeeId = 1;
            }
            else
            {
                MessageBox.Show("Data zakończenia nie może być niższa od daty rozpoczęcia.", "Błąd" ,MessageBoxButton.OK);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SetNewQuestionnaire();

            if (IsNewObject)
            {
                questionnaireSecureService.Create(SelectedQuestionnaire);
            }
            else
            {
                questionnaireSecureService.Update(SelectedQuestionnaire);
            }
            RefreshAll(this, new EventArgs());
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            UnlockAllDataValues();
            SaveButton.IsEnabled = true;
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            questionnaireSecureService.DelteById(SelectedQuestionnaire.Id.Value);
            RefreshAll(this, new EventArgs());
        }
    }
}
