using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using xamarinExample.Models;

namespace xamarinExample.Test
{
    public class RepositoryTests
    {
        string testJson1 = @"{
    ""bunchList"": 
    [
        { ""id"": ""bunch_a"", ""name"": ""a_name""},
        { ""id"": ""bunch_b"", ""name"": ""b_name""},
        { ""id"": ""bunch_c"", ""name"": ""c_name""}
    ]
}";

        string testJson2 = @"{
    ""bunchs"": 
    [
        {
            ""id"": ""bunch_a"",
            ""items"": [
                {
                    ""id"": ""mango"",
                    ""content"": ""mango_content"",
                    ""isActive"": false
                }
            ]
        }
    ]
}";

        string testJson3 = @"{
    ""bunchList"": 
    [
        { ""id"": ""bunch_a"", ""name"": ""a_name""},
        { ""id"": ""bunch_d"", ""name"": ""d_name""}
    ],
    ""bunchs"": 
    [
        {
            ""id"": ""bunch_a"",
            ""items"": [
                {
                    ""id"": ""orange"",
                    ""content"": ""orange_content"",
                    ""isActive"": true
                },
                {
                    ""id"": ""banana"",
                    ""content"": ""banana_content"",
                    ""isActive"": false
                }
            ]
        }
    ]
}";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Update_CalledWithCorrectJson_BunchListIsUpdatedCorrectly()
        {
            var repository = new Repository();
            repository.Update(testJson1);
            var isFoundA = false;
            var isFoundB = false;
            var isFoundC = false;
            IList<Bunch> updatedBunchList = repository.BunchList;
            foreach (var bunch in updatedBunchList)
            {
                Console.WriteLine($"Bunch! {bunch.Id}, {bunch.Name}");
                if (bunch.Id.Equals("bunch_a") && bunch.Name.Equals("a_name"))
                    isFoundA = true;
                else if (bunch.Id.Equals("bunch_b") && bunch.Name.Equals("b_name"))
                    isFoundB = true;
                else if (bunch.Id.Equals("bunch_c") && bunch.Name.Equals("c_name"))
                    isFoundC = true;
            }

            Assert.IsTrue(isFoundA);
            Assert.IsTrue(isFoundB);
            Assert.IsTrue(isFoundC);
            Assert.AreEqual(updatedBunchList.Count, 3);

            repository.Update(testJson3);
            isFoundA = false;
            isFoundB = false;
            isFoundC = false;
            var isFoundD = false;
            updatedBunchList = repository.BunchList;
            foreach (var bunch in updatedBunchList)
            {
                Console.WriteLine($"Bunch! {bunch.Id}, {bunch.Name}");
                if (bunch.Id.Equals("bunch_a") && bunch.Name.Equals("a_name"))
                    isFoundA = true;
                else if (bunch.Id.Equals("bunch_b") && bunch.Name.Equals("b_name"))
                    isFoundB = true;
                else if (bunch.Id.Equals("bunch_c") && bunch.Name.Equals("c_name"))
                    isFoundC = true;
                else if (bunch.Id.Equals("bunch_d") && bunch.Name.Equals("d_name"))
                    isFoundD = true;
            }

            Assert.IsTrue(isFoundA);
            Assert.IsFalse(isFoundB);
            Assert.IsFalse(isFoundC);
            Assert.IsTrue(isFoundD);
            Assert.AreEqual(updatedBunchList.Count, 2);
        }

        [Test]
        public void Update_CalledWithCorrectJson_BunchItemsIsUpdatedCorrectly()
        {
            var repository = new Repository();
            repository.Update(testJson1);
            var updatedBunchList = repository.BunchList;
            Bunch targetBunch = null;
            foreach (var bunch in updatedBunchList)
            {
                if (bunch.Id.Equals("bunch_a"))
                    targetBunch = bunch;
            }
            Assert.IsNotNull(targetBunch);

            repository.Update(testJson2);

            var bunchItemList = targetBunch.ItemList;
            BunchItem mangoItem = null;
            foreach (var bunchItem in bunchItemList)
            {
                Console.WriteLine($"bunchItem {bunchItem.Id}, {bunchItem.Content}, {bunchItem.IsActive}");
                if (bunchItem.Id.Equals("mango"))
                    mangoItem = bunchItem;
            }

            Assert.IsNotNull(mangoItem);
            Assert.IsFalse(mangoItem.IsActive);
            Assert.AreEqual(mangoItem.Content, "mango_content");

            repository.Update(testJson3);

            bunchItemList = targetBunch.ItemList;
            mangoItem = null;
            BunchItem orangeItem = null;
            BunchItem bananaItem = null;
            foreach (var bunchItem in bunchItemList)
            {
                Console.WriteLine($"bunchItem {bunchItem.Id}, {bunchItem.Content}, {bunchItem.IsActive}");
                if (bunchItem.Id.Equals("mango"))
                    mangoItem = bunchItem;
                else if (bunchItem.Id.Equals("orange"))
                    orangeItem = bunchItem;
                else if (bunchItem.Id.Equals("banana"))
                    bananaItem = bunchItem;
            }

            Assert.IsNull(mangoItem);

            Assert.IsNotNull(bananaItem);
            Assert.IsFalse(bananaItem.IsActive);
            Assert.AreEqual(bananaItem.Content, "banana_content");

            Assert.IsNotNull(orangeItem);
            Assert.IsTrue(orangeItem.IsActive);
            Assert.AreEqual(orangeItem.Content, "orange_content");
        }

    }
}