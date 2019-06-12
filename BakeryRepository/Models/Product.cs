using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryRepository.Models
{
    public class Product
    {
        public decimal Price { get; set; }
    public Product() { }

    public Product(decimal price)
    {
        Price = price;
    }
    }
   
}
