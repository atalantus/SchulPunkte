using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SchulPunkte
{
    public class KursListBoxItem : ListBoxItem
    {
        public Kurs Kurs { get; set; }
        public bool KursnameFehler { get; set; }
        public bool KursnummerFehler { get; set; }

        //TODO: string kursname, kursnummer einbauen
        // so kann man vllt dann doch '(' in Kursnamen einbauen
        // wenn man list Objekt durch Attribute splittet

        public KursListBoxItem(Kurs kurs)
        {
            Kurs = kurs;
        }

        public KursListBoxItem(Kurs kurs, string content)
        {
            Kurs = kurs;
            base.Content = content;
        }

        public KursListBoxItem(Kurs kurs, Style style, string content)
        {
            Kurs = kurs;
            base.Style = style;
            base.Content = content;
        }

        public bool IsFehler()
        {
            return (KursnameFehler || KursnummerFehler);
        }
    }
}
