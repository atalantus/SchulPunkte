using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulPunkte
{
    [Serializable]
    public class Einstellungen
    {
        private static Einstellungen _Instance = null;

        public bool MitNotenRechnen { get; set; }
        public double VerhaeltnisMuendlichZuSchriftlich { get; set; }
        public double VerhaeltnisSchriftlichZuMuendlich { get; set; }

        private Einstellungen() { }

        public static Einstellungen Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Einstellungen();
                return _Instance;
            }
        }
    }
}
