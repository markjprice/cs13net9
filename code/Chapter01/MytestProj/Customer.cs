using BestInTownProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestInTownProducts
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public Cart ShoppingCart { get; set; } = new Cart();

        public void AddToCart(Product product, int quantity)
        {
            ShoppingCart.AddItem(product, quantity);
        }

        public void PlaceOrder()
        {
            Order order = new Order
            {
                CustomerId = Id,
                OrderDate = DateTime.Now,
                Items = new List<OrderItem>(ShoppingCart.Items)
            };
            Orders.Add(order);
            ShoppingCart.Clear();
        }
    }
}
