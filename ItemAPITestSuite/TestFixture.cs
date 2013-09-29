using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using HttpUtils;

namespace NUnitTest1
{
    [TestFixture]
    public class TestFixture1
    {
        HttpClient _client;
        
        [TestFixtureSetUp]
        public void Init()
        {
            _client = new HttpClient();
        }

        /*
         * Using the WoW Item API, verify that the item name for a given item id is correct
         */
        [Test]
        public void TestValidItemNameForItemId()
        {
            Assert.AreEqual("Deep Earth Mantle", _client.GetItem("76753").Name);
        }

        /*
         * Using the WoW Item API, verify that the item set name for a given item set id is correct
         */
        [Test]
        public void TestValidItemSetNameForItemSetId()
        {
            Assert.AreEqual("Deep Earth Vestments", _client.GetItemSet("1060").name);
        }

        /*
         * Using the WoW Item API, verify that a given item set contains the expected items.
         */
        [Test]
        public void TestValidItemsInItemSet()
        {
            var expectedItems = new[] { 76749, 76750, 76751, 76752, 76753 };

            List<int> items = GetSetItems("1060");

            //assert that there are no differences between the set of expected values and the set of items returned from the API call
            Assert.AreEqual(false, items.Except(expectedItems).Any());

            //assert that each item in the set has an itemSet, and that the id = 1060
            foreach (var item in items)
            {
                Assert.AreEqual(1060, _client.GetItem(item.ToString()).ItemSet.id);
            }
        }

        /*
         * Using the WoW Item API, verify that individual items in the "Deep Earth Vestments" item set are not auctionable
         */
        [Test]
        public void TestSetItemsNotAuctionable()
        {
            var items = GetSetItems("1060");

            foreach (var item in items)
            {
                Assert.AreEqual(false, _client.GetItem(item.ToString()).IsAuctionable);
            }
        }

        /*
         * Using the WoW Item API, verify that druid is the only class that can wear items from the "Deep Earth Vestments" item set
         */
        [Test]
        public void TestValidAllowableClassesForDeepEarthVestments()
        {
            var items = GetSetItems("1060");

            foreach (var allowableClasses in items.Select(item => _client.GetItem(item.ToString()).AllowableClasses))
            {
                Assert.AreEqual(false, allowableClasses.Except(new[] { 11 }).Any());
            }
        }

        private List<int> GetSetItems(string setId)
        {
            return _client.GetItemSet(setId).items;
        }
    }
}
