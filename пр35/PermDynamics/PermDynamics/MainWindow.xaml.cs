using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using Microsoft.Win32;
using Syncfusion.UI.Xaml.Charts;


namespace PermDynamics
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        private static Random rnd;
        static MainWindow mainWindow;
        
        public MainWindow()
        {
            InitializeComponent();
            MessageBoxManager.Yes = "В базу";
            MessageBoxManager.No = "Файлом";
            MessageBoxManager.Cancel = "Отмена";
            MessageBoxManager.Register();
            mainWindow = this;
            string id = DbCommands.GetLastSaveId();
            if (id != "0" && id != "")
            {
                ViewModel.DynamicData = DbCommands.GetData(id);
            }
            ViewModel.rubPerStock.Clear();
            foreach (Stocks stock in ViewModel.DynamicData)
            {
                ViewModel.rubPerStock.Add(stock.rublesPerStock);
            }
            AddData();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 2);
            timer.Start();

        }
        public static void AddData()
        {
            rnd = new Random();
            double lastPrice = ViewModel.DynamicData.Last().rublesPerStock;
            double rubles;
            double avg = ViewModel.rubPerStock.Average();
            if (rnd.Next(0, 3) == 1)
            {
                rubles = lastPrice - lastPrice / 100 * rnd.Next(1, 50);
            }
            else
            {
                rubles = lastPrice + lastPrice / 100 * rnd.Next(1, 50);
            }
            if (ViewModel.DynamicData.Count >= 100)
            {
                ViewModel.DynamicData.RemoveAt(0);
                ViewModel.rubPerStock.RemoveAt(0);
            }
            if (rubles < avg)
            {
                mainWindow.perStock.Interior = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            else
            {
                mainWindow.perStock.Interior = new SolidColorBrush(Color.FromRgb(95, 143, 132));
            }
            ViewModel.DynamicData.Add(new Stocks(rubles, avg, DateTime.Now));
            ViewModel.rubPerStock.Add(rubles);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            AddData();
        }
        private void ShowAverage(object sender, RoutedEventArgs e)
        {
            if (showAvgChart.IsChecked == true)
            {
                mainWindow.avgStock.StrokeThickness = 1;
            }
            else
            {
                mainWindow.avgStock.StrokeThickness = 0;
            }
        }

        private void SaveChart(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Как сохранять?", "Сохранение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
            if (result == MessageBoxResult.Yes)
            {
                DbCommands.SaveData(ViewModel.DynamicData);
            }
            else if (result == MessageBoxResult.No)
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg,*.jpeg)|*.jpg;*.jpeg|Gif (*.gif)|*.gif|PNG(*.png)|*.png|TIFF(*.tif,*.tiff)|*.tif|All files (*.*)|*.*";

                if (sfd.ShowDialog() == true)
                {

                    using (Stream fs = sfd.OpenFile())
                    {

                        mainWindow.stocks.Save(fs, new PngBitmapEncoder());

                    }

                }
            }
        }

        void ChartsOpen()
        {
            OpenCharts window = new OpenCharts();
            window.Show();
            Dispatcher.Run();
        }
        private void OpenChart(object sender, RoutedEventArgs e)
        {
            Thread newThread = new Thread(ChartsOpen);
            newThread.SetApartmentState(ApartmentState.STA);
            newThread.IsBackground = true;
            newThread.Start();
        }
    }
}
