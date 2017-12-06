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

namespace SchulPunkteUI
{
    /// <summary>
    /// Interaction logic for KurseEinstellen.xaml
    /// </summary>
    public partial class KurseEinstellen : Window
    {
        ListBoxItem selectedKurs;

        public KurseEinstellen()
        {
            InitializeComponent();
        }

        private void KursHinzufuegen(object sender, RoutedEventArgs e)
        {
            ListBoxItem leererKurs = new ListBoxItem();
            Style listBoxItemStyle = this.FindResource("defaultListBoxItem") as Style;
            leererKurs.Style = listBoxItemStyle;
            leererKurs.Content = "Kursname (Kursnummer)";
            KurseListBox.Items.Add(leererKurs);
            KurseListBox.SelectedItem = leererKurs;
        }

        private void KurseListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            selectedKurs = (ListBoxItem)KurseListBox.SelectedValue;

            string selectedText = selectedKurs.Content.ToString();
            string[] texts = selectedText.Split('(');
            string kursname = texts[0];
            string kursnummer = texts[1];
            kursname = kursname.Remove(kursname.Length - 1);
            kursnummer = kursnummer.Remove(kursnummer.Length - 1);

            NeuerKursname.Text = kursname;
            NeueKursnummer.Text = kursnummer;
        }

        private void KursBearbeiten_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool fehler = false;

            if (NeuerKursname.Text.Contains("("))
            {
                KursnameFeedback.Content = "Ungültiges Zeichen: (";
                fehler = true;
            } else
                KursnameFeedback.Content = "";

            if (NeueKursnummer.Text.Contains("("))
            {
                KursnummerFeedback.Content = "Ungültiges Zeichen: (";
                fehler = true;
            } else
                KursnummerFeedback.Content = "";

            if (fehler)
                return;

            selectedKurs.Content = NeuerKursname.Text + " (" + NeueKursnummer.Text + ")";
        }

        private void NeuerKursname_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
                NeuerKursname.SelectAll();
        }

        private void NeueKursnummer_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
                NeueKursnummer.SelectAll();
        }

        private void Help(object sender, RoutedEventArgs e)
        {
            //TODO: show help message
        }

        private void WeiterBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        //TODO: ability to delete kurse
    }
}
