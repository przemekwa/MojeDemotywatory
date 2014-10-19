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
            var fabryka = new Fabryka("http://demotywatory.pl/");

            var rezult = fabryka.PobierzDemotywatory();

            Assert.AreEqual(rezult.Count, 10);
        }

        [TestMethod]
        public void SprawdźCzyJestAdresObrazka()
        {
            var fabryka = new Fabryka("http://demotywatory.pl/");

            var rezult = fabryka.PobierzDemotywatory();

            Assert.AreNotEqual(true, rezult.All(demot => string.IsNullOrEmpty(demot.ObrazekUrl)));
            
        }


    }
}
