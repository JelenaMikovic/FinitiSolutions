using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using back.Repositories;
using back.Repositories.Interfaces;
using back;
using System.Threading.Tasks;

namespace FinitiTests
{
    [TestClass]
    public sealed class UserRepositoryTests
    {
        private IUserRepository _userRepository;
        private DatabaseContext _context;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new DatabaseContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _context.Users.AddRange(
                new User { Id = 100, Name = "test", Surname = "test", Role = UserRole.USER, Email = "test@example.com", Password = "1234" },
                new User { Id = 200, Email = "john@doe.com", Name = "test", Surname = "test", Role = UserRole.ADMIN, Password = "abcd" }
            );
            _context.SaveChanges();

            _userRepository = new UserRepository(_context);
        }

        [TestMethod]
        public async Task GetByEmailAndPassword_ReturnsUser_WhenCredentialsMatch()
        {
            var user = await _userRepository.GetByEmailAndPassword("test@example.com", "1234");

            Assert.IsNotNull(user);
            Assert.AreEqual(100, user.Id);
        }

        [TestMethod]
        public async Task GetByEmailAndPassword_ReturnsNull_WhenCredentialsDoNotMatch()
        {
            var user = await _userRepository.GetByEmailAndPassword("wrong@mail.com", "x");

            Assert.IsNull(user);
        }

        [TestMethod]
        public async Task GetUserById_ReturnsUser_WhenIdExists()
        {
            var user = await _userRepository.GetUserById(200);

            Assert.IsNotNull(user);
            Assert.AreEqual("john@doe.com", user.Email);
        }

        [TestMethod]
        public async Task GetUserById_ReturnsNull_WhenIdDoesNotExist()
        {
            var user = await _userRepository.GetUserById(999);

            Assert.IsNull(user);
        }
    }
}
