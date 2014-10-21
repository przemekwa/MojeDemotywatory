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

            Assert.AreEqual(rezult.ToList().Count, 10);
        }

        [TestMethod]
        public void PobierzDemotywatoryZeSlajdow()
        {
            var fabryka = new FabrykaDemotywatorow("http://demotywatory.pl/");

            var rezult = fabryka.PobierzDemotywatoryZeSlajdow("4405352/8-psychologicznych-trikow-ktore-pomoga-ci-wplywac-na-ludzi");

            Assert.AreEqual(rezult.Count, 8);
        }


        [TestMethod]
        public void PobierzDemotywatoryZeStron()
        {
            var fabryka = new FabrykaDemotywatorow("http://demotywatory.pl/");

            var rezult = fabryka.PobierzDemotywatoryZeStron(2);

            Assert.AreEqual(rezult.Count, 20);
        }

        [TestMethod]
        public void SprawdzCzySaSlajdy()
        {
            var fabryka = new FabrykaDemotywatorow("http://demotywatory.pl/");

            var rezult = fabryka.PobierzDemotywatoryZeStron(1);

            if (!rezult.Any(x => x.czySlajdy == true))
            {
                Assert.Fail();
            }

            var memKtoryMaSlajdy = rezult.Where(x => x.czySlajdy == true);

            Assert.AreEqual(true, memKtoryMaSlajdy.All(x => x.slajdy != null));
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
