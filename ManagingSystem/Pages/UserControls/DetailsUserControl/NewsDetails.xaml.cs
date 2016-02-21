
using ManagingSystem.NewsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
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

namespace ManagingSystem.Pages.UserControls.DetailsUserControl
{
    /// <summary>
    /// Interaction logic for NewsDetails.xaml
    /// </summary>
    public partial class NewsDetails : UserControl
    {
        public NewsSecureServiceClient newsService { get; set; }
        public News actualNews { get; set; }
        bool isNewEmployeeEnable;

        public NewsDetails(ClientCredentials cc)
        {
            InitializeComponent();

            newsService = new NewsSecureServiceClient();
            newsService.ClientCredentials.UserName.UserName = cc.UserName.UserName;
            newsService.ClientCredentials.UserName.Password = cc.UserName.Password;

            OpenTextBoxes();
            isNewEmployeeEnable = true;
        }

        public NewsDetails(ClientCredentials cc, News _actualNews)
        {
            InitializeComponent();

            newsService = new NewsSecureServiceClient();
            newsService.ClientCredentials.UserName.UserName = cc.UserName.UserName;
            newsService.ClientCredentials.UserName.Password = cc.UserName.Password;

            this.actualNews = _actualNews;

            UpdateNewsDetails();
            isNewEmployeeEnable = false;
        }

        private void UpdateNewsDetails()
        {
            SelectedNewsTitle.Text = actualNews.Title;
            SelectedNewsDescription.Text = actualNews.Content;
        }

        private void OpenTextBoxes()
        {
            SelectedNewsTitle.IsEnabled = true;
            SelectedNewsDescription.IsEnabled = true;

            SaveButton.IsEnabled = true;
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            actualNews.Content = SelectedNewsDescription.Text;
            actualNews.Title = SelectedNewsTitle.Text;

            if (isNewEmployeeEnable)
                newsService.Create(actualNews);
            else
                newsService.Update(actualNews);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            OpenTextBoxes();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            newsService.DeleteById(actualNews.Id.Value);
        }
    }
}
