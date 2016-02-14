
using ManagingSystem.NewsService;
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

namespace ManagingSystem.Pages.UserControls.DetailsUserControl
{
    /// <summary>
    /// Interaction logic for NewsDetails.xaml
    /// </summary>
    public partial class NewsDetails : UserControl
    {
        public News actualNews { get; set; }

        public NewsDetails()
        {
            InitializeComponent();
        }

        public void SetActualNews(News actualNews)
        {
            this.actualNews = actualNews;
            UpdateNewsDetails();
        }

        private void UpdateNewsDetails()
        {
            SelectedNewsTitle.Text = actualNews.Title;
            SelectedNewsDescription.Text = actualNews.Content;
        }
    }
}
