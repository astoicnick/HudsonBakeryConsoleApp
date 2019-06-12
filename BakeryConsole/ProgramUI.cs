using BakeryRepository;
using BakeryRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryConsole
{
    public class ProgramUI
    {
        private readonly IBakeryRepository _repo;
        private int idCounter = 0;
        public ProgramUI(IBakeryRepository repo)
        {
            _repo = repo;
        }
        public void Run()
        {
            while (Menu())
            {
            }
        }
        private bool Menu()
        {
            Console.WriteLine("Hi! Welcome to Hudson's Bakery! What would you like to do?\n" +
                "1. Place an Order\n" +
                "2. See current Orders\n" +
                "3. Cancel(remove) an order\n" +
                "4. Exit\n");
            string userKey = Console.ReadLine();
            switch (userKey)
            {
                case "1":
                    Order orderToAdd = GetUserOrder();
                    int initialCount = _repo.GetOrders().Count;
                    _repo.AddOrder(orderToAdd);
                    int postCount = _repo.GetOrders().Count;
                    if (initialCount < postCount)
                    {
                        Console.WriteLine("Awesome! Order went through.");
                    }
                    else
                    {
                        Console.WriteLine("Please try entering your order again");
                    }
                    break;
                case "2":
                    List<Order> ordersToShow = _repo.GetOrders();
                    foreach (Order order in ordersToShow)
                    {
                        Console.WriteLine($"Order ID: {order.OrderId}");
                        List<string> productsToWrite = order.TypeOfProducts.ConvertAll(f => f.ToString());
                        Console.WriteLine($"Product(s): ");
                        foreach (string product in productsToWrite)
                        {
                            Console.WriteLine($"·{product}");
                        }
                        Console.WriteLine($"Customer Name: {order.CustomerName}");
                        Console.WriteLine($"Batch Size: {order.BatchSize}");
                        string costFormatted = order.TotalCost.ToString("C2");
                        Console.WriteLine($"Cost: {costFormatted}");
                        Console.WriteLine("---------------------------");

                    }
                    break;
                case "3":
                    Console.WriteLine("What's the ID associated with the order?");
                    int idToSearch = int.Parse(Console.ReadLine());
                    Order orderToRemove = new Order(idToSearch);
                    _repo.RemoveOrder(orderToRemove);
                    break;
                case "4":
                    return false;
                    break;
                default:
                    Console.WriteLine("Please try that again.");
                    break;
            }
            return true;
        }
        Order GetUserOrder()
        {
            Order userOrder = new Order();
            List<ProductType> productList = new List<ProductType>();
            userOrder.TypeOfProducts = productList;
            bool whileTracker = true;
            Console.WriteLine("What Product(s) would you like? Press enter if you are done" +
                "adding products to your order.");
            //Add Products
            while (whileTracker == true)
            {
                Console.WriteLine("Products// 1. Cake 2. Pie 3. Pastry 4. Bread");
                string userKey = Console.ReadLine();
                if (userKey == "\n")
                {
                    whileTracker = false;
                }
                else
                {
                    switch (userKey)
                    {
                        case "1":
                            productList.Add(ProductType.Cake);
                            break;
                        case "2":
                            productList.Add(ProductType.Pie);
                            break;
                        case "3":
                            productList.Add(ProductType.Pastry);
                            break;
                        case "4":
                            productList.Add(ProductType.Bread);
                            break;
                    }
                    whileTracker = true;
                }
            }
            //Add OrderID
            userOrder.OrderId = idCounter;
            idCounter++;
            //Get Name
            Console.WriteLine("What is your full name?");
            string name = Console.ReadLine();
            userOrder.CustomerName = name;
            //Add batch size
            Console.WriteLine("Finally, how many of each product would you like(batch size)?");
            //Return Order
            return userOrder;
        }
    }
}
