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

namespace Wpfdomino
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Domino> adatok = new List<Domino>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("domino.txt");
            while (!sr.EndOfStream)
            {
                adatok.Add(new Domino(sr.ReadLine()));
            }
            sr.Close();
            tablazat.ItemsSource = adatok;
            tablazat.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int bal = Convert.ToInt32(tb1.Text);
            int jobb = Convert.ToInt32(tb2.Text);
            Boolean letezik = false;
            foreach (var item in adatok)
            {
                if ((item.bal == bal && item.jobb == jobb) || (item.bal == jobb && item.jobb == bal))
                {
                    letezik = true;
                    break;
                }
            }
            if (letezik)
            {
                MessageBox.Show("Létezik");
            }
            else
            {
                if (adatok[adatok.Count - 1].jobb == bal)
                {
                    adatok.Add(new Domino(bal, jobb));
                    tablazat.Items.Refresh();
                    MessageBox.Show("Hozzáadva");
                    StreamWriter sw = new StreamWriter("mentes.txt");
                    foreach (var item in adatok)
                    {
                        sw.WriteLine(item);
                    }
                    sw.Close();
                    
                }
                else
                {
                    MessageBox.Show("Nem illeszthető be");
                }
            }
        }
    }
}
