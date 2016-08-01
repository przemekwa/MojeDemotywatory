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
            var api = new DemotivatorApi("http://demotywatory.pl/");

             var rezult = api.GetMainPage();

            Assert.AreEqual(rezult.DemotivatorList.Count, 6);
        }

        [TestMethod]
        public void PobierzDemotywatory()
        {
            var api = new DemotivatorApi("http://demotywatory.pl/");

            var rezult = api.GetPage(1);

            Assert.AreEqual(rezult.DemotivatorList.Count, 7);
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
            var api = new DemotivatorApi("http://demotywatory.pl/");

            var rezult = api.GetPages(1,2);

            Assert.AreEqual(rezult.Count(), 2);
        }



        [TestMethod]
        public void SprawdźCzyJestAdresObrazka()
        {
            var fabryka = new DemotivatorApi("http://demotywatory.pl/");

            var rezult = fabryka.GetMainPage().DemotivatorList;

            Assert.AreNotEqual(true, rezult.All(demot => string.IsNullOrEmpty(demot.ImgUrl)));
            
        }

        [TestMethod]
        public void SprawdźCzyJestAdresLinkuZObrazka()
        {
            var fabryka = new DemotivatorApi("http://demotywatory.pl/");

            var rezult = fabryka.GetMainPage().DemotivatorList;

            Assert.AreNotEqual(true, rezult.All(demot => string.IsNullOrEmpty(demot.Url)));

        }
    }
}
