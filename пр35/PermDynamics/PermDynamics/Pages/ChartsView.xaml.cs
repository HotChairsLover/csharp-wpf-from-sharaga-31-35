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

namespace PermDynamics.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChartsView.xaml
    /// </summary>
    public partial class ChartsView : Page
    {
        OpenCharts openCharts;
        public ChartsView(OpenCharts openCharts, string id)
        {
            InitializeComponent();
            this.openCharts = openCharts;
            Chart.SavesViewModel.OpenData = DbCommands.GetData(id);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            openCharts.frame.Navigate(new Pages.SavesView(openCharts));
        }
    }
}
