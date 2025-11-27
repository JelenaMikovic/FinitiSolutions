using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using back.Controllers;
using back.Services.Interfaces;
using back.DTOs;
using back.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using back;

namespace FinitiTests
{
    [TestClass]
    public class UserControllerTests
    {
        private Mock<IUserService> _userServiceMock;
        private UserController _controller;
        private Mock<IResponseCookies> _cookiesMock;

        private User _loggedUser;

        [TestInitialize]
        public void Setup()
        {
            _userServiceMock = new Mock<IUserService>();
            _cookiesMock = new Mock<IResponseCookies>();

            _loggedUser = new User
            {
                Id = 1,
                Name = "Test",
                Surname = "User",
                Email = "test@example.com",
                Role = UserRole.USER,
                Password = "1234"
            };

            var httpContextMock = new DefaultHttpContext();
            httpContextMock.Items["loggedUser"] = _loggedUser;

            var responseMock = new Mock<HttpResponse>();
            responseMock.Setup(r => r.Cookies).Returns(_cookiesMock.Object);

            var contextMock = new Mock<HttpContext>();
            contextMock.Setup(c => c.Response).Returns(responseMock.Object);
            contextMock.Setup(c => c.Items).Returns(httpContextMock.Items);

            _controller = new UserController(_userServiceMock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = contextMock.Object
                }
            };
        }

        [TestMethod]
        public async Task Login_ShouldReturnOkWithUserDTO_WhenCredentialsAreValid()
        {
            var credentials = new LogInDto { Email = _loggedUser.Email, Password = _loggedUser.Password };

            _userServiceMock.Setup(s => s.GetByEmailAndPassword(credentials.Email, credentials.Password))
                            .ReturnsAsync(_loggedUser);

            var result = await _controller.Login(credentials);

            _cookiesMock.Verify(c => c.Append(
                "jwtToken",
                It.IsAny<string>(),
                It.IsAny<CookieOptions>()),
                Times.Once);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(UserDTO));
        }

        [TestMethod]
        public async Task Login_ShouldReturnBadRequest_WhenCredentialsAreInvalid()
        {
            var credentials = new LogInDto { Email = "wrong@example.com", Password = "x" };
            _userServiceMock.Setup(s => s.GetByEmailAndPassword(credentials.Email, credentials.Password))
                            .ReturnsAsync((User)null);

            var result = await _controller.Login(credentials);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badResult = result as BadRequestObjectResult;
            Assert.AreEqual("Invalid credentials", badResult.Value);
        }

        [TestMethod]
        public async Task Login_ShouldReturnStatus500_WhenServiceThrowsException()
        {
            var credentials = new LogInDto { Email = _loggedUser.Email, Password = _loggedUser.Password };
            _userServiceMock.Setup(s => s.GetByEmailAndPassword(credentials.Email, credentials.Password))
                            .ThrowsAsync(new System.Exception("Database failure"));

            var result = await _controller.Login(credentials);

            Assert.IsInstanceOfType(result, typeof(ObjectResult));
            var objResult = result as ObjectResult;
            Assert.AreEqual(500, objResult.StatusCode);
            Assert.IsTrue(objResult.Value.ToString().Contains("Internal Server Error"));
        }

        [TestMethod]
        public void Logout_ShouldAppendExpiredCookie()
        {
            var result = _controller.Logout();

            _cookiesMock.Verify(c => c.Append(
                "jwtToken",
                "",
                It.Is<CookieOptions>(opt => opt.Expires < System.DateTime.UtcNow)
            ), Times.Once);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
