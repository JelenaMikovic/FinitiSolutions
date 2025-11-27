using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using back.Controllers;
using back.Services.Interfaces;
using back.DTOs;
using back.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using back;

namespace FinitiTests
{
    [TestClass]
    public class TermControllerTests
    {
        private Mock<ITermService> _termServiceMock;
        private TermController _controller;

        private User _adminUser;
        private User _normalUser;

        [TestInitialize]
        public void Setup()
        {
            _termServiceMock = new Mock<ITermService>();

            _adminUser = new User
            {
                Id = 100,
                Name = "Admin",
                Surname = "User",
                Email = "admin@example.com",
                Role = UserRole.ADMIN
            };

            _normalUser = new User
            {
                Id = 200,
                Name = "Normal",
                Surname = "User",
                Email = "user@example.com",
                Role = UserRole.USER
            };

            var httpContext = new DefaultHttpContext();
            _controller = new TermController(_termServiceMock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext
                }
            };
        }

        [TestMethod]
        public async Task GetPublishedTerms_ShouldReturnOk_WithTerms()
        {
            var terms = new List<TermDTO> { new TermDTO { Id = 100, Name = "Test Term" } };
            _termServiceMock.Setup(s => s.GetPublishedTerms()).ReturnsAsync(terms);
            var result = await _controller.GetPublishedTerms();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            CollectionAssert.AreEqual(terms, okResult.Value as List<TermDTO>);
        }

        [TestMethod]
        public async Task GetPublishedTerms_ShouldReturnBadRequest_OnException()
        {
            _termServiceMock.Setup(s => s.GetPublishedTerms()).ThrowsAsync(new Exception("Service error"));
            var result = await _controller.GetPublishedTerms();

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task GetDraftTerms_ShouldReturnUnauthorized_ForNormalUser()
        {
            _controller.HttpContext.Items["loggedUser"] = _normalUser;
            var result = await _controller.GetDraftTerms();

            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
        }

        [TestMethod]
        public async Task GetDraftTerms_ShouldReturnOk_ForAdmin()
        {
            _controller.HttpContext.Items["loggedUser"] = _adminUser;
            var terms = new List<TermDTO> { new TermDTO { Id = 100, Name = "Draft Term" } };
            _termServiceMock.Setup(s => s.GetDraftTerms(_adminUser.Id)).ReturnsAsync(terms);
            var result = await _controller.GetDraftTerms();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            CollectionAssert.AreEqual(terms, okResult.Value as List<TermDTO>);
        }

        [TestMethod]
        public async Task GetArchivedTerms_ShouldReturnUnauthorized_ForNormalUser()
        {
            _controller.HttpContext.Items["loggedUser"] = _normalUser;
            var result = await _controller.GetArchivedTerms();

            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
        }

        [TestMethod]
        public async Task GetArchivedTerms_ShouldReturnOk_ForAdmin()
        {
            _controller.HttpContext.Items["loggedUser"] = _adminUser;
            var terms = new List<TermDTO> { new TermDTO { Id = 100, Name = "Archived Term" } };
            _termServiceMock.Setup(s => s.GetArchivedTerms()).ReturnsAsync(terms);
            var result = await _controller.GetArchivedTerms();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task CreateTerm_ShouldReturnUnauthorized_ForNormalUser()
        {
            _controller.HttpContext.Items["loggedUser"] = _normalUser;
            var dto = new CreateTermDTO { Name = "New Term", Definition = "Definition..." };
            var result = await _controller.CreateTerm(dto);

            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
        }

        [TestMethod]
        public async Task CreateTerm_ShouldReturnOk_ForAdmin()
        {
            _controller.HttpContext.Items["loggedUser"] = _adminUser;
            var dto = new CreateTermDTO { Name = "New Term", Definition = "Definition..." };
            _termServiceMock.Setup(s => s.CreateNewTerm(dto, _adminUser.Id)).Returns(Task.CompletedTask);
            var result = await _controller.CreateTerm(dto);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public async Task ArchiveTerm_ShouldReturnUnauthorized_ForNormalUser()
        {
            _controller.HttpContext.Items["loggedUser"] = _normalUser;
            var result = await _controller.ArchiveTerm(1);

            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
        }

        [TestMethod]
        public async Task ArchiveTerm_ShouldReturnOk_ForAdmin()
        {
            _controller.HttpContext.Items["loggedUser"] = _adminUser;
            _termServiceMock.Setup(s => s.ArchiveTerm(1, _adminUser.Id)).Returns(Task.CompletedTask);
            var result = await _controller.ArchiveTerm(1);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public async Task PublishTerm_ShouldReturnUnauthorized_ForNormalUser()
        {
            _controller.HttpContext.Items["loggedUser"] = _normalUser;
            var result = await _controller.PublishTerm(1);

            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
        }

        [TestMethod]
        public async Task PublishTerm_ShouldReturnOk_ForAdmin()
        {
            _controller.HttpContext.Items["loggedUser"] = _adminUser;
            _termServiceMock.Setup(s => s.PublishTerm(1, _adminUser.Id)).Returns(Task.CompletedTask);
            var result = await _controller.PublishTerm(1);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public async Task DeleteDraft_ShouldReturnUnauthorized_ForNormalUser()
        {
            _controller.HttpContext.Items["loggedUser"] = _normalUser;
            var result = await _controller.DeleteDraft(1);

            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
        }

        [TestMethod]
        public async Task DeleteDraft_ShouldReturnOk_ForAdmin()
        {
            _controller.HttpContext.Items["loggedUser"] = _adminUser;
            _termServiceMock.Setup(s => s.DeleteDraft(1, _adminUser.Id)).Returns(Task.CompletedTask);
            var result = await _controller.DeleteDraft(1);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
