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
        #region Attribute
        private Serialisierung Serialisierung;
        private Manager Manager;
        private Kurs SelectedKurs;
        private Style ListBoxItemStyle;
        #endregion

        #region Konstruktoren
        public KurseUebersicht()
        {
            InitializeComponent();
            Closing += OnWindowClosing;

            Serialisierung = Serialisierung.Instance;
            DataContext = Manager = Manager.Instance;
            ListBoxItemStyle = this.FindResource("defaultListBoxItem") as Style;

            Serialisierung.Laden();

            UpdateKurse();
        }
        #endregion

        #region Methoden
        public void UpdateKurse()
        {
           
        }

        public void UpdateGesamtUebersicht()
        {

        }

        public void UpdateKursUebersicht()
        {

        }

        public void UpdateLeistungserhebungen()
        {
            if (SelectedKurs == null)
            {
                LeistungserhebungenHeader.Content = "Kein Kurs ausgewählt!";
                AddLeistungserhebung.IsEnabled = false;
                return;
            }

            LeistungserhebungenHeader.Content = "Leistungserhebungen des Kurses: " + SelectedKurs.GetKursInfo();
            AddLeistungserhebung.IsEnabled = true;
        }
        #endregion

        #region Event Handler
        private void KurseEinstellenMenue_Click(object sender, RoutedEventArgs e)
        {
            KurseEinstellen kurseEinstellen = new KurseEinstellen(this);
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

        private void Help(object sender, RoutedEventArgs e)
        {

        }

        private void KurseListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedKurs = (Kurs) KurseListBox.SelectedValue;
            TabControl_SelectionChanged(null, null);
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (InfoTabs.SelectedIndex)
            {
                case 0:
                    UpdateGesamtUebersicht();
                    break;
                case 1:
                    UpdateKursUebersicht();
                    break;
                case 2:
                    UpdateLeistungserhebungen();
                    break;
            }
        }

        private void AddLeistungserhebung_Click(object sender, RoutedEventArgs e)
        {
            LeistungserhebungHinzufuegen leistungserhebungHinzufuegen = new LeistungserhebungHinzufuegen();
            leistungserhebungHinzufuegen.ShowDialog();
            leistungserhebungHinzufuegen.Activate();
            leistungserhebungHinzufuegen.Focus();
        }
        #endregion
    }
}
