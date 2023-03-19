using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public async Task SendMessageFromSocket()
        {
            byte[] bytes = new byte[1024];
            var readEvent = new AutoResetEvent(false);
            var sendEvent = new AutoResetEvent(false);

            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);
            try
            {
                Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                await sender.ConnectAsync(ipEndPoint);

                string message = messages.Text;
                messages.Text = "";

                byte[] msg = Encoding.UTF8.GetBytes(message);

                Label mes = new Label();
                mes.Content = "Я: " + message;
                parrent.Children.Add(mes);
                sender.Send(msg);
                int bytesRec = 0;
                do
                {
                    bytesRec = sender.Receive(bytes, bytes.Length, 0);
                }
                while (sender.Available > 0);

                sender.Shutdown(SocketShutdown.Both);
                sender.Close();

                mes = new Label();
                mes.Content = "Ответ от сервера: " + Encoding.UTF8.GetString(bytes, 0, bytesRec) + " + символов.";
                parrent.Children.Add(mes);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private async void SendMessage(object sender, RoutedEventArgs e)
        {
            if(messages.Text != "")
            {
                await SendMessageFromSocket();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите сообщение.");
            }
        }
    }
}
