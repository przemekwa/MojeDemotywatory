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
            var fabryka = new DemotywatorApi("http://demotywatory.pl/");

             var rezult = fabryka.GetMainPage();

            Assert.AreEqual(rezult.DemotywatorList.Count, 7);
        }

        [TestMethod]
        public void PobierzDemotywatoryZeSlajdow()
        {
            DemotywatorApi.DemotywatorAddress = "http://demotywatory.pl/";

            var rezult = ApiTools.PobierzDemotywatoryZeSlajdow("4405857/10-ciekawostek-o-ludzkim-organizmie-ktore-cie-zadziwia");

            Assert.AreEqual(rezult.ToList().Count, 9);
        }


        [TestMethod]
        public void PobierzDemotywatoryZeStron()
        {
            var fabryka = new DemotywatorApi("http://demotywatory.pl/");

            var rezult = fabryka.GetPages(1,2);

            Assert.AreEqual(rezult.Count(), 2);
        }

        [TestMethod]
        public void SprawdzCzySaSlajdy()
        {
           // var fabryka = new DemotywatorApi("http://demotywatory.pl/");

           // var rezult = fabryka.GetPages(1, 1);

           //if (rezult.ToList().Any(l => l.DemotywatorList.Any(d => d.CzySaSlajdy == true)))
           //{
           //    Assert.Fail();
           //}
           
          

           
        }


        [TestMethod]
        public void SprawdźCzyJestAdresObrazka()
        {
            var fabryka = new DemotywatorApi("http://demotywatory.pl/");

            var rezult = fabryka.GetMainPage().DemotywatorList;

            Assert.AreNotEqual(true, rezult.All(demot => string.IsNullOrEmpty(demot.ImgUrl)));
            
        }

        [TestMethod]
        public void SprawdźCzyJestAdresLinkuZObrazka()
        {
            var fabryka = new DemotywatorApi("http://demotywatory.pl/");

            var rezult = fabryka.GetMainPage().DemotywatorList;

            Assert.AreNotEqual(true, rezult.All(demot => string.IsNullOrEmpty(demot.Url)));

        }
      


    }
}
