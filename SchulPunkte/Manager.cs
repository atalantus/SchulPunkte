using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulPunkte
{
    public class Manager
    {
        private static Manager _Instance = null;

        public List<Kurs> Kurse { get; set; }

        private Manager()
        {
            Kurse = new List<Kurs>();
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
