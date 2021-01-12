using Services;
using System;
using System.ComponentModel;
using System.Media;
using System.Runtime.InteropServices;
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


        public MainWindow()
        {
            InitializeComponent();

            isMute = false; // set isMute default value and then check settings

            // see if program is muted
            isMute = MrDuckSettings.Default.IsMrDuckMute;

            if (isMute)
            {
                muteCheckMenuHeader.IsChecked = true;
            }


            // play quack at startup
            PlayQuack();
        }



        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                PlayQuack();
                this.DragMove();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            PowerHelper.ResetSystemDefault();
            base.OnClosing(e);

        }

        private void ExitProgram(object sender, RoutedEventArgs e)
        {
            PowerHelper.ResetSystemDefault();
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

            if (!muteCheckMenuHeader.IsChecked)
            {
                isMute = false;
            }
            else
            {
                isMute = true;
            }

            MrDuckSettings.Default.IsMrDuckMute = isMute;
            MrDuckSettings.Default.Save();
        }



        private void PlayQuack()
        {

            if (!isMute)
            {
                SoundPlayer player = new SoundPlayer(MrDuck.AudioResource.Quack);
                player.Play();
            }

        }

        private void Quack_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(MrDuck.AudioResource.Quack);
            player.Play();
        }

        private void OpenPhoneMsg_Click(object sender, RoutedEventArgs e)
        {
            OnThePhoneWindow onThePhoneW = new OnThePhoneWindow();
            onThePhoneW.WindowStartupLocation = WindowStartupLocation.Manual;
            onThePhoneW.Show();
        }
    }


}
