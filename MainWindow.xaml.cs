using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPF_APP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> imagesStore;
        private int currentIndex = 0;
        public MainWindow()
        {
            InitializeComponent();
            LoadImages(@"C:\Mac\Home\Downloads\images");
            DisplayImage();
        }
        
        private void LoadImages(string path)
        {
            if (Directory.Exists(path)) 
            {
                imagesStore = new List<string>(Directory.GetFiles((path),"*.jpg"));
                imagesStore.AddRange(Directory.GetFiles((path), "*.png"));
                imagesStore.AddRange(Directory.GetFiles((path), "*.bmp"));
            }
        }

        private void DisplayImage()
        {
            if (imagesStore == null || imagesStore.Count == 0)
            {
                MessageBox.Show("Папка пустая или нет изображений");
                return;
            }
            var imagePath = imagesStore[currentIndex];
            DisplayImageForm.Source = new BitmapImage(new Uri(imagePath));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            //Закрыть все окна
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
