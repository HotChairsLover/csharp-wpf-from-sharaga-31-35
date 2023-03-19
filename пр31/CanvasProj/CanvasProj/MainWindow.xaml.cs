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
using System.Windows.Threading;

namespace CanvasProj
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int count = 100;
        const int maxTransform = 30;
        const int minDistantion = 40;
        const int maxSize = 7;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public class ellipseInfo
        {
            public int x { get; set; }
            public int y { get; set; }
            public Ellipse ellipse { get; set; }
            public List<Line> lines = new List<Line>();
        }
        public List<ellipseInfo> ellipseUpLayer = new List<ellipseInfo>();
        public List<ellipseInfo> ellipseMiddleLayer = new List<ellipseInfo>();
        public List<ellipseInfo> ellipseBottomLayer = new List<ellipseInfo>();
        public void CreateParalax(int list)
        {
            Random random = new Random();
            Canvas canvasToUpdate = new Canvas();
            SolidColorBrush color = new SolidColorBrush();
            if(list == 0)
            {
                canvasToUpdate = canvasUp;
                color = new SolidColorBrush(Colors.Black);
            }
            if (list == 1)
            {
                canvasToUpdate = canvasMiddle;
                color = new SolidColorBrush(Colors.Gray);
            }
            if (list == 2)
            {
                canvasToUpdate = canvasBottom;
                color = new SolidColorBrush(Colors.LightGray);
            }
            for (int i = 0; i < count; i++)
            {
                ellipseInfo newElement = new ellipseInfo();
                newElement.x = random.Next(20, (int)Width - 20);
                newElement.y = random.Next(20, (int)Height - 20);
                Ellipse ellipse = new Ellipse();
                Canvas.SetLeft(ellipse, newElement.x);
                Canvas.SetTop(ellipse, newElement.y);
                int widthEllips = random.Next(3, maxSize);
                ellipse.Width = widthEllips;
                ellipse.Height = widthEllips;
                ellipse.Fill = color;
                newElement.ellipse = ellipse;
                canvasToUpdate.Children.Add(newElement.ellipse);
                if (list == 0)
                {
                    ellipseUpLayer.Add(newElement);
                }
                if (list == 1)
                {
                    ellipseMiddleLayer.Add(newElement);
                }
                if (list == 2)
                {
                    ellipseBottomLayer.Add(newElement);
                }
            }
            ellipseInfo mouseElement = new ellipseInfo();
            mouseElement.x = (int)Mouse.GetPosition(canvasToUpdate).X;
            mouseElement.y = (int)Mouse.GetPosition(canvasToUpdate).Y;
            Ellipse mouseEllipse = new Ellipse();
            mouseEllipse.Width = 2;
            mouseEllipse.Height = 2;
            Canvas.SetLeft(mouseEllipse, mouseElement.x);
            Canvas.SetTop(mouseEllipse, mouseElement.y);
            mouseElement.ellipse = mouseEllipse;
            canvasToUpdate.Children.Add(mouseElement.ellipse);
            if (list == 0)
            {
                ellipseUpLayer.Add(mouseElement);
            }
            if (list == 1)
            {
                ellipseMiddleLayer.Add(mouseElement);
            }
            if (list == 2)
            {
                ellipseBottomLayer.Add(mouseElement);
            }
        }
        private void UpdateParalax(int list)
        {
            Random random = new Random();
            List<ellipseInfo> listToUpdate = new List<ellipseInfo>();
            Canvas canvasToUpdate = new Canvas();
            SolidColorBrush color = new SolidColorBrush();
            if (list == 0)
            {
                listToUpdate = ellipseUpLayer;
                canvasToUpdate = canvasUp;
                color = new SolidColorBrush(Colors.Black);
            }
            if (list == 1)
            {
                listToUpdate = ellipseMiddleLayer;
                canvasToUpdate = canvasMiddle;
                color = new SolidColorBrush(Colors.Gray);
            }
            if (list == 2)
            {
                listToUpdate = ellipseBottomLayer;
                canvasToUpdate = canvasBottom;
                color = new SolidColorBrush(Colors.LightGray);
            }
            listToUpdate[count].x = (int)Mouse.GetPosition(canvasToUpdate).X;
            listToUpdate[count].y = (int)Mouse.GetPosition(canvasToUpdate).Y;
            for (int i = 0; i < listToUpdate.Count; i++)
            {
                if (i < count)
                {
                    if (listToUpdate[i].x < 20)
                    {
                        listToUpdate[i].x += random.Next(0, maxTransform);
                    }
                    else if (listToUpdate[i].x > Width - 20)
                    {
                        listToUpdate[i].x += random.Next(-maxTransform, 0);
                    }
                    else
                    {
                        listToUpdate[i].x += random.Next(-maxTransform, maxTransform + 1);
                    }

                    if (listToUpdate[i].y < 20)
                    {
                        listToUpdate[i].y += random.Next(0, maxTransform);
                    }
                    else if (listToUpdate[i].y > Height - 20)
                    {
                        listToUpdate[i].y += random.Next(-maxTransform, 0);
                    }
                    else
                    {
                        listToUpdate[i].y += random.Next(-maxTransform, maxTransform + 1);
                    }
                }

                Canvas.SetLeft(listToUpdate[i].ellipse, listToUpdate[i].x);
                Canvas.SetTop(listToUpdate[i].ellipse, listToUpdate[i].y);

                for (int j = 0; j < listToUpdate[i].lines.Count; j++)
                {
                    canvasToUpdate.Children.Remove(listToUpdate[i].lines[j]);
                    listToUpdate[i].lines.Remove(listToUpdate[i].lines[j]);
                }

                for (int j = i + 1; j < ellipseUpLayer.Count; j++)
                {
                    double x1 = listToUpdate[i].x + listToUpdate[i].ellipse.Width / 2;
                    double y1 = listToUpdate[i].y + listToUpdate[i].ellipse.Width / 2;
                    double x2 = listToUpdate[j].x + listToUpdate[j].ellipse.Width / 2;
                    double y2 = listToUpdate[j].y + listToUpdate[j].ellipse.Width / 2;
                    double destination = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
                    if (destination < minDistantion)
                    {
                        Line line = new Line();
                        line.X1 = x1;
                        line.Y1 = y1;
                        line.X2 = x2;
                        line.Y2 = y2;
                        line.Stroke = color;
                        line.StrokeThickness = 1;
                        canvasToUpdate.Children.Add(line);
                        listToUpdate[i].lines.Add(line);
                    }
                }
            }
        }
        private void UpdateParalaxAll(object sender, EventArgs e)
        {
            UpdateParalax(2);
            UpdateParalax(1);
            UpdateParalax(0);
        }
        public MainWindow()
        {
            InitializeComponent();
            CreateParalax(2);
            CreateParalax(1);
            CreateParalax(0);

            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 30);
            dispatcherTimer.Tick += UpdateParalaxAll;
            dispatcherTimer.Start();
        }
    }
}
