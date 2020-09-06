using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using xamarinExample.Models;

namespace xamarinExample.Test
{
    public class RepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UpdateBunchList_CalledWithCorrectJson_BunchListIsUpdatedCorrectly()
        {
            var json = "[ { \"id\": \"a\", \"name\": \"a_name\"}, " +
                "{ \"id\": \"b\", \"name\": \"b_name\"}, " +
                "{ \"id\": \"c\", \"name\": \"c_name\"} ]";
            var repository = new Repository();
            repository.UpdateBunchList(json);
            var isFoundA = false;
            var isFoundB = false;
            var isFoundC = false;
            IList<Bunch> bunchList = repository.BunchList;
            foreach (var bunch in bunchList)
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
            Assert.AreEqual(bunchList.Count, 3);
        }
    }
}
