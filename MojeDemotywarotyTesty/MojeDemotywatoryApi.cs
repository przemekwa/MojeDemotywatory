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
            var fabryka = new DemotywatoryApi("http://demotywatory.pl/");

             var rezult = fabryka.PobierzDemotywatoryZGłownej();

            Assert.AreEqual(rezult.ToList().Count, 10);
        }

        [TestMethod]
        public void PobierzDemotywatoryZeSlajdow()
        {
            var fabryka = new DemotywatoryApi("http://demotywatory.pl/");

            var rezult = fabryka.PobierzDemotywatoryZeSlajdow("4405857/10-ciekawostek-o-ludzkim-organizmie-ktore-cie-zadziwia");

            Assert.AreEqual(rezult.ToList().Count, 9);
        }


        [TestMethod]
        public void PobierzDemotywatoryZeStron()
        {
            var fabryka = new DemotywatoryApi("http://demotywatory.pl/");

            var rezult = fabryka.PobierzDemotywatoryZeStron(2);

            Assert.AreEqual(rezult.ToList().Count, 20);
        }

        [TestMethod]
        public void SprawdzCzySaSlajdy()
        {
            var fabryka = new DemotywatoryApi("http://demotywatory.pl/");

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
            var fabryka = new DemotywatoryApi("http://demotywatory.pl/");

            var rezult = fabryka.PobierzDemotywatoryZGłownej();

            Assert.AreNotEqual(true, rezult.All(demot => string.IsNullOrEmpty(demot.ObrazekUrl)));
            
        }

        [TestMethod]
        public void SprawdźCzyJestAdresLinkuZObrazka()
        {
            var fabryka = new DemotywatoryApi("http://demotywatory.pl/");

            var rezult = fabryka.PobierzDemotywatoryZGłownej();

            Assert.AreNotEqual(true, rezult.All(demot => string.IsNullOrEmpty(demot.AdresUrl)));

        }
      


    }
}
