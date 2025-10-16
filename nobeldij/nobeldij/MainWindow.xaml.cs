using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
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

namespace Nobeldij
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        List<dij> nobelDijak = new List<dij>();
        public MainWindow()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("nobel.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                nobelDijak.Add(new dij(sr.ReadLine()));
            }
            sr.Close();
            tablazat.ItemsSource = nobelDijak;
            tablazat.Items.Refresh();
        }

        private void felvisz_Click(object sender, RoutedEventArgs e)
        {
            dij newDij = new dij(Convert.ToInt32(ev.Text), tipus.Text, keresztnev.Text, vezeteknev.Text);
            nobelDijak.Add(newDij);
            tablazat.Items.Refresh();
        }

        private void torol_Click(object sender, RoutedEventArgs e)
        {
            if (tablazat.SelectedItem != null)
            {
                dij selectedDij = (dij)tablazat.SelectedItem;
                nobelDijak.Remove(selectedDij);
                tablazat.Items.Refresh();
            }
        }

        private void kiir_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("dijak2.csv");
            foreach (var item in nobelDijak)
            {
                sw.WriteLine(item.ToString());
            }
        }
    }
}