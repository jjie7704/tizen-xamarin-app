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
                if (bunch.Id.Equals("a") && bunch.Name.Equals("a_name"))
                    isFoundA = true;
                else if (bunch.Id.Equals("b") && bunch.Name.Equals("b_name"))
                    isFoundB = true;
                else if (bunch.Id.Equals("c") && bunch.Name.Equals("c_name"))
                    isFoundC = true;
            }

            Assert.IsTrue(isFoundA);
            Assert.IsTrue(isFoundB);
            Assert.IsTrue(isFoundC);
            Assert.AreEqual(bunchList.Count, 3);

            var json2 = "[ { \"id\": \"d\", \"name\": \"d_name\"}, " +
                "{ \"id\": \"c\", \"name\": \"c_name\"} ]";
            repository.UpdateBunchList(json2);
            isFoundA = false;
            isFoundB = false;
            isFoundC = false;
            var isFoundD = false;
            bunchList = repository.BunchList;
            foreach (var bunch in bunchList)
            {
                Console.WriteLine($"Bunch! {bunch.Id}, {bunch.Name}");
                if (bunch.Id.Equals("a") && bunch.Name.Equals("a_name"))
                    isFoundA = true;
                else if (bunch.Id.Equals("b") && bunch.Name.Equals("b_name"))
                    isFoundB = true;
                else if (bunch.Id.Equals("c") && bunch.Name.Equals("c_name"))
                    isFoundC = true;
                else if (bunch.Id.Equals("d") && bunch.Name.Equals("d_name"))
                    isFoundD = true;
            }

            Assert.IsFalse(isFoundA);
            Assert.IsFalse(isFoundB);
            Assert.IsTrue(isFoundC);
            Assert.IsTrue(isFoundD);
            Assert.AreEqual(bunchList.Count, 2);
        }
    }
}
