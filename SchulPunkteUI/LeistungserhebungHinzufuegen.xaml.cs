using SchulPunkte;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace SchulPunkteUI
{
    /// <summary>
    /// Interaction logic for LeistungserhebungHinzufuegen.xaml
    /// </summary>
    public partial class LeistungserhebungHinzufuegen : Window
    {
        #region Attribute
        private Leistungserhebung Leistungserhebung;
        private List<string> Bilder;
        private static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
       
        #endregion

        #region Konstuktoren
        public LeistungserhebungHinzufuegen()
        {
            InitializeComponent();

            Leistungserhebung = new Leistungserhebung();
            Bilder = new List<string>();
            TypComboBox.ItemsSource = Enum.GetValues(typeof(Leistungserhebung.Typen)).Cast<Leistungserhebung.Typen>();
        }
        #endregion

        #region Methoden
        #endregion

        #region Event Handler
        private void Speichern_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImagePanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach(string f in files)
                {
                    if (ImageExtensions.Contains(f.ToUpperInvariant()))
                    {
                        Bilder.Add(f);
                    }
                }
            }
        }

        private void BilderExplorerButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }

        private void Help(object sender, RoutedEventArgs e)
        {
            Process.Start(Manager.HilfURL);
        }
        #endregion
    }
}
