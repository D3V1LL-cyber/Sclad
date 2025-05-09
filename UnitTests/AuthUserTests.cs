using Склад.Models.Auth;

namespace TestProject
{
    [TestClass]
    public sealed class AuthUserTests
    {
        [TestMethod]
        public void AuthUser_ValidProperties_ShouldSetValuesCorrectly()
        {
            var user = new AuthUser
            {
                Id = 1,
                Email = "test@gmail.com",
                Password = "password",
                Role = "Admin"
            };

            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("test@gmail.com", user.Email);
            Assert.AreEqual("Admin", user.Role);
        }
    }
}