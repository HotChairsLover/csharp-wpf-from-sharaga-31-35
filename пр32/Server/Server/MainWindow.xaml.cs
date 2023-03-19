using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace Server
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool enable = false;
        public MainWindow()
        {
            InitializeComponent(); 
        }
        public async Task Listen()
        {
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);

                while (enable)
                {
                    Socket handler = await sListener.AcceptAsync();
                    string data = null;

                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);

                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    Label mes = new Label();
                    mes.Content = "Полученный текст:" + data + "\n\n";
                    parrent.Children.Add(mes);
                    DBFunctions.UploadMessage(data);

                    string reply = data.Length.ToString();
                    byte[] msg = Encoding.UTF8.GetBytes(reply);
                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
                sListener.Close();
            }
            catch (Exception ex)
            {
                if (ex.GetType().ToString() == "System.Net.Sockets.SocketException")
                {

                }
                else
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private async void Start(object sender, RoutedEventArgs e)
        {
            if (!enable)
            {
                enable = true;
                startButton.Content = "Выключить";
                await Listen();
            }
            else
            {
                enable = false;
                startButton.Content = "Включить";
            }
        }
    }
}
