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
            var api = new DemotywatoryApi("http://demotywatory.pl/");

             var rezult = api.GetMainPage();

            Assert.AreEqual(rezult.DemotywatorList.Count, 6);
        }

        [TestMethod]
        public void PobierzDemotywatory()
        {
            var api = new DemotywatoryApi("http://demotywatory.pl/");

            var rezult = api.GetPage(1);

            Assert.AreEqual(rezult.DemotywatorList.Count, 7);
        }

        [TestMethod]
        public void PobierzDemotywatoryZeSlajdow()
        {
            var rezult = ApiTools.PobierzDemotywatoryZeSlajdow("http://demotywatory.pl/4405857/10-ciekawostek-o-ludzkim-organizmie-ktore-cie-zadziwia");

            Assert.AreEqual(rezult.ToList().Count, 9);
        }


        [TestMethod]
        public void PobierzDemotywatoryZeStron()
        {
            var api = new DemotywatoryApi("http://demotywatory.pl/");

            var rezult = api.GetPages(1,2);

            Assert.AreEqual(rezult.Count(), 2);
        }



        [TestMethod]
        public void SprawdźCzyJestAdresObrazka()
        {
            var fabryka = new DemotywatoryApi("http://demotywatory.pl/");

            var rezult = fabryka.GetMainPage().DemotywatorList;

            Assert.AreNotEqual(true, rezult.All(demot => string.IsNullOrEmpty(demot.ImgUrl)));
            
        }

        [TestMethod]
        public void SprawdźCzyJestAdresLinkuZObrazka()
        {
            var fabryka = new DemotywatoryApi("http://demotywatory.pl/");

            var rezult = fabryka.GetMainPage().DemotywatorList;

            Assert.AreNotEqual(true, rezult.All(demot => string.IsNullOrEmpty(demot.Url)));

        }
    }
}
