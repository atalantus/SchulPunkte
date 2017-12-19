using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulPunkte
{
    public class Manager
    {
        #region Attribute
        private static Manager _Instance = null;

        //TODO: System aendern
        // Eine Kurs Liste mit allen Kursen. Die Klasse Kurs enthaelt 5 booleans,
        // die angeben ob die Kurse im jeweiligen Semester vertreten sind.
        // Beim Laden eines Semesters die Kurse, die im jeweiligen Semester vorhanden sind
        // über LINQ rausfinden und in eine eigene "AktiveKurse" Liste packen.
        public ObservableCollection<Kurs> Kurse { get; set; }
        public ObservableCollection<Kurs> AktiveKurse { get; set; }
        public enum Semester
        {
            Erstes = 11_1,
            Zweites = 11_2,
            Drittes = 12_1,
            Viertes = 12_2
        }

        private Semester _AktivesSemester;
        public Semester AktivesSemester
        {
            get
            {
                return _AktivesSemester;
            }
            set
            {
                _AktivesSemester = value;
                AktivesSemester_ValueSet();
            }
        }

        public static Manager Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Manager();
                return _Instance;
            }
        }
        #endregion

        #region Konstruktoren
        private Manager()
        {
            Kurse = new ObservableCollection<Kurs>();
        }
        #endregion

        #region Methoden


        public List<Kurs> GetKurseAusAktuellemSemester()
        {
            return Kurse.Where(k => k.IsInActiveSemester()).ToList();
        }
        #endregion

        #region Event Handler
        public void AktivesSemester_ValueSet()
        {
            AktiveKurse = new ObservableCollection<Kurs>(GetKurseAusAktuellemSemester());
        }
        #endregion
    }
}
