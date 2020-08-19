using Services;
using System;
using System.IO;
using System.Media;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace MrDuck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isMute;

        private static Timer _timer;


        public MainWindow()
        {
            InitializeComponent();

            isMute = false; // set isMute default value and then check settings

            // see if program is muted
            ReadSavedSettings();

            if (isMute)
            {
                muteCheckMenuHeader.IsChecked = true;
            }


            // play quack
            PlayQuack();

            // check time (disable/activate based off time)
            _timer = new Timer(50000); // 5 sec interval
            _timer.Elapsed += CheckTime;
            _timer.Start();
        }



        private void CheckTime(Object source, ElapsedEventArgs e)
        {
            var date = DateTime.Now;
            if (date.Hour >= 0 && date.Hour <= 12)
            {
                PowerHelper.ResetSystemDefault();
                this.Dispatcher.Invoke(() => stayAwakeHeader.IsChecked = false);
            }
            else if (date.Hour >= 12 && date.Hour <= 24)
            {
                PowerHelper.ForceSystemAwake();
                this.Dispatcher.Invoke(() => stayAwakeHeader.IsChecked = true);
            }
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                PlayQuack();
                this.DragMove();
            }
        }

        private void PlayQuack_Click(object sender, RoutedEventArgs e)
        {
            PlayQuack();
        }


        private void ExitProgram(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void StayAwake_Checked(object sender, RoutedEventArgs e)
        {
            PowerHelper.ForceSystemAwake();
        }

        private void DoNotStayAwake_UnChecked(object sender, RoutedEventArgs e)
        {
            PowerHelper.ResetSystemDefault();
        }

        private void MuteDuck_Checked(object sender, RoutedEventArgs e)
        {
            isMute = true;
            UpdateReadSettings();
        }

        private void UnMuteDuck_UnChecked(object sender, RoutedEventArgs e)
        {
            isMute = false;
            UpdateReadSettings();
        }


        private void PlayQuack()
        {
            if (!isMute)
            {
                SoundPlayer player = new SoundPlayer(MrDuck.AudioResource.Quack);
                player.Play();
            }
        }

        private void ReadSavedSettings()
        {
            try
            {
                using (var sr = new StreamReader("SettingsFile.txt"))
                {
                    isMute = bool.Parse(sr.ReadToEnd());
                }
            }
            catch
            {

            }
        }

        private void UpdateReadSettings()
        {
            try
            {
                using (var sw = new StreamWriter("SettingsFile.txt"))
                {
                    sw.WriteLine(isMute.ToString());
                }
            }
            catch
            {

            }
        }
    }
}
