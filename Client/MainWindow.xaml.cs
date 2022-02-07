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
using Client.Service;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IServiceCallback
    {
        bool connected = false;
        public ServiceClient client;
        public int Id;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Connect_click(object sender, RoutedEventArgs e)
        {
            if (!connected)
            {
                client = ConnectToServer();
            }
            else
            {
                DisconnectIntoServer();
            }
        }
        public ServiceClient ConnectToServer()
        {
            try
            {
                client = new ServiceClient(new System.ServiceModel.InstanceContext(this));
                Id = client.Connect(UserName.Text);
                UserName.IsEnabled = false;
                Connect.Content = "Disconnect";
                connected = true;
                return client;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        private void DisconnectIntoServer()
        {
            try
            {
                client.Disconect(Id);
                client = null;
                UserName.IsEnabled = true;
                Connect.Content = "Connect";
                connected = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (client != null)
                {
                    client.SendMsg(ClientMsg.Text, Id);
                    ClientMsg.Text = string.Empty;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectIntoServer();
        }

        public void CallBackMsg(string msg)
        {
            Chat.Items.Add(msg);
            Chat.ScrollIntoView(Chat.Items[Chat.Items.Count - 1]);
        }
    }
}
