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
using ManagingSystem.AnswerOptionService;

namespace ManagingSystem.Pages.UserControls
{
    /// <summary>
    /// Interaction logic for CareerUserControl.xaml
    /// </summary>
    public partial class CareerUserControl : UserControl
    {
        AnswerOptionServiceClient answerOptionService;
        AnswerOption[] answerOptionArray;

        public CareerUserControl(ClientCredentials clientCredentials)
        {
            InitializeComponent();

            answerOptionService = new AnswerOptionServiceClient();
            answerOptionService.ClientCredentials.UserName.UserName = clientCredentials.UserName.UserName;
            answerOptionService.ClientCredentials.UserName.Password = clientCredentials.UserName.Password;

        }

        public void FillData()
        {
            answerOptionArray = answerOptionService.GetAll();
            ListBox.ItemsSource = answerOptionArray;

            AnswerOption qwe = new AnswerOption();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
