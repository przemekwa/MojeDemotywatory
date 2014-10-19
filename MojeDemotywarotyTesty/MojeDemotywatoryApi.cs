using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MojeDemotywatoryApi;
using System.Collections;

namespace MojeDemotywarotyTesty
{
    [TestClass]
    public class MojeDemotywatoryApi
    {
        [TestMethod]
        public void MojeDemotywatoryApi_OgólneDziałanie()
        {
            var fabryka = new Fabryka("http://demotywatory.pl/");

            var rezult = fabryka.PobierzDemotywatory();

            Assert.AreEqual(rezult.Count, 10);
        }
    }
}
