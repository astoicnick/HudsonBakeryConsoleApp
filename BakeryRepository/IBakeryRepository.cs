using BakeryRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryRepository
{
    public interface IBakeryRepository
    {
        void AddOrder(Order orderToAdd);
        List<Order> GetOrders();
        void RemoveOrder(Order orderToRemove);
    }
}
