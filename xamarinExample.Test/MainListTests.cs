using NUnit.Framework;
using System;
using xamarinExample.Models;

namespace xamarinExample.test
{
    public class MainListTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SyncBunchListFromJson_CalledWithCorrectJson_UpdatedCorrectly()
        {
            var json = "[ { \"id\": \"a\", \"name\": \"a_name\"}, " +
                "{ \"id\": \"b\", \"name\": \"b_name\"}, " +
                "{ \"id\": \"c\", \"name\": \"c_name\"} ]";
            var mainlist = new MainList();
            mainlist.SyncBunchListFromJson(json);
            var isFoundA = false;
            var isFoundB = false;
            var isFoundC = false;
            foreach (var bunch in mainlist.BunchList)
            {
                Console.WriteLine($"Bunch! {bunch.Id}, {bunch.Name}");
                if (bunch.Id == "a" && bunch.Name == "a_name")
                    isFoundA = true;
                else if (bunch.Id == "b" && bunch.Name == "b_name")
                    isFoundB = true;
                else if (bunch.Id == "c" && bunch.Name == "c_name")
                    isFoundC = true;
            }

            Assert.IsTrue(isFoundA);
            Assert.IsTrue(isFoundB);
            Assert.IsTrue(isFoundC);
            Assert.AreEqual(mainlist.BunchList.Count, 3);
        }
    }
}