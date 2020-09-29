﻿using Services;
using System;
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
            isMute = MrDuckSettings.Default.IsMrDuckMute;

            if (isMute)
            {
                muteCheckMenuHeader.IsChecked = true;
            }


            // play quack
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

        private void Quack_Clicked(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(MrDuck.AudioResource.Quack);
            player.Play();
        }
    }
}
