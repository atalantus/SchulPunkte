using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SchulPunkte
{
    public class Serialisierung
    {
        //TODO: Singleton machen
        //TODO: Mehrere Speicherungen pro Semester. Siehe Menueleiste
        #region Attribute
        private string _SpeicherPfad = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public Manager Manager { get; private set; }
        public Einstellungen Einstellungen { get; private set; }

        public string SpeicherPfad
        {
            get
            {
                return _SpeicherPfad;
            }
            set
            {
                _SpeicherPfad = value;
            }
        }
        #endregion

        #region Konstruktoren
        public Serialisierung()
        {
            Manager = Manager.Instance;
            Einstellungen = Einstellungen.Instance;
        }
        #endregion

        #region Methoden
        public bool Speichern()
        {
            try
            {
                string ordnerPfad = Path.Combine(_SpeicherPfad, "SchulPunkte");

                if (!Directory.Exists(ordnerPfad))
                {
                    Directory.CreateDirectory(ordnerPfad);
                }

                SpeicherDaten speicherDaten = new SpeicherDaten
                {
                    //speicherDaten.TestSpeicherDatenSetzen();
                    Kurse = Manager.Kurse
                };

                FileStream datei = new FileStream(Path.Combine(ordnerPfad, "Saves.dat"), FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(datei, speicherDaten);
                datei.Close();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.GetBaseException());
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
                return false;
            }
        }

        public bool Laden()
        {
            try
            {
                string ordnerPfad = Path.Combine(_SpeicherPfad, "SchulPunkte");

                if (!Directory.Exists(ordnerPfad))
                {
                    Debug.WriteLine("Der gesuchte Ordner existiert nicht!");
                    return false;
                }
                else if (!File.Exists(Path.Combine(ordnerPfad, "Saves.dat")))
                {
                    Debug.WriteLine("Die gesuchte Datei existiert nicht!");
                    return false;
                }

                SpeicherDaten speicherDaten;

                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream datei = new FileStream(Path.Combine(ordnerPfad, "Saves.dat"), FileMode.Open);

                speicherDaten = (SpeicherDaten)binaryFormatter.Deserialize(datei);
                Manager.Kurse = speicherDaten.Kurse;
                Einstellungen = speicherDaten.Einstellungen;

                datei.Close();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.GetBaseException());
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
                return false;
            }
        }
        #endregion
    }

    /// <summary>
    /// Die Klasse, die am Ende abgespeichert und auch wieder geladen wird.
    /// </summary>
    [Serializable]
    public class SpeicherDaten
    {
        #region Attribute
        public List<Kurs> Kurse { get; set; }
        public Einstellungen Einstellungen { get; private set; }
        #endregion

        #region Konstruktoren
        public SpeicherDaten()
        {
            Kurse = new List<Kurs>();
            Einstellungen = Einstellungen.Instance;
        }
        #endregion
    }
}
