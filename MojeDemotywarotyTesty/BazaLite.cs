using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BazaLite;

namespace MojeDemotywarotyTesty
{
    /// <summary>
    /// Summary description for BazaLite
    /// </summary>
    [TestClass]
    public class BazaLite
    {
        public BazaLite()
        {
            //
            // TODO: Add constructor logic here
            //
        }
         
        [TestMethod]
        public void BazaOdczytaj()
        {
            var bazaTest = new Baza("test");

            bazaTest.Dodaj("Pierwsza");
            bazaTest.Dodaj("Druga");
            bazaTest.Dodaj("Trzecia");
            bazaTest.Dodaj("Piąta");
            bazaTest.Dodaj("Czwarta");
            

            foreach (var t in bazaTest.Odczytaj())
            {
                Assert.AreNotEqual("", t);
            }

            
        }
    }
}
