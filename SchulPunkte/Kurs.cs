using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulPunkte
{
    [Serializable]
    public class Kurs
    {
        #region Attribute
        public string Kursnummer { get; set; }
        public string Kursname { get; set; }
        public bool[] Semester { get; set; }
        public string KursInfo
        {
            get
            {
                return GetKursInfo();
            }
            private set { }
        }
        public string KursID { get { return Kursname; } private set { } }
        public List<Leistungserhebung> Leistungserhebungen { get; private set; }
        private List<Leistungserhebung> KleineLE { get; set; }
        private List<Leistungserhebung> GrosseLE { get; set; }
        #endregion

        #region Konstruktoren
        public Kurs(string kursname)
        {
            this.Kursnummer = kursname;
            this.Kursname = kursname;
            Semester = new bool[4];
            Leistungserhebungen = new List<Leistungserhebung>();
            KleineLE = new List<Leistungserhebung>();
            GrosseLE = new List<Leistungserhebung>();
        }

        public Kurs(string kursname, string kursnummer)
        {
            this.Kursnummer = kursnummer;
            this.Kursname = kursname;
            Semester = new bool[4];
            Leistungserhebungen = new List<Leistungserhebung>();
            KleineLE = new List<Leistungserhebung>();
            GrosseLE = new List<Leistungserhebung>();
        }
        #endregion

        #region Methoden
        public void ChangeKursSemester(bool erstesSemester, bool zweitesSemester, bool drittesSemester, bool viertesSemester)
        {
            Semester[0] = erstesSemester;
            Semester[1] = zweitesSemester;
            Semester[2] = drittesSemester;
            Semester[3] = viertesSemester;
        }

        public bool IsInActiveSemester()
        {
            switch (Manager.Instance.AktivesSemester)
            {
                case Manager.Semester.Erstes:
                    return Semester[0];
                case Manager.Semester.Zweites:
                    return Semester[1];
                case Manager.Semester.Drittes:
                    return Semester[2];
                case Manager.Semester.Viertes:
                    return Semester[3];
            }
            return false;
        }

        public void AddLeistungserhebung(Leistungserhebung leistungserhebung)
        {
            Leistungserhebungen.Add(leistungserhebung);

            if (leistungserhebung.Typ == Leistungserhebung.Typen.Klausur)
                GrosseLE.Add(leistungserhebung);
            else
                KleineLE.Add(leistungserhebung);
        }

        public void AddLeistungserhebungen(List<Leistungserhebung> leistungserhebungen)
        {
            Leistungserhebungen.AddRange(leistungserhebungen);

            foreach(Leistungserhebung l in leistungserhebungen)
            {
                if (l.Typ == Leistungserhebung.Typen.Klausur)
                    GrosseLE.Add(l);
                else
                    KleineLE.Add(l);
            }
        }

        public double GesamtDurchschnittBerechnen()
        {
            return Math.Truncate(((DurchschnittBerechnen(KleineLE) + DurchschnittBerechnen(GrosseLE)) / 2) * 100) / 100;
        }

        private double DurchschnittBerechnen(List<Leistungserhebung> leistungserhebungen)
        {
            double gesamtPunkte = 0;

            foreach(Leistungserhebung l in leistungserhebungen)
            {
                gesamtPunkte += l.Punktzahl * l.Gewichtung;
            }

            return gesamtPunkte / leistungserhebungen.Count;
        }

        public string GetKursInfo()
        {
            return Kursname + " (" + Kursnummer + ")";
        }
        #endregion
    }
}
