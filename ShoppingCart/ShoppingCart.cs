using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    /*
        Shopping Cart Class: Implement a ShoppingCart class that allows customers to add and remove products. 
        The cart should keep track of selected items and calculate the total price.
     */
    public class ShoppingCart
    {
        public List<Product> Cart { get; set; } = new List<Product>();

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        { 
            throw new NotImplementedException(); 
        }
        public void TotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}
