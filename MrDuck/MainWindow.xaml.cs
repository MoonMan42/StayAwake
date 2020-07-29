using Services;
using System.IO;
using System.Media;
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
            ReadSavedSettings();

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
