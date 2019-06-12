using BakeryRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryRepository
{
    public class Repository : IBakeryRepository
    {
        private List<Order> _orders = new List<Order>();
        public void AddOrder(Order orderToAdd)
        {
            orderToAdd.TotalCost = CalculateCost(orderToAdd);
            _orders.Add(orderToAdd);
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }

        public void RemoveOrder(Order orderToRemove)
        {
            foreach (Order order in _orders.ToList())
            {
                if (orderToRemove.OrderId == order.OrderId)
                {
                    _orders.Remove(order);
                }
            }
        }
        public void AddInitialContent()
        {
            Order testOrder = new Order();
            List<ProductType> productList = new List<ProductType> { ProductType.Pie, ProductType.Bread, ProductType.Cake };
            testOrder.TypeOfProducts = productList;
            testOrder.CustomerName = "Nick";
            testOrder.OrderId = 1;
            testOrder.BatchSize = 4;
            AddOrder(testOrder);
        }
        private decimal CalculateCost(Order orderCalc)
        {
            decimal batchSizeTemp = orderCalc.BatchSize;
            decimal cost = 100m;
            foreach (ProductType products in orderCalc.TypeOfProducts)
            {
                switch (products.ToString())
                {
                    case "Cake":
                        cost += 2000m * batchSizeTemp;
                        break;
                    case "Pie":
                        cost += 851.5m * batchSizeTemp;
                        break;
                    case "Pastry":
                        cost += 200.10m * batchSizeTemp;
                        break;
                    case "Bread":
                        cost += 500.01m * batchSizeTemp;
                        break;
                }
            }
            return cost;
        }

    }
}
