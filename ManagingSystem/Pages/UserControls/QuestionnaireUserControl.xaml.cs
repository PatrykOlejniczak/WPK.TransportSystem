using ManagingSystem.Interface;
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
using System.ServiceModel.Description;
using ManagingSystem.QuestionnaireService;
using ManagingSystem.Pages.UserControls.DetailsUserControl;

namespace ManagingSystem.Pages.UserControls
{
    /// <summary>
    /// Interaction logic for SurverUserControl.xaml
    /// </summary>
    public partial class QuestionnaireUserControl : UserControl
    {

        QuestionnaireServiceClient questionnaireService { get; set; }
        Questionnaire[] questionnaireList;
        QuestionnaireDetails questionnaireDetails;

        public QuestionnaireUserControl(ClientCredentials cc)
        {
            InitializeComponent();

            questionnaireService = new QuestionnaireServiceClient();
            questionnaireService.ClientCredentials.UserName.UserName = cc.UserName.UserName;
            questionnaireService.ClientCredentials.UserName.Password = cc.UserName.Password;
        }

        public void FillData()
        {
            try
            {
                questionnaireList = questionnaireService.GetAll();
                ListBox.ItemsSource = questionnaireList;
            }
            catch(Exception ex)
            {
                
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            questionnaireDetails = new QuestionnaireDetails(questionnaireService.ClientCredentials, (Questionnaire)ListBox.SelectedItem);
            questionnaireDetails.RefreshAll += QuestionnaireDetails_RefreshAll;
            DetailsContentControl.Content = questionnaireDetails;
        }

        private void QuestionnaireDetails_RefreshAll(object sender, EventArgs e)
        {
            FillData();
            this.DetailsContentControl.Content = null;
            questionnaireDetails = null;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            questionnaireDetails = new QuestionnaireDetails(questionnaireService.ClientCredentials);
            questionnaireDetails.RefreshAll += QuestionnaireDetails_RefreshAll;
            DetailsContentControl.Content = questionnaireDetails;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string searchedText = SearchTextBox.Text;
            List<Questionnaire> searchedCustomers = new List<Questionnaire>();

            for (int i = 0; i < questionnaireList.Length; i++)
            {
                if (CheckSearchedText(searchedText, questionnaireList[i]))
                {
                    searchedCustomers.Add(questionnaireList[i]);
                }
            }

            ListBox.ItemsSource = searchedCustomers;
        }

        private bool CheckSearchedText(string text, Questionnaire questionnaire)
        {
            try
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] != questionnaire.Question[i])
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
