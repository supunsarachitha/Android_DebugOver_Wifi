using SharpAdbClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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

namespace Android_DebugOver_Wifi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        AdbClient adbClient = new AdbClient();
        List<DeviceData> devices;
        public MainWindow()
        {
            InitializeComponent();

           
            AdbServer server = new AdbServer();
            StartServerResult result = server.StartServer(@"C:\Program Files (x86)\Android\android-sdk\platform-tools\adb.exe", restartServerIfNewer: false);
            txtStatus.Text = "Adb Status : "+ result.ToString();
            txtIP.Text = Properties.Settings.Default.LastIp;
            GetListOfDevices();

            var monitor = new DeviceMonitor(new AdbSocket(new IPEndPoint(IPAddress.Loopback, AdbClient.AdbServerPort)));
            monitor.DeviceConnected += this.OnDeviceConnected;
            monitor.DeviceDisconnected += Monitor_DeviceDisconnected;
            monitor.Start();

            
        }

        private void Monitor_DeviceDisconnected(object sender, DeviceDataEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => { Bindlist(); }));
        }

        private void OnDeviceConnected(object sender, DeviceDataEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => { Bindlist(); }));
            
            
        }

        private void Bindlist()
        {
            try
            {
                lstDevices.ItemsSource = null;
                devices = null;
                devices = adbClient.GetDevices();

                List<DeviceData> listofD = new List<DeviceData>();

                lstDevices.ItemsSource = devices;
                
            }
            catch (Exception ex)
            {

                return;
            }
        }

        private async void GetListOfDevices()
        {


            Application.Current.Dispatcher.BeginInvoke(new Action(() => { Bindlist(); }));



        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //txtIP.Text = ((DeviceData)lstDevices.SelectedItem).Serial.ToString();
                adbClient.Connect(txtIP.Text);

                MessageBox.Show("Operation Success. Disconnect your device from PC");

                Properties.Settings.Default.LastIp = txtIP.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("Operation failed");
                return;
            }
                
        }

        private void lstDevices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //if (lstDevices.SelectedItem != null)
            //{
            //    txtIP.Text = ((DeviceData)lstDevices.SelectedItem).Serial.ToString();
            //}
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (devices.Count > 0)
                {
                    foreach (var item in devices)
                    {
                        if (item.Serial.Contains(":5555"))
                        {
                            adbClient.Disconnect(new DnsEndPoint(item.Serial.Replace(":5555", ""), 5555));
                        }
                    }
                        
                }
            }
            catch (Exception)
            {

                return;
            }
           
            
        }
    }
}
