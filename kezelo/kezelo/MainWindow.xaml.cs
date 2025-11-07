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

namespace kezelo
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
        public void megjelenit(string fpath, ListBox lb)
        {
            string[]mappak= Directory.GetDirectories(fpath);
            string[] fajlok= Directory.GetFiles(fpath);

            lb.Items.Clear();
            lb.Items.Add("..");
            foreach(var item in mappak)
            {
                string[] darabok = item.Split('\\');
                lb.Items.Add(darabok[darabok.Length - 1]);
            }
            foreach (var item in fajlok)
            {
                string[] darabok = item.Split('\\');
                lb.Items.Add(darabok[darabok.Length - 1]);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fpath = path.Text;
            megjelenit(fpath, lb);
        }

        private void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rt.Document.Blocks.Clear();
            if (lb.SelectedItem == null) return;

            string newpath = System.IO.Path.Combine(path.Text, lb.SelectedItem.ToString());
            if (Directory.Exists(newpath))
            {
                path.Text = newpath;
                megjelenit(newpath, lb);
            }
            else if (lb.SelectedItem.ToString() == "..")
            {
                string parentPath = Directory.GetParent(path.Text).FullName;
                path.Text = parentPath;
                megjelenit(parentPath, lb);
            }
            else if (File.Exists(newpath))
            {
                rt.AppendText(File.ReadAllText(newpath));

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory(System.IO.Path.Combine(path.Text, mp.Text));
            megjelenit(path.Text, lb);
        }
    }
}
