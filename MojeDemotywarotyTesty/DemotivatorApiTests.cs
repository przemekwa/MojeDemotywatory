using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MojeDemotywatoryApi;
using System.Collections;
using System.Linq;

namespace MojeDemotywarotyTesty
{
    [TestClass]
    public class DemotivatorApiTests : DemotivatorApiBase
    {
        [TestMethod]
        public void Get_Demot_From_Main_Page()
        {
            var rezult = this.DemotivatorApi.GetMainPage();

            Assert.AreEqual(6, rezult.DemotivatorList.Count);
        }

        [TestMethod]
        public void Get_Demot_From_First_Page()
        {
            var rezult = this.DemotivatorApi.GetPage(1);

            Assert.AreEqual(6, rezult.DemotivatorList.Count);
        }

        //[TestMethod]
        //public void Get_Slide_Demot()
        //{
        //    var rezult =
        //        ApiTools.GetDemovivatorSlides(
        //            "http://demotywatory.pl/4405857/10-ciekawostek-o-ludzkim-organizmie-ktore-cie-zadziwia");

        //    Assert.AreEqual(9, rezult.ToList().Count);
        //}


        [TestMethod]
        public void Get_Range_Of_Pages()
        {
            var rezult = this.DemotivatorApi.GetPages(1, 2);

            Assert.AreEqual(2, rezult.Count());
        }

        [TestMethod]
        public void Get_Demotivator_Img_Url()
        {
            var rezult = this.DemotivatorApi.GetMainPage().DemotivatorList;

            Assert.AreNotEqual(true, rezult.All(demot => string.IsNullOrEmpty(demot.ImgUrl)));
        }

        [TestMethod]
        public void Get_Demotivator_Url()
        {
            var rezult = this.DemotivatorApi.GetMainPage().DemotivatorList;

            Assert.AreNotEqual(true, rezult.All(demot => string.IsNullOrEmpty(demot.Url)));
        }
    }
}
