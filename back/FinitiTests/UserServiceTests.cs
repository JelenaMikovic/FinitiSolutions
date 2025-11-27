using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using back.Services;
using back.Services.Interfaces;
using back.Repositories.Interfaces;
using back.Model;
using System.Threading.Tasks;
using back;

namespace FinitiTests
{
    [TestClass]
    public sealed class UserServiceTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private IUserService _userService;

        [TestInitialize]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [TestMethod]
        public async Task GetByEmailAndPassword_ShouldReturnUser_WhenCredentialsMatch()
        {
            var expectedUser = new User { Id = 100, Name = "test", Surname = "test", Role = UserRole.USER, Email = "test@example.com", Password = "1234" };
            _userRepositoryMock
                .Setup(repo => repo.GetByEmailAndPassword("test@example.com", "1234"))
                .ReturnsAsync(expectedUser);

            var result = await _userService.GetByEmailAndPassword("test@example.com", "1234");

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser.Id, result.Id);
            Assert.AreEqual(expectedUser.Email, result.Email);

            _userRepositoryMock.Verify(repo => repo.GetByEmailAndPassword("test@example.com", "1234"), Times.Once);
        }

        [TestMethod]
        public async Task GetByEmailAndPassword_ShouldReturnNull_WhenCredentialsDoNotMatch()
        {
            _userRepositoryMock
                .Setup(repo => repo.GetByEmailAndPassword("wrong@example.com", "x"))
                .ReturnsAsync((User)null);

            var result = await _userService.GetByEmailAndPassword("wrong@example.com", "x");

            Assert.IsNull(result);

            _userRepositoryMock.Verify(repo => repo.GetByEmailAndPassword("wrong@example.com", "x"), Times.Once);
        }
    }
}
