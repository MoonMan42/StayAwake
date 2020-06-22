﻿using Services;
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
        public MainWindow()
        {
            InitializeComponent();
            PowerHelper.ForceSystemAwake();

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

        private void PlayQuack()
        {
            SoundPlayer player = new SoundPlayer(MrDuck.AudioResource.Quack);
            player.Play();
        }

        private void ExitProgram(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}