using ManagingSystem.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ManagingSystem.NewsService;
using ManagingSystem.Pages.UserControls.DetailsUserControl;

namespace ManagingSystem.Pages.UserControls
{
    /// <summary>
    /// Interaction logic for NewsControl.xaml
    /// </summary>
    public partial class NewsControl : UserControl
    {
        private NewsSecureServiceClient NewsSecService { get; set; }
        private NewsServiceClient NewsService { get; set; }
        private News[] newsArray;

        public NewsControl()
        {
            InitializeComponent();

            NewsSecService = new NewsSecureServiceClient();
            NewsService = new NewsServiceClient();
        }

        public void UpdateUserCredentials(string login, string password)
        {
            try
            {
                NewsSecService.ClientCredentials.UserName.UserName = login;
                NewsSecService.ClientCredentials.UserName.Password = password;
            }
            catch(Exception ex)
            {

            }
        }

        public void FillData()
        {
            FillNews();
        }

        private void FillNews()
        {
            newsArray = NewsService.GetAll();
            NewsListBox.ItemsSource = newsArray;
        }

        private void NewsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                NewsDetails newsDetails = new NewsDetails();
                this.NewsDetailsContentControl.Content = newsDetails;
                newsDetails.SetActualNews((News)NewsListBox.SelectedItem);
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}
