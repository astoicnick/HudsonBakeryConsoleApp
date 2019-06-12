using System;
using System.Collections.Generic;
using BakeryRepository.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BakeryTests
{
    [TestClass]
    public class HudsonBakeryTests
    {
        Order testOrder;
        List<Products> productList;
        BakeryRepository.Repository testRepo = new BakeryRepository.Repository();

        [TestInitialize]
        public void Arrange()
        {
            testOrder = new Order();
            productList = new List<Products> { Products.Pie, Products.Bread, Products.Cake };
            testOrder.TypeOfProducts = productList;
            testOrder.CustomerName = "Nick";
            testOrder.OrderId = 1;
            testOrder.BatchSize = 4;
        }

        [TestMethod]
        public void AddMethodTest()
        {
            //Act
            testRepo.AddOrder(testOrder);
            //Assert
            Assert.IsTrue(testRepo.GetOrders().Count == 1);
            Assert.IsNotNull(testRepo.GetOrders());
        }
        [TestMethod]
        public void GetMethodTest()
        {
            //Act
            List<Order> testOrderList = testRepo.GetOrders();
            //Assert
            Assert.IsNotNull(testOrderList);
        }
        [TestMethod]
        public void RemoveMethodTest()
        {
            //Act
            testRepo.AddOrder(testOrder);
            int countAfterAdd = testRepo.GetOrders().Count;
            testRepo.RemoveOrder(testOrder);
            int countAfterRemove = testRepo.GetOrders().Count;
            //Assert
            Assert.IsTrue(testRepo.GetOrders().Count == 0);
            Assert.IsTrue(countAfterAdd != countAfterRemove);
        }
    }
}
