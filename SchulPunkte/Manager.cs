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
        private static Manager _Instance = null;

        //TODO: System aendern
        // Eine Kurs Liste mit allen Kursen. Die Klasse Kurs enthaelt 5 booleans,
        // die angeben ob die Kurse im jeweiligen Semester vertreten sind.
        // Beim Laden eines Semesters die Kurse, die im jeweiligen Semester vorhanden sind
        // über LINQ rausfinden und in eine eigene "AktiveKurse" Liste packen.
        private ObservableCollection<Kurs> _KurseErstes { get; set; }
        private ObservableCollection<Kurs> _KurseZweites { get; set; }
        private ObservableCollection<Kurs> _KurseDrittes { get; set; }
        private ObservableCollection<Kurs> _KurseViertes { get; set; }

        public ObservableCollection<Kurs> Kurse
        {
            get
            {
                return GetKurs();
            }
            private set { }
        }

        public enum Semester
        {
            Erstes = 11_1,
            Zweites = 11_2,
            Drittes = 12_1,
            Viertes = 12_2
        }
        public Semester AktivesSemester;

        private Manager()
        {
            _KurseErstes = new ObservableCollection<Kurs>();
            _KurseZweites = new ObservableCollection<Kurs>();
            _KurseDrittes = new ObservableCollection<Kurs>();
            _KurseViertes = new ObservableCollection<Kurs>();
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

        private ObservableCollection<Kurs> GetKurs()
        {
            switch (AktivesSemester)
            {
                case Semester.Erstes:
                    return _KurseErstes;
                case Semester.Zweites:
                    return _KurseZweites;
                case Semester.Drittes:
                    return _KurseDrittes;
                case Semester.Viertes:
                    return _KurseViertes;
            }
            return null;
        }

        public void SetKurse(ObservableCollection<Kurs> kurseErstes,
            ObservableCollection<Kurs> kurseZweites,
            ObservableCollection<Kurs> kurseDrittes,
            ObservableCollection<Kurs> kurseViertes)
        {
            _KurseErstes = kurseErstes;
            _KurseZweites = kurseZweites;
            _KurseDrittes = kurseDrittes;
            _KurseViertes = kurseViertes;
        }

        public List<Kurs> GetKurseErstes() { return _KurseErstes.ToList(); }
        public List<Kurs> GetKurseZweites() { return _KurseZweites.ToList(); }
        public List<Kurs> GetKurseDrittes() { return _KurseDrittes.ToList(); }
        public List<Kurs> GetKurseViertes() { return _KurseViertes.ToList(); }
    }
}
