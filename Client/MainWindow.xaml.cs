using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
using Microsoft.Win32;

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
        bool fileIsSelected = false;
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
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(client!=null)
            DisconnectIntoServer();
        }

        public void CallBackMsg(string msg)
        {
            Chat.Items.Add(msg);
            Chat.ScrollIntoView(Chat.Items[Chat.Items.Count - 1]);
            ProgressAnswer.IsIndeterminate = false;
        }

        public void MsgBoxError(string msg)
        {
            MessageBox.Show(msg, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ClientMsg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Nullable<bool> result = false;
            try
            {
                OpenFileDialog sf = new OpenFileDialog();
                sf.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                result = sf.ShowDialog();
                if(result == false)
                {
                    MessageBox.Show("Файл не выбран", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                fileIsSelected = true;
                ClientMsg.Text = sf.FileName;
            }
            catch (Exception ex)
            {
                if (result == false)
                {
                    MessageBox.Show(ex.Message,"Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }

        private void SendFileToServer_Click(object sender, RoutedEventArgs e)
        {
            if (client != null && fileIsSelected)
            {
                ProgressAnswer.IsIndeterminate = true;
                client.SendMsg(ReadFile(ClientMsg.Text), System.IO.Path.GetFileName(ClientMsg.Text), Id);
                ClientMsg.Text = "Выберите файл";
                fileIsSelected = false;
            }
            else
            {
                MessageBox.Show("Не удалось отправить файл", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string ReadFile(string path)
        {
            string TextFile = File.ReadAllText(path.Replace("\n", " "));
            return TextFile;
        }
    }
}
