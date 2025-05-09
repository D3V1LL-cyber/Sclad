using Склад.Models;
using System.ComponentModel.DataAnnotations;

namespace TestProject
{
    [TestClass]
    public sealed class ProductTests
    {
        [TestMethod]
        public void Product_EmptyTitle_ShouldBeInvalid()
        {
            // Arrange
            var product = new Product
            {
                Name = "",
                Price = 100.00m,
                Quantity = 50,
                CategoryId = 1,
                SupplierId = 1
            };

            // Act
            var context = new ValidationContext(product);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(product, context, results, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(r => r.ErrorMessage == "Введите название товара"));
        }
    }
}