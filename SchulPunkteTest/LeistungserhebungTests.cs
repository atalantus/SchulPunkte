using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchulPunkte;
using System.Diagnostics;

namespace SchulPunkteTest
{
    [TestClass]
    public class LeistungserhebungTests
    {
        [TestMethod]
        public void PunkteInNoteTest()
        {
            Leistungserhebung l15 = new Leistungserhebung("name", "beschreibung", 15, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l14 = new Leistungserhebung("name", "beschreibung", 14, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l13 = new Leistungserhebung("name", "beschreibung", 13, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l12 = new Leistungserhebung("name", "beschreibung", 12, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l11 = new Leistungserhebung("name", "beschreibung", 11, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l10 = new Leistungserhebung("name", "beschreibung", 10, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l9 = new Leistungserhebung("name", "beschreibung", 9, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l8 = new Leistungserhebung("name", "beschreibung", 8, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l7 = new Leistungserhebung("name", "beschreibung", 7, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l6 = new Leistungserhebung("name", "beschreibung", 6, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l5 = new Leistungserhebung("name", "beschreibung", 5, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l4 = new Leistungserhebung("name", "beschreibung", 4, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l3 = new Leistungserhebung("name", "beschreibung", 3, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l2 = new Leistungserhebung("name", "beschreibung", 2, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l1 = new Leistungserhebung("name", "beschreibung", 1, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l0 = new Leistungserhebung("name", "beschreibung", 0, 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);

            Assert.AreEqual("1+", l15.PunkteInNoteUmrechnen());
            Assert.AreEqual("1", l14.PunkteInNoteUmrechnen());
            Assert.AreEqual("1-", l13.PunkteInNoteUmrechnen());
            Assert.AreEqual("2+", l12.PunkteInNoteUmrechnen());
            Assert.AreEqual("2", l11.PunkteInNoteUmrechnen());
            Assert.AreEqual("2-", l10.PunkteInNoteUmrechnen());
            Assert.AreEqual("3+", l9.PunkteInNoteUmrechnen());
            Assert.AreEqual("3", l8.PunkteInNoteUmrechnen());
            Assert.AreEqual("3-", l7.PunkteInNoteUmrechnen());
            Assert.AreEqual("4+", l6.PunkteInNoteUmrechnen());
            Assert.AreEqual("4", l5.PunkteInNoteUmrechnen());
            Assert.AreEqual("4-", l4.PunkteInNoteUmrechnen());
            Assert.AreEqual("5+", l3.PunkteInNoteUmrechnen());
            Assert.AreEqual("5", l2.PunkteInNoteUmrechnen());
            Assert.AreEqual("5-", l1.PunkteInNoteUmrechnen());
            Assert.AreEqual("6", l0.PunkteInNoteUmrechnen());
        }

        [TestMethod]
        public void NoteInPunkteTest()
        {
            Leistungserhebung l1Plus = new Leistungserhebung("name", "beschreibung", "1+", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l1 = new Leistungserhebung("name", "beschreibung", "1", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l1Minus = new Leistungserhebung("name", "beschreibung", "1-", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l2Plus = new Leistungserhebung("name", "beschreibung", "+2", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l2 = new Leistungserhebung("name", "beschreibung", "2", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l2Minus = new Leistungserhebung("name", "beschreibung", "2-", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l3Plus = new Leistungserhebung("name", "beschreibung", "3+", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l3 = new Leistungserhebung("name", "beschreibung", "3", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l3Minus = new Leistungserhebung("name", "beschreibung", "3-", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l4Plus = new Leistungserhebung("name", "beschreibung", "+4", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l4 = new Leistungserhebung("name", "beschreibung", "4", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l4Minus = new Leistungserhebung("name", "beschreibung", "4-", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l5Plus = new Leistungserhebung("name", "beschreibung", "5+", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l5 = new Leistungserhebung("name", "beschreibung", "5", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l5Minus = new Leistungserhebung("name", "beschreibung", "-5", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l6Plus = new Leistungserhebung("name", "beschreibung", "6+", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l6 = new Leistungserhebung("name", "beschreibung", "6", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);
            Leistungserhebung l6Minus = new Leistungserhebung("name", "beschreibung", "-6", 1, Leistungserhebung.Typen.Schriftlich, DateTime.Now);

            Assert.AreEqual(15, l1Plus.NoteInPunkteUmrechnen());
            Assert.AreEqual(14, l1.NoteInPunkteUmrechnen());
            Assert.AreEqual(13, l1Minus.NoteInPunkteUmrechnen());
            Assert.AreEqual(12, l2Plus.NoteInPunkteUmrechnen());
            Assert.AreEqual(11, l2.NoteInPunkteUmrechnen());
            Assert.AreEqual(10, l2Minus.NoteInPunkteUmrechnen());
            Assert.AreEqual(9, l3Plus.NoteInPunkteUmrechnen());
            Assert.AreEqual(8, l3.NoteInPunkteUmrechnen());
            Assert.AreEqual(7, l3Minus.NoteInPunkteUmrechnen());
            Assert.AreEqual(6, l4Plus.NoteInPunkteUmrechnen());
            Assert.AreEqual(5, l4.NoteInPunkteUmrechnen());
            Assert.AreEqual(4, l4Minus.NoteInPunkteUmrechnen());
            Assert.AreEqual(3, l5Plus.NoteInPunkteUmrechnen());
            Assert.AreEqual(2, l5.NoteInPunkteUmrechnen());
            Assert.AreEqual(1, l5Minus.NoteInPunkteUmrechnen());
            Assert.AreEqual(0, l6Plus.NoteInPunkteUmrechnen());
            Assert.AreEqual(0, l6.NoteInPunkteUmrechnen());
            Assert.AreEqual(0, l6Minus.NoteInPunkteUmrechnen());
        }
    }
}
