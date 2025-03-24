using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestInTownProducts
{
    /// <summary>
    /// Enum to denote the product category.
    /// </summary>
    public enum ProductCategory
    {
        Electronics,
        Clothing,
        Books,
        HomeAppliances,
        Furniture,
        Sports,
        Beauty,
        Toys,
        Food,
        Health
    }

    /// <summary>
    /// Represents a product with various properties and methods to calculate price, check stock status, and manage the product lifecycle.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        public ProductCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the stock quantity of the product.
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer of the product.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the Stock Keeping Unit (SKU) of the product.
        /// </summary>
        public string SKU { get; set; }

        
        

        /// <summary>
        /// Gets or sets the discount percentage for the product.
        /// </summary>
        private decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets the date when the product was added to the inventory.
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// Gets or sets the date when the product details were last updated.
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets the weight of the product.
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// Gets or sets the dimensions of the product (length, width, height).
        /// </summary>
        public (decimal Length, decimal Width, decimal Height) Dimensions { get; set; }

        /// <summary>
        /// Gets or sets the average customer rating of the product.
        /// </summary>
        public decimal Rating { get; set; }

        /// <summary>
        /// Gets or sets the list of customer reviews for the product.
        /// </summary>
        public List<string> Reviews { get; set; } = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        public Product() { }

        /// <summary>
        /// Calculates the final price of the product based on base price, tax rate, and discount rate.
        /// </summary>
        /// <param name="basePrice">The base price of the product.</param>
        /// <param name="taxRate">The tax rate to be applied.</param>
        /// <param name="discountRate">The discount rate to be applied.</param>
        /// <returns>The final price of the product.</returns>
        public decimal CalculatePrice(decimal basePrice, decimal taxRate, decimal discountRate)
        {
            decimal taxAmount = basePrice * taxRate;
            decimal discountAmount = basePrice * discountRate;
            decimal finalPrice = basePrice + taxAmount - discountAmount;
            return finalPrice;
        }

        /// <summary>
        /// Checks if the product is in stock.
        /// </summary>
        /// <param name="stockQuantity">The stock quantity of the product.</param>
        /// <param name="productId">The ID of the product.</param>
        /// <param name="sku">The SKU of the product.</param>
        /// <param name="productName">The name of the product.</param>
        /// <returns><c>true</c> if the product is in stock; otherwise, <c>false</c>.</returns>
        public bool IsInStock(int stockQuantity, int productId, string sku, string productName)
        {
            if (stockQuantity > 0)
            {
                Console.WriteLine($"Product with ID {productId}, SKU {sku}, and Name {productName} is in stock.");
                return true;
            }
            else
            {
                Console.WriteLine($"Product with ID {productId}, SKU {sku}, and Name {productName} is out of stock.");
                return false;
            }
        }

        /// <summary>
        /// Checks if the product is having a discount.
        /// </summary>
        /// <param name="discountPercentage">The discount percentage of the product.</param>
        /// <param name="productId">The ID of the product.</param>
        /// <param name="sku">The SKU of the product.</param>
        /// <param name="productName">The name of the product.</param>
        /// <returns><c>true</c> if the product is having a discount; otherwise, <c>false</c>.</returns>
        public bool IsHavingDiscount(decimal discountPercentage, int productId, string sku, string productName)
        {
            if (discountPercentage > 0)
            {
                Console.WriteLine($"Product with ID {productId}, SKU {sku}, and Name {productName} is having a discount of {discountPercentage}%.");
                return true;
            }
            else
            {
                Console.WriteLine($"Product with ID {productId}, SKU {sku}, and Name {productName} is not having any discount.");
                return false;
            }
        }

        /// <summary>
        /// Updates the stock quantity of the product.
        /// </summary>
        /// <param name="newQuantity">The new stock quantity.</param>
        public void UpdateStockQuantity(int newQuantity)
        {
            StockQuantity = newQuantity;
            LastUpdated = DateTime.Now;
        }

        /// <summary>
        /// Adds a customer review to the product.
        /// </summary>
        /// <param name="review">The customer review.</param>
        public void AddReview(string review)
        {
            Reviews.Add(review);
            LastUpdated = DateTime.Now;
        }

        /// <summary>
        /// Calculates the shipping cost based on weight and dimensions.
        /// </summary>
        /// <returns>The calculated shipping cost.</returns>
        public decimal CalculateShippingCost()
        {
            // Example calculation based on weight and dimensions
            decimal volume = Dimensions.Length * Dimensions.Width * Dimensions.Height;
            decimal shippingCost = Weight * 0.5m + volume * 0.1m;
            return shippingCost;
        }

        /// <summary>
        /// Applies a discount to the product price.
        /// </summary>
        /// <param name="discountRate">The discount rate to be applied.</param>
        public void ApplyDiscount(decimal discountRate)
        {
            Price -= Price * discountRate;
            LastUpdated = DateTime.Now;
        }

        /// <summary>
        /// Establishes a connection to the SQL database.
        /// </summary>
        /// <returns>A <see cref="SqlConnection"/> object representing the connection to the database.</returns>
        private SqlConnection GetConnection()
        {
            string connectionString = "your_connection_string_here"; // Replace with your actual connection string
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Retrieves product data from the database by product ID.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>A <see cref="Product"/> object representing the retrieved product, or <c>null</c> if not found.</returns>
        public static Product GetProductById(int productId)
        {
            Product product = null;
            string query = "SELECT * FROM Products WHERE Id = @Id";

            using (SqlConnection connection = new Product().GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", productId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = new Product
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            //Category = reader["Category"].,
                            Price = (decimal)reader["Price"],
                            StockQuantity = (int)reader["StockQuantity"],
                            Manufacturer = reader["Manufacturer"].ToString(),
                            SKU = reader["SKU"].ToString()
                        };
                    }
                }
            }

            return product;
        }

        /// <summary>
        /// Saves the current product instance to the database.
        /// </summary>
        public void Save()
        {
            string query = "INSERT INTO Products (Name, Description, Category, Price, StockQuantity, Manufacturer, SKU, DateAdded, LastUpdated, Weight, Dimensions, Rating) " +
                           "VALUES (@Name, @Description, @Category, @Price, @StockQuantity, @Manufacturer, @SKU, @DateAdded, @LastUpdated, @Weight, @Dimensions, @Rating)";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Description", Description);
                command.Parameters.AddWithValue("@Category", Category);
                command.Parameters.AddWithValue("@Price", Price);
                command.Parameters.AddWithValue("@StockQuantity", StockQuantity);
                command.Parameters.AddWithValue("@Manufacturer", Manufacturer);
                command.Parameters.AddWithValue("@SKU", SKU);
                command.Parameters.AddWithValue("@DateAdded", DateAdded);
                command.Parameters.AddWithValue("@LastUpdated", LastUpdated);
                command.Parameters.AddWithValue("@Weight", Weight);
                command.Parameters.AddWithValue("@Dimensions", $"{Dimensions.Length},{Dimensions.Width},{Dimensions.Height}");
                command.Parameters.AddWithValue("@Rating", Rating);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the current product instance in the database.
        /// </summary>
        public void Update()
        {
            string query = "UPDATE Products SET Name = @Name, Description = @Description, Category = @Category, Price = @Price, " +
                           "StockQuantity = @StockQuantity, Manufacturer = @Manufacturer, SKU = @SKU, LastUpdated = @LastUpdated, " +
                           "Weight = @Weight, Dimensions = @Dimensions, Rating = @Rating WHERE Id = @Id";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Description", Description);
                command.Parameters.AddWithValue("@Category", Category);
                command.Parameters.AddWithValue("@Price", Price);
                command.Parameters.AddWithValue("@StockQuantity", StockQuantity);
                command.Parameters.AddWithValue("@Manufacturer", Manufacturer);
                command.Parameters.AddWithValue("@SKU", SKU);
                command.Parameters.AddWithValue("@LastUpdated", LastUpdated);
                command.Parameters.AddWithValue("@Weight", Weight);
                command.Parameters.AddWithValue("@Dimensions", $"{Dimensions.Length},{Dimensions.Width},{Dimensions.Height}");
                command.Parameters.AddWithValue("@Rating", Rating);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Deletes the current product instance from the database.
        /// </summary>
        public void Delete()
        {
            string query = "DELETE FROM Products WHERE Id = @Id";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", Id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A list of <see cref="Product"/> objects representing all products in the database.</returns>
        public static List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            string query = "SELECT * FROM Products";

            using (SqlConnection connection = new Product().GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                           // Category = reader["Category"].ToString(),
                            Price = (decimal)reader["Price"],
                            StockQuantity = (int)reader["StockQuantity"],
                            Manufacturer = reader["Manufacturer"].ToString(),
                            SKU = reader["SKU"].ToString()
                        };
                        products.Add(product);
                    }
                }
            }

            return products;
        }
    }
}
