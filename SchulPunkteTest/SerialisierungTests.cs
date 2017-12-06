using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchulPunkte;

namespace SchulPunkteTest
{
    [TestClass]
    public class SerialisierungTests
    {
        [TestMethod]
        public void SpeichernTest()
        {
            Serialisierung serialisierung = Serialisierung.Instance;

            Assert.AreEqual(true, serialisierung.Speichern());
        }

        [TestMethod]
        public void LadenTest()
        {
            Serialisierung serialisierung = Serialisierung.Instance;

            Assert.AreEqual(true, serialisierung.Laden());
        }
    }
}
