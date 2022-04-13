using Plugin.BluetoothLE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMitAlles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bluetooth : ContentPage
    {
        public ObservableCollection<BleDeviceModel> deviceList = new ObservableCollection<BleDeviceModel>();

        public Bluetooth()
        {
            InitializeComponent();
        }

        private void ButtonScan_Clicked(object sender, EventArgs e)
        {
            ScanBLE();
        }

        private void ButtonConnect_Clicked(object sender, EventArgs e)
        {
            ConnectBLE();
        }

        public void ScanBLE()
        {
            deviceListView.ItemsSource = deviceList;

            if (CrossBleAdapter.Current.Status != AdapterStatus.PoweredOn)
            {
                bluetoothLabel.Text = "Bluetooth is disabled!";
                return;
            }

            if (CrossBleAdapter.Current.IsScanning)
            {
                CrossBleAdapter.Current.StopScan();
                Debug.WriteLine("currently scanning.. StopScan()");
            }

            var scanner = CrossBleAdapter.Current.Scan().Subscribe(scanResult =>
            {
                if (scanResult.Device.Name != null)
                {
                    Debug.WriteLine(scanResult.Device.Name);
                    BleDeviceModel model = new BleDeviceModel();
                    model.Name = scanResult.Device.Name;
                    model.Uuid = scanResult.Device.NativeDevice.ToString();
                    deviceList.Add(model);
                }

                if (CrossBleAdapter.Current.IsScanning)
                {
                    bluetoothLabel.Text = "Scanning..";
                }
                else
                {
                    bluetoothLabel.Text = scanResult.Device.Name + " Connected!";
                }
            });
        }

        public void ConnectBLE()
        {
            if (CrossBleAdapter.Current.IsScanning)
            {
                CrossBleAdapter.Current.StopScan();
                Debug.WriteLine("currently scanning.. StopScan()");
            }
            CrossBleAdapter.Current.Scan().Subscribe(scanResult =>
            {
                scanResult.Device.Connect();
                if (scanResult.Device.IsConnected())
                {
                    bluetoothLabel.Text = "Connected!";
                    Debug.WriteLine("Connected!!");
                }
            });
        }
    }
}