using BestInTownProducts;
using System.Collections.Generic;

public class Wishlist
{
    public int CustomerId { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();

    public void AddToWishlist(Product product)
    {
        Products.Add(product);
    }

    public void RemoveFromWishlist(Product product)
    {
        Products.Remove(product);
    }
}
