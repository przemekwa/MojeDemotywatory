﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MojeDemotywatoryDatabaseApi;
using MojeDemotywatoryDatabaseApi.Dto;

namespace MojeDemotywarotyTesty
{
    [TestClass]
    public class DemotvatorDataBasesApiTests
    {
        [TestMethod]
        public void IntegrationTest()
        {
            var db = new FavoritesDemotivatorApi();

            var favorite = db.Get();

            var favoriteses = favorite.ToList();

            Assert.IsNotNull(favoriteses);
        }

        [TestMethod]
        public void AddAndRemove()
        {
            var db = new FavoritesDemotivatorApi();

                db.Add(new Favorites
                {
                    ImgUrl = "http:",
                    Url = "http:",
                    User = new User
                    {
                        Name = "przemek"
                    }
                });

                var favorite = db.Get();

                var favoriteses = favorite.ToList();

                Assert.AreEqual(1, favoriteses.Count);


            db.Remove(favoriteses.Last().Id);


        }
    }
}
