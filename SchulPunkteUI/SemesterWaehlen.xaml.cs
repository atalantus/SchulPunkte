using SchulPunkte;
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

namespace SchulPunkteUI
{
    /// <summary>
    /// Interaction logic for SemesterWaehlen.xaml
    /// </summary>
    public partial class SemesterWaehlen : Window
    {
        private bool ErstesMal = false;

        public SemesterWaehlen()
        {
            InitializeComponent();
        }

        public SemesterWaehlen(bool ohneAbbrechen)
        {
            InitializeComponent();

            if (ohneAbbrechen)
            {
                ErstesMal = true;
                Abbrechen.Visibility = Visibility.Hidden;
            }
        }

        private void Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Auswaehlen_Click(object sender, RoutedEventArgs e)
        {
            KurseUebersicht kurseUebersicht = null;

            switch (SemesterListView.SelectedIndex)
            {
                case 0:
                    kurseUebersicht = new KurseUebersicht("Semester 11/1");
                    Manager.Instance.AktivesSemester = Manager.Semester.Erstes;
                    break;
                case 1:
                    kurseUebersicht = new KurseUebersicht("Semester 11/2");
                    Manager.Instance.AktivesSemester = Manager.Semester.Zweites;
                    break;
                case 2:
                    kurseUebersicht = new KurseUebersicht("Semester 12/1");
                    Manager.Instance.AktivesSemester = Manager.Semester.Drittes;
                    break;
                case 3:
                    kurseUebersicht = new KurseUebersicht("Semester 12/2");
                    Manager.Instance.AktivesSemester = Manager.Semester.Viertes;
                    break;
            }

            if (!ErstesMal)
            {
                kurseUebersicht.Show();
                kurseUebersicht.Activate();
                kurseUebersicht.Focus();
            } else
            {
                KurseEinstellen kurseEinstellen = new KurseEinstellen(kurseUebersicht, false);
                kurseEinstellen.Show();
                kurseEinstellen.Activate();
                kurseEinstellen.Focus();
            }

            Close();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Auswaehlen_Click(null, null);
        }
    }
}
