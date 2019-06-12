using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryRepository.Models
{
    public enum ProductType
    { Bread, Cake, Pie, Pastry };
    public class Order
    {

        public int OrderId { get; set; }
        public List<ProductType> TypeOfProducts { get; set; }
        public string CustomerName { get; set; }
        public int BatchSize { get; set; }
        public decimal TotalCost { get; set; }

        public Order() {}
        public Order(int id)
        {
            OrderId = id;
        }
        public Order(List<ProductType> products,string customerName, int batchSize,int orderID, decimal totalCost)
        {
            TypeOfProducts = products;
            CustomerName = customerName;
            BatchSize = batchSize;
            OrderId = orderID;
            TotalCost = totalCost;
        }
    }
}
