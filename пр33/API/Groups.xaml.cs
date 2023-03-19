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

namespace API
{
    /// <summary>
    /// Логика взаимодействия для Groups.xaml
    /// </summary>
    public partial class Groups : Page
    {
        MainWindow mainWindow;
        public Groups(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            LoadData(mainWindow.groupLists); 
        }
        private void LoadData(List<MainWindow.GroupList> groupList)
        {
            listView.Items.Clear();
            for(int i = 0; i < groupList.Count; i++)
            {
                listView.Items.Add(groupList[i]);
            }
        }

        private void FindGroups(object sender, TextChangedEventArgs e)
        {
            List<MainWindow.GroupList> list = new List<MainWindow.GroupList>();
            if (find.Text == "")
            {
                LoadData(mainWindow.groupLists);
            }
            else
            {
                foreach (MainWindow.GroupList item in mainWindow.groupLists)
                {
                    if (item.name.Contains(find.Text))
                    {
                        list.Add(item);
                    }
                }
                LoadData(list);
            }
        }

        private void SaveGroups(object sender, RoutedEventArgs e)
        {
            DbCommands commands = new DbCommands();
            commands.AddGroups(mainWindow.groupLists);
        }

        private void OpenGroup(object sender, RoutedEventArgs e)
        {
            if(listView.SelectedItem != null)
            {
                MainWindow.GroupList group = listView.SelectedItem as MainWindow.GroupList;
                mainWindow.frame.Navigate(new Group(mainWindow, group));
            }
            else
            {
                MessageBox.Show("Выберите группу для открытия", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
