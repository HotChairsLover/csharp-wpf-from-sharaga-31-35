using PermDynamics.Chart;
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
    /// Логика взаимодействия для SavesView.xaml
    /// </summary>
    public partial class SavesView : Page
    {
        OpenCharts openCharts;
        public SavesView(OpenCharts openCharts)
        {
            InitializeComponent();
            this.openCharts = openCharts;
            LoadData();
        }
        private void LoadData()
        {
            List<Saves> saves = DbCommands.GetSaves();
            listView.Items.Clear();
            foreach (Saves save in saves)
            {
                listView.Items.Add(save);
            }
        }

        private void OpenChart(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                Saves save = listView.SelectedItem as Saves;
                //ChartsView page = new ChartsView(openCharts, save.id);
                //page.DataContext = SavesViewModel;
                openCharts.frame.Navigate(new Pages.ChartsView(openCharts, save.id));
            }
            else
            {
                MessageBox.Show("Выберите сохранение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteChart(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                MessageBoxResult res = MessageBox.Show("Вы точно хотите удалить сохранение?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                if (res == MessageBoxResult.OK)
                {
                    Saves save = listView.SelectedItem as Saves;
                    DbCommands.DeleteSave(save.id);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите сохранение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
