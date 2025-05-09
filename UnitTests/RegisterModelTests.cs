using Склад.Models.Auth;
using System.ComponentModel.DataAnnotations;

namespace TestProject
{
    [TestClass]
    public sealed class RegisterModelTests
    {
        [TestMethod]
        public void RegisterModel_MismatchedPasswords_ShouldBeInvalid()
        {
            // Arrange
            var model = new RegisterModel
            {
                Email = "test@gmail.com",
                Password = "123",
                ConfirmPassword = "456"
            };

            // Act
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(r => r.ErrorMessage == "Подтверждение введено неверно"));
        }
    }
}
