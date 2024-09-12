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

namespace Logistik
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Page2());

           //Page1Button.Visibility = Visibility.Collapsed;
           //Page2Button.Visibility = Visibility.Collapsed;
           //Page3Button.Visibility = Visibility.Collapsed;
           //Page4Button.Visibility = Visibility.Collapsed;
           //Page5Button.Visibility = Visibility.Collapsed;
           //Page6Button.Visibility = Visibility.Collapsed;
           // Page7Button.Visibility = Visibility.Collapsed;


        }
        //Klienti
        private void Page1Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Shohzod lohay");
            MainFrame.Navigate(new Page1());
            Page1Button.Background = (Brush)new BrushConverter().ConvertFromString("#0C4E40");
            Page2Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page3Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page4Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page5Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page7Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
        }

        //NewOrder
        private void Page2Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page2());
            Page1Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page2Button.Background = (Brush)new BrushConverter().ConvertFromString("#0C4E40");
            Page3Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page4Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page5Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page7Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");

        }

        private void Page3Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page3());
            Page1Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page2Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page3Button.Background = (Brush)new BrushConverter().ConvertFromString("#0C4E40");
            Page4Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page5Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page7Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
        }



        //TrnsportVehicle
        private void Page4Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page4());
            Page1Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page2Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page3Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page4Button.Background = (Brush)new BrushConverter().ConvertFromString("#0C4E40");
            Page5Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page7Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");

        }
        //Drivers
        private void Page5Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page5());
            Page1Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page2Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page3Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page4Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page5Button.Background = (Brush)new BrushConverter().ConvertFromString("#0C4E40");
            Page7Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
        }
        //Close
        private void Page6Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Page7Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page7());
            Page1Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page2Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page3Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page4Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page5Button.Background = (Brush)new BrushConverter().ConvertFromString("#1ABC9C");
            Page7Button.Background = (Brush)new BrushConverter().ConvertFromString("#0C4E40");

        }
    }
}
