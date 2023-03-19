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
using System.Net;

namespace API
{
    /// <summary>
    /// Логика взаимодействия для Group.xaml
    /// </summary>
    public partial class Group : Page
    {
        MainWindow mainWindow;
        MainWindow.GroupList group;
        List<MainWindow.GroupList> groupList = new List<MainWindow.GroupList>();
        public Group(MainWindow mainWindow, MainWindow.GroupList group)
        {
            this.mainWindow = mainWindow;
            this.group = group;
            InitializeComponent();
            GetData();
            LoadData(groupList);
        }
        public void GetData()
        {
            groupList.Clear();
            string data = mainWindow.HttpQuery($"http://localhost/api/index.php?group={group.id}");
            string[] dataGroups = data.Split(';');
            for (int i = 0; i < dataGroups.Length; i++)
            {
                MainWindow.GroupList newGroupsList = new MainWindow.GroupList();
                string[] idNameGroups = dataGroups[i].Split(':');
                newGroupsList.id = Convert.ToInt32(idNameGroups[0]);
                newGroupsList.name = idNameGroups[1];
                groupList.Add(newGroupsList);
            }
            groupTitle.Content += group.name;
        }
        private void LoadData(List<MainWindow.GroupList> groupList)
        {
            listView.Items.Clear();
            for (int i = 0; i < groupList.Count; i++)
            {
                listView.Items.Add(groupList[i]);
            }
        }
        private void FindGroups(object sender, TextChangedEventArgs e)
        {
            if (find.Text == "")
            {
                LoadData(groupList);
            }
            else
            {
                List<MainWindow.GroupList> list = new List<MainWindow.GroupList>();
                foreach (MainWindow.GroupList item in groupList)
                {
                    if (item.name.Contains(find.Text))
                    {
                        list.Add(item);
                    }
                }
                LoadData(list);
            }
        }

        private void SaveGroup(object sender, RoutedEventArgs e)
        {
            DbCommands commands = new DbCommands();
            commands.AddGroup(groupList, group.name);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            mainWindow.ChoosePage(1);
        }
    }
}
