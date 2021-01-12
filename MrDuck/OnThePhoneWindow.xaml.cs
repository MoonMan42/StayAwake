using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MrDuck
{
    /// <summary>
    /// Interaction logic for OnThePhoneWindow.xaml
    /// </summary>
    public partial class OnThePhoneWindow : Window
    {
        //#b58fc4
        //#8fa4c4

        private static Timer _timer;
        private static bool backgroundState;

        public OnThePhoneWindow()
        {
            InitializeComponent();

            backgroundState = false;

            SetTimer();

        }

        private static void SetTimer()
        {
            // create the timer
            _timer = new Timer(3000); // 3 secs

            // hook up elapsed time
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // update background
            if (backgroundState)
            {
                PhoneGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b58fc4"));
            }
            else
            {
                PhoneGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b58fc4"));
            }
        }
    }
}
