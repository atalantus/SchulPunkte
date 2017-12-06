using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchulPunkte;

namespace SchulPunkteTest
{
    [TestClass]
    public class KursTests
    {
        [TestMethod]
        public void GesamtDurchschnittBerechnenTest()
        {
            Leistungserhebung l8 = new Leistungserhebung("name", "beschreibung", 6, 1, Leistungserhebung.Typen.Muendlich, DateTime.Now);
            Leistungserhebung l7 = new Leistungserhebung("name", "beschreibung", 4, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l6 = new Leistungserhebung("name", "beschreibung", 6, 1, Leistungserhebung.Typen.Muendlich, DateTime.Now);
            Leistungserhebung l5 = new Leistungserhebung("name", "beschreibung", 15, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l4 = new Leistungserhebung("name", "beschreibung", 10, 1, Leistungserhebung.Typen.Muendlich, DateTime.Now);
            Leistungserhebung l3 = new Leistungserhebung("name", "beschreibung", 14, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l2 = new Leistungserhebung("name", "beschreibung", 11, 1, Leistungserhebung.Typen.Muendlich, DateTime.Now);
            Leistungserhebung l1 = new Leistungserhebung("name", "beschreibung", 8, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung lk = new Leistungserhebung("name", "beschreibung", 13, 1, Leistungserhebung.Typen.Klausur, DateTime.Now);

            Kurs kurs = new Kurs("Kursname", "Kursnummer");
            Kurs kurs02 = new Kurs("Kursname", "Kursnummer");

            kurs.AddLeistungserhebungen(new System.Collections.Generic.List<Leistungserhebung>() { lk, l1, l2, l3, l4 });
            kurs02.AddLeistungserhebungen(new System.Collections.Generic.List<Leistungserhebung>() { lk, l1, l2, l3, l4, l5, l6, l7, l8 });
            Assert.AreEqual(11.87d, kurs.GesamtDurchschnittBerechnen());
            Assert.AreEqual(11.12d, kurs02.GesamtDurchschnittBerechnen());
        }
    }
}
