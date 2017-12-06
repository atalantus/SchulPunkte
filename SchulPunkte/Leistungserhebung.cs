using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Media;
using System.Text.RegularExpressions;

namespace SchulPunkte
{
    [Serializable]
    public class Leistungserhebung
    {
        #region Attribute
        private Einstellungen einstellungen;

        public List<ImageSource> Bilder { get; set; }
        public int Punktzahl { get; set; }
        public string Note { get; private set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public DateTime Datum { get; set; }

        public int Gewichtung { get; set; }

        public enum Typen
        {
            Muendlich,
            Schriftlich,
            Klausur
        }

        public Typen Typ { get; set; }
        #endregion

        #region Konstruktoren
        public Leistungserhebung(string name, string beschreibung, int punktzahl, int gewichtung, Typen typ, DateTime datum)
        {
            this.Beschreibung = beschreibung;
            this.Punktzahl = punktzahl;
            this.Note = PunkteInNoteUmrechnen();
            this.Gewichtung = gewichtung;
            this.Typ = typ;
            this.Datum = datum;
            einstellungen = Einstellungen.Instance;
        }

        public Leistungserhebung(string name, string beschreibung, string note, int gewichtung, Typen typ, DateTime datum)
        {
            this.Beschreibung = beschreibung;
            this.Note = note;
            this.Punktzahl = NoteInPunkteUmrechnen();
            this.Gewichtung = gewichtung;
            this.Typ = typ;
            this.Datum = datum;
            einstellungen = Einstellungen.Instance;
        }
        #endregion

        #region Methoden
        /// <summary>
        /// Rechnet die Punktzahl in die jeweilige Note mit Vorzeichen um (1+, 1, 1-).
        /// </summary>
        /// <returns>Note mit Vorzeichen als string</returns>
        public string PunkteInNoteUmrechnen()
        {
            double Notendurchschnitt = (17d - Punktzahl) / 3d;
            int NoteRaw = (int)Math.Round(Notendurchschnitt);
            double Vorzeichen = Notendurchschnitt - Math.Truncate(Notendurchschnitt);
            string NoteVorzeichen = "";
            if (Vorzeichen != 0d && NoteRaw != 6)
            {
                if (Vorzeichen < 0.5d)
                    NoteVorzeichen = "-";
                else
                    NoteVorzeichen = "+";
            }
            return NoteRaw.ToString() + NoteVorzeichen;
        }

        /// <summary>
        /// Rechnet die Note mit Vorzeichen (1+, 1, 1-) in die jeweilige Punktzahl um.
        /// </summary>
        /// <returns>Punkte als int</returns>
        public int NoteInPunkteUmrechnen()
        {
            int Punktzahl = 0;

            string NoteRaw = Regex.Match(Note, @"\d+").Value;

            switch (NoteRaw)
            {
                case "1":
                    Punktzahl = 14;
                    break;
                case "2":
                    Punktzahl = 11;
                    break;
                case "3":
                    Punktzahl = 8;
                    break;
                case "4":
                    Punktzahl = 5;
                    break;
                case "5":
                    Punktzahl = 2;
                    break;
                case "6":
                    Punktzahl = 0;
                    break;
            }

            if (!Note.Contains("6"))
            {
                if (Note.Contains("+"))
                    Punktzahl++;
                else if (Note.Contains("-"))
                    Punktzahl--;
            }

            return Punktzahl;
        }
        #endregion
    }
}
