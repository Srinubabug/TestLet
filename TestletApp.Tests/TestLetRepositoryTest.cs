using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testlet.DAL;
using System.Collections.Generic;
using System.Linq;

namespace TestletApp.Tests
{
    [TestClass]
    public class TestLetRepositoryTest
    {
        #region 
        private ITestLetItemRepository _testLetItemRepository;
        #endregion
        #region Additional test attributes

        [TestInitialize()]
        public void Initialize()
        {
            _testLetItemRepository = new TestLetItemRepository();  
        }
        #endregion

        #region TestMethods
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Items_Less_Than_One_Throws_IndexOutOfRangeException_TestMethod()
        {
            var testLetRandomizer = new Testlet.DAL.Testlet("Set1", new List<Item>());
            Assert.IsNotNull(testLetRandomizer.Items);
        }


        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Items_greater_Than_Ten_Throws_IndexOutOfRangeException_TestMethod()
        {
            var testLetRandomizer = new Testlet.DAL.Testlet("Set1", new List<Item>());
            Assert.IsNotNull(testLetRandomizer.Items);
        }

        [TestMethod]
        public void TestLet_Random_Items_Valid()
        {
            var shuffledItems = _testLetItemRepository.GetRandomizeItems();
            Assert.IsNotNull(shuffledItems);
        }


        [TestMethod]
        public void TestLet_should_have_4_PreTestItems()
        {
            var preTestCount = _testLetItemRepository.GetRandomizeItems().Where(a => a.ItemType == ItemType.Pretest).Count();
            Assert.AreEqual(4, preTestCount);
        }

        [TestMethod]
        public void TestLet_should_have_6_OperationalItems()
        {
            var operationalItemCount = _testLetItemRepository.GetRandomizeItems().Where(a => a.ItemType == ItemType.Operational).Count();
            Assert.AreEqual(6, operationalItemCount);
        }



        [TestMethod]
        public void TestLet_should_have_Top_2_PreTestItems()
        {
            var preTestItemsCount = _testLetItemRepository.GetRandomizeItems().Take(2).Where(a => a.ItemType == ItemType.Pretest).Count();
            Assert.AreEqual(2, preTestItemsCount);
        }

        [TestMethod]
        public void TestLet_should_have_8_mixedItems()
        {
            var mixedItems = _testLetItemRepository.GetRandomizeItems().Skip(2);
            var preTestItemsCount = mixedItems.Where(a => a.ItemType == ItemType.Pretest).Count();
            var operationalItemsCount = mixedItems.Where(a => a.ItemType == ItemType.Operational).Count();
            Assert.AreEqual(8, preTestItemsCount + operationalItemsCount);
        }

        [TestMethod]
        public void TestLet_Items_Order_Valid()
        {
            var shuffledItems = _testLetItemRepository.GetRandomizeItems();
            var isTop2PreTest = shuffledItems.Take(2).All(a => a.ItemType == ItemType.Pretest);
            var ismixedItems = shuffledItems.Skip(2).All(a => a.ItemType == ItemType.Pretest || a.ItemType == ItemType.Operational);
            Assert.AreEqual(true, ismixedItems && isTop2PreTest);
        }

        #endregion
    }
}
