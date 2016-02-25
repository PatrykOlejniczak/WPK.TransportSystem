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
    /// Interaction logic for CareerUserControl.xaml
    /// </summary>
    public partial class CareerUserControl : UserControl
    {
        QuestionnaireServiceClient questionnaireService;
        Questionnaire[] questionnaireArray;

        public CareerUserControl(ClientCredentials clientCredentials)
        {
            InitializeComponent();

            questionnaireService = new QuestionnaireServiceClient();
            questionnaireService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            questionnaireService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

        }

        public void FillData()
        {
            questionnaireArray = questionnaireService.GetAll();
            ListBox.ItemsSource = questionnaireArray;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
