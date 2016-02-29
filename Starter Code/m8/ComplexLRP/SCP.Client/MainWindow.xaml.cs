using SCP.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using System.ServiceModel;
using SCP.Contracts;

namespace SCP.Client
{
    public partial class MainWindow : Window, ILongRunningCallback
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //LongRunClient _Proxy;
        LongRunningDuplexClient _Proxy;
        bool _Cancel = false;

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //LongRunClient proxy = new LongRunClient();
            //proxy.StartProcess();
            //proxy.Close();

            //_Proxy = new LongRunClient();
            
            _Proxy = new LongRunningDuplexClient(new InstanceContext(this));

            _Cancel = false;
            _Proxy.StartProcess();

            btnStart.IsEnabled = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            _Cancel = true;
            _Proxy.Abort();
        }

        public bool ReportNumber(int number)
        {
            lblNumber.Content = number.ToString();

            return _Cancel;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _Cancel = true;
            btnStart.IsEnabled = true;
        }
    }
}
