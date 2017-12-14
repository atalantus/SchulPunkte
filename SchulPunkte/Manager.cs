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

        public ObservableCollection<Kurs> Kurse { get; set; }

        private Manager()
        {
            Kurse = new ObservableCollection<Kurs>();
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
    }
}
