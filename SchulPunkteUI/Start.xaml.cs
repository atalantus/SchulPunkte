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
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();
            //TODO: Loading
        }

        public void Continue()
        {
            string folderPath = System.IO.Path.Combine(Serialisierung.SpeicherPfad, Serialisierung.OrdnerName);

            if (System.IO.Directory.Exists(folderPath))
            {
                Serialisierung.Instance.Laden();
                KurseUebersicht kurseUebersicht = null;

                switch (Manager.Instance.AktivesSemester)
                {
                    case Manager.Semester.Erstes:
                        kurseUebersicht = new KurseUebersicht("Semester 11/1");
                        break;
                    case Manager.Semester.Zweites:
                        kurseUebersicht = new KurseUebersicht("Semester 11/2");
                        break;
                    case Manager.Semester.Drittes:
                        kurseUebersicht = new KurseUebersicht("Semester 12/1");
                        break;
                    case Manager.Semester.Viertes:
                        kurseUebersicht = new KurseUebersicht("Semester 12/2");
                        break;
                }

                kurseUebersicht.Show();
                kurseUebersicht.Activate();
                kurseUebersicht.Focus();
            } else
            {
                SemesterWaehlen SemesterWaehlen = new SemesterWaehlen(true);
                SemesterWaehlen.Show();
                SemesterWaehlen.Activate();
                SemesterWaehlen.Focus();
            }

            Close();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            Continue();
        }
    }
}
