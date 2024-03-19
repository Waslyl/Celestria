using System;
using System.Diagnostics;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Celestria
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            contentFrame.Source = new Uri("Pages/Home.xaml", UriKind.Relative);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new Uri("Pages/Home.xaml", UriKind.Relative));
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new Uri("Pages/Download.xaml", UriKind.Relative));
        }


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void camthestupid_click(object sender, RoutedEventArgs e)
        {
            string url = "https://cash.app/$heszy";

            System.Diagnostics.Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
