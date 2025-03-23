using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestInTownProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nameofNamespace = typeof(Program).Namespace ?? "<null>";
            Console.WriteLine(nameofNamespace);

            // Create an instance of the Product class
            Product product = new Product
            {
                Id = 1,
                Name = "Sample Product",
                Description = "This is a sample product.",
                Category = "Sample Category"
            };

            // Calculate the price of the product
            decimal basePrice = 100.00m;
            decimal taxRate = 0.08m; // 8% tax
            decimal discountRate = 0.10m; // 10% discount
            decimal finalPrice = product.CalculatePrice(basePrice, taxRate, discountRate);

            // Print the calculated price to the console
            Console.WriteLine($"The final price of the product is: {finalPrice:C}");
        }
    }
}
