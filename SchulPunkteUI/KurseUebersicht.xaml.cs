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
        private KursListBoxItem SelectedKurs;
        private Style ListBoxItemStyle;
        #endregion

        #region Konstruktoren
        public KurseUebersicht()
        {
            InitializeComponent();
            Closing += OnWindowClosing;

            Serialisierung = Serialisierung.Instance;
            Manager = Manager.Instance;
            ListBoxItemStyle = this.FindResource("defaultListBoxItem") as Style;

            Serialisierung.Laden();

            foreach (Kurs kurs in Manager.Kurse)
            {
                KursListBoxItem kursItem = new KursListBoxItem(kurs, kurs.GetKursInfo());
                //kursItem.Style = ListBoxItemStyle;
                KurseListBox.Items.Add(kursItem);
            }
        }
        #endregion

        #region Methoden
        private void UpdateGesamtUebersicht()
        {

        }

        private void UpdateKursUebersicht()
        {

        }

        private void UpdateLeistungserhebungen()
        {
            if (SelectedKurs == null)
            {
                LeistungserhebungenHeader.Content = "Kein Kurs ausgewählt!";
                AddLeistungserhebung.IsEnabled = false;
                return;
            }

            LeistungserhebungenHeader.Content = "Leistungserhebungen des Kurses: " + SelectedKurs.Kurs.GetKursInfo();
            AddLeistungserhebung.IsEnabled = true;
            foreach (Leistungserhebung kurs in SelectedKurs.Kurs.Leistungserhebungen)
            {
                LeistungserhebungListBoxItem leistungserhebungItem = new LeistungserhebungListBoxItem();
                //kursItem.Style = ListBoxItemStyle;
                LeistungserhebungsListe.Items.Add(leistungserhebungItem);
            }
        }
        #endregion

        #region Event Handler
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

        private void Help(object sender, RoutedEventArgs e)
        {

        }

        private void KurseListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedKurs = (KursListBoxItem) KurseListBox.SelectedValue;
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

        }
        #endregion
    }
}
