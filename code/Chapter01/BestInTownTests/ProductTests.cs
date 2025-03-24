using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestInTownProducts;

namespace BestInTownProducts.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void CalculatePrice_ShouldReturnCorrectFinalPrice()
        {
            // Arrange
            var product = new Product();
            decimal basePrice = 100.00m;
            decimal taxRate = 0.08m; // 8% tax
            decimal discountRate = 0.10m; // 10% discount

            // Act
            decimal finalPrice = product.CalculatePrice(basePrice, taxRate, discountRate);

            // Assert
            Assert.AreEqual(98.00m, finalPrice);
        }

        [TestMethod]
        public void IsInStock_ShouldReturnTrue_WhenStockQuantityIsGreaterThanZero()
        {
            // Arrange
            var product = new Product { StockQuantity = 10 };

            // Act
            bool isInStock = product.IsInStock(product.StockQuantity, product.Id, product.SKU, product.Name);

            // Assert
            Assert.IsTrue(isInStock);
        }

        [TestMethod]
        public void IsInStock_ShouldReturnFalse_WhenStockQuantityIsZero()
        {
            // Arrange
            var product = new Product { StockQuantity = 0 };

            // Act
            bool isInStock = product.IsInStock(product.StockQuantity, product.Id, product.SKU, product.Name);

            // Assert
            Assert.IsFalse(isInStock);
        }

        [TestMethod]
        public void IsHavingDiscount_ShouldReturnTrue_WhenDiscountPercentageIsGreaterThanZero()
        {
            // Arrange
            var product = new Product();
            decimal discountPercentage = 0.10m; // 10% discount

            // Act
            bool isHavingDiscount = product.IsHavingDiscount(discountPercentage, product.Id, product.SKU, product.Name);

            // Assert
            Assert.IsTrue(isHavingDiscount);
        }

        [TestMethod]
        public void IsHavingDiscount_ShouldReturnFalse_WhenDiscountPercentageIsZero()
        {
            // Arrange
            var product = new Product();
            decimal discountPercentage = 0.00m; // 0% discount

            // Act
            bool isHavingDiscount = product.IsHavingDiscount(discountPercentage, product.Id, product.SKU, product.Name);

            // Assert
            Assert.IsFalse(isHavingDiscount);
        }

        [TestMethod]
        public void UpdateStockQuantity_ShouldUpdateStockQuantity()
        {
            // Arrange
            var product = new Product { StockQuantity = 10 };
            int newQuantity = 20;

            // Act
            product.UpdateStockQuantity(newQuantity);

            // Assert
            Assert.AreEqual(newQuantity, product.StockQuantity);
        }

        [TestMethod]
        public void AddReview_ShouldAddReviewToList()
        {
            // Arrange
            var product = new Product();
            string review = "Great product!";

            // Act
            product.AddReview(review);

            // Assert
            Assert.AreEqual(1, product.Reviews.Count);
            Assert.AreEqual(review, product.Reviews[0]);
        }

        [TestMethod]
        public void CalculateShippingCost_ShouldReturnCorrectShippingCost()
        {
            // Arrange
            var product = new Product
            {
                Weight = 10.0m,
                Dimensions = (2.0m, 3.0m, 4.0m)
            };

            // Act
            decimal shippingCost = product.CalculateShippingCost();

            // Assert
            Assert.AreEqual(11.2m, shippingCost);
        }

        [TestMethod]
        public void ApplyDiscount_ShouldReducePriceByDiscountRate()
        {
            // Arrange
            var product = new Product();
            decimal initialPrice = 100.00m;
            decimal discountRate = 0.10m; // 10% discount
            product.GetType().GetProperty("Price").SetValue(product, initialPrice);

            // Act
            product.ApplyDiscount(discountRate);

            // Assert
            decimal expectedPrice = initialPrice - (initialPrice * discountRate);
            decimal actualPrice = (decimal)product.GetType().GetProperty("Price").GetValue(product);
            Assert.AreEqual(expectedPrice, actualPrice);
        }
    }
}
