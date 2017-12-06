using SchulPunkte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for KurseUebersicht.xaml
    /// </summary>
    public partial class KurseUebersicht : Window
    {
        private Serialisierung Serialisierung;
        private Manager Manager;

        public KurseUebersicht()
        {
            InitializeComponent();
            Closing += OnWindowClosing;

            Serialisierung = new Serialisierung();
            Manager = Manager.Instance;

            Serialisierung.Laden();
        }

        private void KurseEinstellenMenue_Click(object sender, RoutedEventArgs e)
        {
            KurseEinstellen kurseEinstellen = new KurseEinstellen();
            kurseEinstellen.ShowDialog();
            kurseEinstellen.Activate();
            kurseEinstellen.Focus();
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Serialisierung.Speichern();
        }

        private void MainWindowMenue_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            mainWindow.Activate();
            mainWindow.Focus();
        }
    }
}
