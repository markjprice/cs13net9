using System.Collections.Generic;

namespace BestInTownProducts
{
    public class Cart
    {
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public void AddItem(Product product, int quantity)
        {
            Items.Add(new OrderItem { Product = product, Quantity = quantity });
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
