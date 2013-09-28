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

        [Test]
        public void TestValidItemNameForItemId()
        {
            Assert.AreEqual("Deep Earth Mantle", _client.GetItem("76753").Name);
        }

        [Test]
        public void TestValidItemSetNameForItemSetId()
        {
            Assert.AreEqual("Deep Earth Vestments", _client.GetItemSet("1060").name);
        }

        [Test]
        public void TestValidItemsInItemSet()
        {
            List<int> items = GetSetItems("1060");
            
            foreach (int item in items)
            {
                Assert.AreEqual(1060, _client.GetItem(item.ToString()).ItemSet.id);
            }
        }

        [Test]
        public void TestSetItemsNotAuctionable()
        {
            List<int> items = GetSetItems("1060");

            foreach (int item in items)
            {
                Assert.AreEqual(false, _client.GetItem(item.ToString()).IsAuctionable);
            }
        }

        [Test]
        public void TestValidAllowableClassesForDeepEarthVestments()
        {
            List<int> items = GetSetItems("1060");

            foreach (int item in items)
            {
                List<int> allowableClasses = _client.GetItem(item.ToString()).AllowableClasses;
                Assert.AreEqual(false, allowableClasses.Except(new[] { 11 }).Any());
            }
        }

        private List<int> GetSetItems(string setId)
        {
            return _client.GetItemSet(setId).items;
        }
    }
}
