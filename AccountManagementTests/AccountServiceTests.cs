using FlowerLovers.Core.Contracts.AccountService;
using FlowerLovers.Core.Contracts.ApplicationServices;
using FlowerLovers.Core.Services.AccountServices;
using FlowerLovers.Data.Data;
using FlowerLovers.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AccountManagementTests
{
    [TestFixture]
    public class AccountServiceTests
    {
        [Test]
        public async Task CreateUserAccount_SuccessfullyCreatesUserAccount()
        {

            var applicationUserService = new Mock<IAccountService>();

            var testUserId = "58016067-ce93-4560-a4c7-2970ce0ccc92";

            // Act
            var result = await applicationUserService.Object.CreateUserAccount(testUserId);

            // Assert
            // Verify that a user account was created
            Assert.IsNotNull(result);

            // Verify that the user account has the expected properties
            Assert.That(result.Username, Is.EqualTo("KolioKolev"));
            Assert.That(result.ImageUrl, Is.EqualTo("Content/Images/default-user.png"));
            Assert.That(result.Biography, Is.EqualTo(""));
            Assert.IsNotNull(result.CreationDate);
        }
    }
}
