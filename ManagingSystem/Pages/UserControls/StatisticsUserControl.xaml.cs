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

namespace ManagingSystem.Pages.UserControls
{
    /// <summary>
    /// Interaction logic for StatisticsUserControl.xaml
    /// </summary>
    public partial class StatisticsUserControl : UserControl, IDetailsPage
    {
        public StatisticsUserControl()
        {
            InitializeComponent();
        }

        public void FillData()
        {
            throw new NotImplementedException();
        }

        public void UpdateUserCredentials(ClientCredentials cc)
        {
            throw new NotImplementedException();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
