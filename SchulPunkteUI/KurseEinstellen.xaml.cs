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
using System.Windows.Shapes;
using SchulPunkte;
using System.Diagnostics;
using System.ComponentModel;

namespace SchulPunkteUI
{
    /// <summary>
    /// Interaction logic for KurseEinstellen.xaml
    /// </summary>
    public partial class KurseEinstellen : Window
    {
        #region Attribute
        private KursListBoxItem SelectedKurs;
        private Style ListBoxItemStyle;
        private List<char> NichtErlaubt;
        private KurseUebersicht KurseUebersicht;
        private bool EinfachesSchliessen;

        private Manager Manager;
        #endregion

        #region Konstruktor
        public KurseEinstellen(KurseUebersicht kurseUebersicht, bool einfachesSchliessen = true)
        {
            InitializeComponent();
            ListBoxItemStyle = this.FindResource("defaultListBoxItem") as Style;

            EinfachesSchliessen = einfachesSchliessen;
            Manager = Manager.Instance;
            SelectedKurs = null;
            KurseUebersicht = kurseUebersicht;
            NichtErlaubt = new List<char>() { '(', ';', '*', ':', '\\', '"', '/', ')' };

            foreach (Kurs kurs in Manager.Kurse)
            {
                KursListBoxItem kursItem = new KursListBoxItem(kurs, kurs.GetKursInfo())
                {
                    Style = ListBoxItemStyle
                };
                KurseListBox.Items.Add(kursItem);
            }

            NeuerKursname.IsEnabled = false;
            NeueKursnummer.IsEnabled = false;
            KursnameFeedback.Content = "";
            KursnummerFeedback.Content = "";
        }
        #endregion

        #region Methoden
        /// <summary>
        /// Ueberprueft, ob ein Kursname in der aktuellen Liste bereits vorkommt.
        /// </summary>
        /// <param name="neuerKursname">Kursname, der ueberprueft werden soll.</param>
        /// <returns>false, wenn der Kursname bereits vorkommt, ansonsten false</returns>
        private bool KursnamePruefen(KursListBoxItem neuerKurs)
        {
            string neuerKursname = neuerKurs.Kurs.Kursname;

            if (neuerKurs.Kurs.Kursname.ToLower() != "kursname")
            {
                foreach (KursListBoxItem kursItem in KurseListBox.Items)
                {
                    if (kursItem.Kurs.Kursname.ToLower() == neuerKursname.ToLower() && kursItem != neuerKurs)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Ueberprueft, ob der String einen der chars in der 'NichtErlaubt' Liste enthält.
        /// </summary>
        /// <param name="name">String der ueberprueft werden soll.</param>
        /// <returns>UnerlaubtesZeichen Objekt</returns>
        private UnerlaubtesZeichen StringPruefen(string name)
        {
            foreach (char c in NichtErlaubt)
            {
                if (name.Contains(c))
                    return new UnerlaubtesZeichen(true, c);
            }
            return new UnerlaubtesZeichen(false);
        }

        /// <summary>
        /// Ueberprueft, ob eine Kursnummer in der aktuellen Liste bereits vorkommt.
        /// </summary>
        /// <param name="neueKursnummer">Kursnummer, die ueberprueft werden soll.</param>
        /// <returns>false, wenn die Kursnummer bereits vorkommt, ansonsten false</returns>
        private bool KursnummerPruefen(KursListBoxItem neuerKurs)
        {
            string neueKursnummer = neuerKurs.Kurs.Kursnummer;

            if (neuerKurs.Kurs.Kursnummer.ToLower() != "kursnummer")
            {
                foreach (KursListBoxItem kursItem in KurseListBox.Items)
                {
                    if (kursItem.Kurs.Kursnummer.ToLower() == neueKursnummer.ToLower() && kursItem != neuerKurs)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Ueberprueft, ob ein Kurs Objekt in der Liste einen Fehler hat (Fehler ist true)
        /// und enabled oder disabled je nachdem den 'WeiterBtn'.
        /// </summary>
        private void FehlerPruefen()
        {
            bool listeEnthaeltFehler = false;
            foreach (KursListBoxItem kursItem in KurseListBox.Items)
            {
                if (kursItem.IsFehler())
                {
                    kursItem.Foreground = new SolidColorBrush(Color.FromArgb(255, 249, 38, 74));
                    listeEnthaeltFehler = true;
                }
                else
                {
                    kursItem.Foreground = new SolidColorBrush(Color.FromArgb(255, 241, 241, 241));
                }
            }

            if (listeEnthaeltFehler)
                WeiterBtn.IsEnabled = false;
            else
                WeiterBtn.IsEnabled = true;
        }
        #endregion

        #region Event Handler
        /// <summary>
        /// Click Event fuer 'Neuen Kurs hinzufuegen' Button
        /// Fuegt neuen Kurs mit Standart Werten hinzu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KursHinzufuegen(object sender, RoutedEventArgs e)
        {
            KursListBoxItem leererKurs = new KursListBoxItem(new Kurs("Kursname", "Kursnummer"), "Kursname (Kursnummer)")
            {
                Style = ListBoxItemStyle
            };
            KurseListBox.Items.Add(leererKurs);
            KurseListBox.SelectedItem = leererKurs;
            SelectedKurs = leererKurs;
            NeuerKursname.Focus();
            NeuerKursname.SelectAll();
        }

        /// <summary>
        /// SelectionChanged Event fuer Kurs Liste
        /// Aktualisiert die 'Kurs bearbeiten' Inputs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KurseListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            SelectedKurs = (KursListBoxItem)KurseListBox.SelectedValue;

            if (SelectedKurs == null)
                return;

            NeuerKursname.IsEnabled = true;
            NeueKursnummer.IsEnabled = true;
            NeuerKursname.Text = SelectedKurs.Kurs.Kursname;
            NeueKursnummer.Text = SelectedKurs.Kurs.Kursnummer;
        }

        /// <summary>
        /// TextChanged Event fuer 'NeuerKursname' Input
        /// Ueberprueft, den neuen Kursnamen fuer den aktuell 
        /// ausgewaehlten Kurs. Passt etwas nicht, wird eine Fehlermeldung unter dem
        /// Input Feld angezeigt, ansonsten uebernimmt das ausgewaehlte 
        /// Kurs Objekt in der Kurs Liste die Kursname und Kursnummer Werte, der
        /// 'Kurs bearbeiten' Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NeuerKursname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SelectedKurs == null)
                return;

            SelectedKurs.Kurs.Kursname = NeuerKursname.Text;
            UnerlaubtesZeichen unerlaubtesZeichen = StringPruefen(NeuerKursname.Text);

            if (unerlaubtesZeichen.Error)
            {
                KursnameFeedback.Content = "Ungültiges Zeichen: " + unerlaubtesZeichen.Zeichen;
                SelectedKurs.KursnameFehler = true;
            }
            else if (!KursnamePruefen(SelectedKurs))
            {
                KursnameFeedback.Content = "Dieser Kursname existiert bereits!";
                SelectedKurs.KursnameFehler = true;
            }
            else
            {
                KursnameFeedback.Content = "";
                SelectedKurs.KursnameFehler = false;
            }

            FehlerPruefen();

            SelectedKurs.Content = NeuerKursname.Text + " (" + NeueKursnummer.Text + ")";
        }

        /// <summary>
        /// TextChanged Event fuer 'NeueKursnummer' Input
        /// Ueberprueft, die neue Kursnummer fuer den aktuell 
        /// ausgewaehlten Kurs. Passt etwas nicht, wird eine Fehlermeldung unter dem
        /// Input Feld angezeigt, ansonsten uebernimmt das ausgewaehlte 
        /// Kurs Objekt in der Kurs Liste die Kursname und Kursnummer Werte, der
        /// 'Kurs bearbeiten' Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NeueKursnummer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SelectedKurs == null)
                return;

            SelectedKurs.Kurs.Kursnummer = NeueKursnummer.Text;
            UnerlaubtesZeichen unerlaubtesZeichen = StringPruefen(NeueKursnummer.Text);

            if (unerlaubtesZeichen.Error)
            {
                KursnummerFeedback.Content = "Ungültiges Zeichen: " + unerlaubtesZeichen.Zeichen;
                SelectedKurs.KursnummerFehler = true;
            }
            else if (!KursnummerPruefen(SelectedKurs))
            {
                KursnummerFeedback.Content = "Diese Kursnummer existiert bereits!";
                SelectedKurs.KursnummerFehler = true;
            }
            else
            {
                KursnummerFeedback.Content = "";
                SelectedKurs.KursnummerFehler = false;
            }

            FehlerPruefen();

            SelectedKurs.Content = NeuerKursname.Text + " (" + NeueKursnummer.Text + ")";
        }

        /// <summary>
        /// NeuerKursname Input Field wird ueber Tab-key gefocused. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NeuerKursname_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
                NeuerKursname.SelectAll();
        }

        /// <summary>
        /// NeueKursnummer Input Field wird ueber Tab-key gefocused. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NeueKursnummer_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
                NeueKursnummer.SelectAll();
        }

        private void Help(object sender, RoutedEventArgs e)
        {
            Process.Start(Manager.HilfURL);
        }

        /// <summary>
        /// Speichert die neuen Kurse und schliesst das Fenster.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeiterBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.Kurse.Clear();
            foreach (KursListBoxItem kursItem in KurseListBox.Items)
            {
                if (kursItem.Kurs.Kursname.ToLower() != "kursname" && kursItem.Kurs.Kursnummer.ToLower() != "kursnummer")
                    Manager.Kurse.Add(kursItem.Kurs);
            }

            KurseUebersicht.UpdateKurse();

            if (!EinfachesSchliessen)
            {
                KurseUebersicht.Show();
                KurseUebersicht.Activate();
                KurseUebersicht.Focus();
            }

            Close();
        }

        private void KursErstesSemester_Checked(object sender, RoutedEventArgs e)
        {
            SelectedKurs.Kurs.Semester[0] = (bool)KursErstesSemester.IsChecked;
        }

        private void KursZweitesSemester_Checked(object sender, RoutedEventArgs e)
        {
            SelectedKurs.Kurs.Semester[1] = (bool)KursZweitesSemester.IsChecked;
        }

        private void KursDrittesSemester_Checked(object sender, RoutedEventArgs e)
        {
            SelectedKurs.Kurs.Semester[2] = (bool)KursDrittesSemester.IsChecked;
        }

        private void KursViertesSemester_Checked(object sender, RoutedEventArgs e)
        {
            SelectedKurs.Kurs.Semester[3] = (bool)KursViertesSemester.IsChecked;
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (!EinfachesSchliessen && !KurseUebersicht.IsActive)
                KurseUebersicht.Close();
        }
        //TODO: Kurse löschen können (nach Bestaetigung)
        //Moechtest du wirklich den Kurs #kurs mit n eingetragenen Leistungserhebungen loeschen?
        #endregion
    }

    #region Structs
    public struct UnerlaubtesZeichen
    {
        public char Zeichen { get; set; }
        public bool Error { get; set; }

        public UnerlaubtesZeichen(bool error, char zeichen = 'e')
        {
            Error = error;
            Zeichen = zeichen;
        }
    }
    #endregion
}
