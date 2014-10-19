using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MojeDemotywatoryApi;
using System.Collections;
using System.Linq;

namespace MojeDemotywarotyTesty
{
    [TestClass]
    public class MojeDemotywatoryApi
    {
        [TestMethod]
        public void PobierzDemotywatoryZGłownej()
        {
            var fabryka = new FabrykaDemotywatorow("http://demotywatory.pl/");

            var rezult = fabryka.PobierzDemotywatoryZGłownej();

            Assert.AreEqual(rezult.Count, 10);
        }

        [TestMethod]
        public void PobierzDemotywatoryZeStron()
        {
            var fabryka = new FabrykaDemotywatorow("http://demotywatory.pl/");

            var rezult = fabryka.PobierzDemotywatoryZeStron(2);

            Assert.AreEqual(rezult.Count, 19);
        }

        [TestMethod]
        public void SprawdźCzyJestAdresObrazka()
        {
            var fabryka = new FabrykaDemotywatorow("http://demotywatory.pl/");

            var rezult = fabryka.PobierzDemotywatoryZGłownej();

            Assert.AreNotEqual(true, rezult.All(demot => string.IsNullOrEmpty(demot.ObrazekUrl)));
            
        }

        [TestMethod]
        public void SprawdźCzyJestAdresLinkuZObrazka()
        {
            var fabryka = new FabrykaDemotywatorow("http://demotywatory.pl/");

            var rezult = fabryka.PobierzDemotywatoryZGłownej();

            Assert.AreNotEqual(true, rezult.All(demot => string.IsNullOrEmpty(demot.AdresUrl)));

        }
      


    }
}
