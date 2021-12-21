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

namespace Projekt_GalImre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CheckBox> feladatokElemei = new List<CheckBox>();
        List<CheckBox> toroltekElemei = new List<CheckBox>();

        public MainWindow()
        {
            InitializeComponent();
            feladatokListaja.ItemsSource = feladatokElemei;
            toroltekListaja.ItemsSource = toroltekElemei;
        }

        private void hozzaadasGomb_Click(object sender, RoutedEventArgs e)
        {
            if (feladatNeve.Text != "")
            {
                CheckBox feladat = new CheckBox();
                feladat.IsChecked = false;
                feladat.Content = feladatNeve.Text;
                feladatokElemei.Add(feladat);
                feladatNeve.Clear();
                feladatokListaja.Items.Refresh();
                feladat.Checked += new RoutedEventHandler(pipa);
                feladat.Unchecked += new RoutedEventHandler(pipa);
            }

        }

        private void pipa(object sender, RoutedEventArgs e)
        {
            CheckBox feladat = (CheckBox)sender;
            if (feladat.IsChecked == true)
            {
                feladat.Foreground = Brushes.Gray;
                feladat.FontStyle = FontStyles.Italic;
            }
            else
            {
                feladat.Foreground = Brushes.Black;
                feladat.FontStyle = FontStyles.Normal;
            }

        }

        private void athelyezesGomb_Click(object sender, RoutedEventArgs e)
        {
            CheckBox feladat = (CheckBox)feladatokListaja.SelectedItem;
            toroltekElemei.Add(feladat);
            feladatokElemei.Remove(feladat);
            feladatNeve.Clear();
            feladatokListaja.Items.Refresh();
            toroltekListaja.Items.Refresh();

        }

        private void torlesGomb_Click(object sender, RoutedEventArgs e)
        {
            CheckBox feladat = (CheckBox)toroltekListaja.SelectedItem;
            toroltekElemei.Remove(feladat);
            toroltekListaja.Items.Refresh();
        }

        private void visszaalitasGomb_Click(object sender, RoutedEventArgs e)
        {
            CheckBox feladat = (CheckBox)toroltekListaja.SelectedItem;
            feladatokElemei.Add(feladat);
            toroltekElemei.Remove(feladat);
            feladatokListaja.Items.Refresh();
            toroltekListaja.Items.Refresh();
        }

        private void feladatokListaja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckBox feladat = (CheckBox)feladatokListaja.SelectedItem;
            if (feladat != null)
                feladatNeve.Text = (string)feladat.Content;
        }

        private void modositasGomb_Click(object sender, RoutedEventArgs e)
        {
            CheckBox feladat = (CheckBox)feladatokListaja.SelectedItem;
            feladat.Content = feladatNeve.Text;
        }
    }
}