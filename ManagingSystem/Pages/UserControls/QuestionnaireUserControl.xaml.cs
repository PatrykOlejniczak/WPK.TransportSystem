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
using System.Windows.Shapes;
using System.ServiceModel.Description;
using ManagingSystem.QuestionnaireService;

namespace ManagingSystem.Pages.UserControls
{
    /// <summary>
    /// Interaction logic for SurverUserControl.xaml
    /// </summary>
    public partial class QuestionnaireUserControl : UserControl, IDetailsPage
    {
        QuestionnaireServiceClient questionnaireService { get; set; }
        QuestionnaireSecureServiceClient questionnaireSecureService { get; set; }
        Questionnaire[] questionnaireList;
        //QuestionnaireDetails questionnaireDetails;

        public QuestionnaireUserControl()
        {
            InitializeComponent();

            questionnaireService = new QuestionnaireServiceClient();
            questionnaireSecureService = new QuestionnaireSecureServiceClient();
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
                MessageBox.Show(ex.Message, "Wystąpił błąd", MessageBoxButton.OK);
            }
        }

        public void UpdateUserCredentials(ClientCredentials cc)
        {
            try
            {
                questionnaireService.ClientCredentials.UserName.UserName = cc.UserName.UserName;
                questionnaireService.ClientCredentials.UserName.Password = cc.UserName.Password;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Wystąpił błąd", MessageBoxButton.OK);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
