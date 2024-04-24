using Moq;
using FlowerLovers.Core.Contracts.ApplicationServices;

namespace ArticleManagementTests
{
    [TestFixture]
    public class ApplicationNameTests
    {
        [Test]
        public async Task UserFullName_SuccessfullyCreatingFullNames()
        {
            var applicationUserService = new Mock<IApplicationServiceUser>();

            var userId = "a2c10gb6-c198-1199-a7ft-b7p3f139c082";

            applicationUserService.Setup(a => a.UserFullNameAsync(userId))
                           .Returns(Task.FromResult("Magdalena Vladimirova"));

            var result = await applicationUserService.Object.UserFullNameAsync(userId);

            Assert.That(result, Is.EqualTo("Magdalena Vladimirova"));
        }
    }
}
