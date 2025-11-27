using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using back.Services;
using back.Repositories.Interfaces;
using back.DTOs;
using back.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using back;

namespace FinitiTests
{
    [TestClass]
    public sealed class TermServiceTests
    {
        private Mock<ITermRepository> _termRepoMock;
        private Mock<IUserRepository> _userRepoMock;
        private Mock<IForbiddenWordsRepository> _forbiddenRepoMock;
        private TermService _termService;

        private User _user1;
        private User _user2;

        [TestInitialize]
        public void Setup()
        {
            _termRepoMock = new Mock<ITermRepository>();
            _userRepoMock = new Mock<IUserRepository>();
            _forbiddenRepoMock = new Mock<IForbiddenWordsRepository>();

            _termService = new TermService(_termRepoMock.Object, _userRepoMock.Object, _forbiddenRepoMock.Object);

            _user1 = new User
            {
                Id = 100,
                Name = "test",
                Surname = "test",
                Role = UserRole.USER,
                Email = "test@example.com",
                Password = "1234"
            };

            _user2 = new User
            {
                Id = 200,
                Name = "test",
                Surname = "test",
                Role = UserRole.ADMIN,
                Email = "john@doe.com",
                Password = "abcd"
            };
        }

        private Term CreateTerm(int id, User createdBy, TermStatus status = TermStatus.DRAFT)
        {
            return new Term
            {
                Id = id,
                Name = "Test Term",
                Definition = "A term for testing purposes that is long enough.",
                CreatedAt = DateTime.UtcNow,
                Status = status,
                CreatedBy = createdBy
            };
        }

        [TestMethod]
        public async Task GetArchivedTerms_ShouldReturnMappedDTOs()
        {
            var term = CreateTerm(100, _user1, TermStatus.ARCHIVED);
            _termRepoMock.Setup(r => r.GetArchivedTerms()).ReturnsAsync(new List<Term> { term });

            var result = await _termService.GetArchivedTerms();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(term.Name, result[0].Name);
            Assert.AreEqual($"{_user1.Name} {_user1.Surname}", result[0].CreatedBy);
        }

        [TestMethod]
        public async Task GetDraftTerms_ShouldReturnMappedDTOs()
        {
            var term = CreateTerm(101, _user1, TermStatus.DRAFT);
            _termRepoMock.Setup(r => r.GetDraftTerms(_user1.Id)).ReturnsAsync(new List<Term> { term });

            var result = await _termService.GetDraftTerms(_user1.Id);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(term.Id, result[0].Id);
        }

        [TestMethod]
        public async Task GetPublishedTerms_ShouldReturnMappedDTOs()
        {
            var term = CreateTerm(102, _user1, TermStatus.PUBLISHED);
            _termRepoMock.Setup(r => r.GetPublishedTerms()).ReturnsAsync(new List<Term> { term });

            var result = await _termService.GetPublishedTerms();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(TermStatus.PUBLISHED.ToString(), result[0].Status);
        }

        [TestMethod]
        public async Task CreateNewTerm_ShouldCallAddTerm()
        {
            _userRepoMock.Setup(r => r.GetUserById(_user1.Id)).ReturnsAsync(_user1);
            var dto = new CreateTermDTO { Name = "New Term", Definition = "Definition that is definitely long enough." };

            await _termService.CreateNewTerm(dto, _user1.Id);

            _termRepoMock.Verify(r => r.AddTerm(It.Is<Term>(t =>
                t.Name == dto.Name &&
                t.Definition == dto.Definition &&
                t.Status == TermStatus.DRAFT &&
                t.CreatedBy == _user1
            )), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "User not found.")]
        public async Task CreateNewTerm_ShouldThrow_WhenUserNotFound()
        {
            _userRepoMock.Setup(r => r.GetUserById(_user1.Id)).ReturnsAsync((User)null);
            var dto = new CreateTermDTO { Name = "x", Definition = new string('x', 30) };
            await _termService.CreateNewTerm(dto, _user1.Id);
        }

        [TestMethod]
        public async Task UpdateTerm_ShouldModifyTerm_WhenOwner()
        {
            var term = CreateTerm(103, _user1);
            _userRepoMock.Setup(r => r.GetUserById(_user1.Id)).ReturnsAsync(_user1);
            _termRepoMock.Setup(r => r.GetTermById(term.Id)).ReturnsAsync(term);

            var updateDTO = new UpdateTermDTO { Id = 103, Name = "Updated", Definition = "Updated definition that is long enough." };

            await _termService.UpdateTerm(updateDTO, _user1.Id);

            Assert.AreEqual("Updated", term.Name);
            Assert.AreEqual(updateDTO.Definition, term.Definition);
            _termRepoMock.Verify(r => r.UpdateTerm(term), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "You are not authorized to update this term.")]
        public async Task UpdateTerm_ShouldThrow_WhenNotOwner()
        {
            var term = CreateTerm(104, _user1);
            _userRepoMock.Setup(r => r.GetUserById(_user2.Id)).ReturnsAsync(_user2);
            _termRepoMock.Setup(r => r.GetTermById(term.Id)).ReturnsAsync(term);

            var dto = new UpdateTermDTO { Id = 104, Name = "X" };
            await _termService.UpdateTerm(dto, _user2.Id);
        }

        [TestMethod]
        public async Task DeleteDraft_ShouldCallDeleteTerm_WhenOwner()
        {
            var term = CreateTerm(105, _user1, TermStatus.DRAFT);
            _userRepoMock.Setup(r => r.GetUserById(_user1.Id)).ReturnsAsync(_user1);
            _termRepoMock.Setup(r => r.GetTermById(term.Id)).ReturnsAsync(term);

            await _termService.DeleteDraft(term.Id, _user1.Id);

            _termRepoMock.Verify(r => r.DeleteTerm(term), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "You are not authorized to update this term.")]
        public async Task DeleteDraft_ShouldThrow_WhenNotOwner()
        {
            var term = CreateTerm(106, _user1, TermStatus.DRAFT);
            _userRepoMock.Setup(r => r.GetUserById(_user2.Id)).ReturnsAsync(_user2);
            _termRepoMock.Setup(r => r.GetTermById(term.Id)).ReturnsAsync(term);

            await _termService.DeleteDraft(term.Id, _user2.Id);
        }

        [TestMethod]
        public async Task PublishTerm_ShouldSetStatusToPublished_WhenOwnerAndValid()
        {
            var term = CreateTerm(107, _user1, TermStatus.DRAFT);
            _userRepoMock.Setup(r => r.GetUserById(_user1.Id)).ReturnsAsync(_user1);
            _termRepoMock.Setup(r => r.GetTermById(term.Id)).ReturnsAsync(term);
            _forbiddenRepoMock.Setup(r => r.GetAllForbiddenWords()).ReturnsAsync(new List<ForbiddenWord>());

            await _termService.PublishTerm(term.Id, _user1.Id);

            Assert.AreEqual(TermStatus.PUBLISHED, term.Status);
            _termRepoMock.Verify(r => r.UpdateTerm(term), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "The term contains forbidden words and cannot be published.")]
        public async Task PublishTerm_ShouldThrow_WhenContainsForbiddenWords()
        {
            var term = CreateTerm(108, _user1, TermStatus.DRAFT);
            term.Name = "Bad Term";

            _userRepoMock.Setup(r => r.GetUserById(_user1.Id)).ReturnsAsync(_user1);
            _termRepoMock.Setup(r => r.GetTermById(term.Id)).ReturnsAsync(term);
            _forbiddenRepoMock.Setup(r => r.GetAllForbiddenWords()).ReturnsAsync(new List<ForbiddenWord>
            {
                new ForbiddenWord { Word = "Bad" }
            });

            await _termService.PublishTerm(term.Id, _user1.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "You are not authorized to publish this term.")]
        public async Task PublishTerm_ShouldThrow_WhenNotOwner()
        {
            var term = CreateTerm(109, _user1, TermStatus.DRAFT);
            _userRepoMock.Setup(r => r.GetUserById(_user2.Id)).ReturnsAsync(_user2);
            _termRepoMock.Setup(r => r.GetTermById(term.Id)).ReturnsAsync(term);
            _forbiddenRepoMock.Setup(r => r.GetAllForbiddenWords()).ReturnsAsync(new List<ForbiddenWord>());

            await _termService.PublishTerm(term.Id, _user2.Id);
        }

        [TestMethod]
        public async Task ArchiveTerm_ShouldSetStatusToArchived_WhenOwnerAndPublished()
        {
            var term = CreateTerm(110, _user1, TermStatus.PUBLISHED);
            _userRepoMock.Setup(r => r.GetUserById(_user1.Id)).ReturnsAsync(_user1);
            _termRepoMock.Setup(r => r.GetTermById(term.Id)).ReturnsAsync(term);

            await _termService.ArchiveTerm(term.Id, _user1.Id);

            Assert.AreEqual(TermStatus.ARCHIVED, term.Status);
            _termRepoMock.Verify(r => r.UpdateTerm(term), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Only published terms can be archived.")]
        public async Task ArchiveTerm_ShouldThrow_WhenNotPublished()
        {
            var term = CreateTerm(111, _user1, TermStatus.DRAFT);
            _userRepoMock.Setup(r => r.GetUserById(_user2.Id)).ReturnsAsync(_user2);
            _termRepoMock.Setup(r => r.GetTermById(term.Id)).ReturnsAsync(term);

            await _termService.ArchiveTerm(term.Id, _user2.Id);
        }
    }
}
