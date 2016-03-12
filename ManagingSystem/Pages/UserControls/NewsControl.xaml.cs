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
using System.ServiceModel.Description;

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
        private NewsDetails newsDetails;

        public NewsControl()
        {
            InitializeComponent();

            NewsSecService = new NewsSecureServiceClient();
            NewsService = new NewsServiceClient();
        }

        private void NewsDetails_RefreshList(object sender, EventArgs e)
        {
            FillNews();
            NewsDetailsContentControl.Content = null;
            newsDetails = null;
        }

        public void UpdateUserCredentials(ClientCredentials cc)
        {
            try
            {
                NewsSecService.ClientCredentials.UserName.UserName = cc.UserName.UserName;
                NewsSecService.ClientCredentials.UserName.Password = cc.UserName.Password;
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
                newsDetails = new NewsDetails(NewsSecService.ClientCredentials, (News)NewsListBox.SelectedItem);
                newsDetails.RefreshAll += NewsDetails_RefreshList;
                this.NewsDetailsContentControl.Content = newsDetails;
            }
            catch(Exception ex)
            {
                
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            newsDetails = new NewsDetails(NewsSecService.ClientCredentials);
            newsDetails.RefreshAll += NewsDetails_RefreshList;
            this.NewsDetailsContentControl.Content = newsDetails;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchedText = SearchTextBox.Text;
            List<News> searchedCustomers = new List<News>();

            for (int i = 0; i < newsArray.Length; i++)
            {
                if (CheckSearchedText(searchedText, newsArray[i]))
                {
                    searchedCustomers.Add(newsArray[i]);
                }
            }

            NewsListBox.ItemsSource = searchedCustomers;
        }

        private bool CheckSearchedText(string text, News news)
        {
            try
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] != news.Title[i])
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
