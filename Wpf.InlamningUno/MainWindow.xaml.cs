using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Win32;

namespace Wpf.InlamningUno
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fil = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> resultat = fil.ShowDialog();

            if (resultat == true)
            {
                var uri = new System.Uri(fil.FileName);
                mediaElement.Source = uri;
                
            }
            else
            {
                MessageBox.Show("Du måste välja en videofil");
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
            BtnPlay.Visibility = Visibility.Hidden;
            BtnPause.Visibility = Visibility.Visible;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
            BtnPlay.Visibility = Visibility.Visible;
            BtnPause.Visibility = Visibility.Hidden;
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
        }

        private void BtnRotate_Click(object sender, RoutedEventArgs e)
        {
            TransformGroup group = new TransformGroup();
            group.Children.Add(new RotateTransform(90));
            group.Children.Add(new TranslateTransform(this.mediaElement.ActualWidth, 5));
            this.mediaElement.RenderTransform = group;
        }
    }
}
