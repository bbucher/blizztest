using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using HttpUtils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NUnitTest1
{
    [TestFixture]
    public class TestFixture1
    {
        HttpClient client;
        
        [TestFixtureSetUp]
        public void init()
        {
            client = new HttpClient();
        }

        [Test]
        public void TestValidItemNameForItemId()
        {
            Assert.AreEqual("Deep Earth Mantle", client.GetItem("76753").name);
        }

        [Test]
        public void TestValidItemSetNameForItemSetId()
        {
            Assert.AreEqual("Deep Earth Vestments", client.GetItemSet("1060").name);
        }

        [Test]
        public void TestValidItemsInItemSet()
        {
            List<int> items = GetSetItems("1060");
            
            foreach (int item in items)
            {
                Assert.AreEqual(1060, client.GetItem(item.ToString()).itemSet.id);
            }
        }

        [Test]
        public void TestSetItemsNotAuctionable()
        {
            List<int> items = GetSetItems("1060");

            foreach (int item in items)
            {
                Assert.AreEqual(false, client.GetItem(item.ToString()).isAuctionable);
            }
        }

        [Test]
        public void TestValidAllowableClassesForDeepEarthVestments()
        {
            List<int> items = GetSetItems("1060");

            foreach (int item in items)
            {
                List<int> allowableClasses = client.GetItem(item.ToString()).allowableClasses;
                Assert.AreEqual(false, allowableClasses.Except<int>(new int[] { 11 }).Any<int>());
            }
        }

        private List<int> GetSetItems(string setId)
        {
            return client.GetItemSet(setId).items;
        }
    }
}
