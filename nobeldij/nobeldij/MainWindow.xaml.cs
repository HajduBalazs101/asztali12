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

namespace nobeldij
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        List<nobel> nobelDijak = new List<nobel>();
        public MainWindow()
        {
            StreamReader sr = new StreamReader("nobel.csv");
            while (!sr.EndOfStream)
            {
                string[] adat = sr.ReadLine().Split(';');
                nobelDijak.Add(new nobel(adat[0], adat[1], adat[2], adat[3], adat[4], adat[5], adat[6]));
            }
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //felvisz
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //torol
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //kiir
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //kilep
            Application.Current.Shutdown();
        }
    }
}
