using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using back.Repositories;
using back.Repositories.Interfaces;
using back;
using back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinitiTests
{
    [TestClass]
    public sealed class TermRepositoryTests
    {
        private DatabaseContext _context;
        private ITermRepository _termRepository;

        private User _user1;
        private User _user2;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) 
                .Options;

            _context = new DatabaseContext(options);

            _user1 = new User { Id = 100, Name = "test", Surname = "test", Role = UserRole.USER, Email = "a@a.com", Password = "123" };
            _user2 = new User { Id = 200, Name = "test", Surname = "test", Role = UserRole.USER, Email = "b@b.com", Password = "456" };

            _context.Users.AddRange(_user1, _user2);
            _context.SaveChanges();

            _termRepository = new TermRepository(_context);
        }

        [TestMethod]
        public async Task AddTerm_ShouldInsertTerm()
        {
            var term = new Term
            {
                Id = 100,
                Name = "Test Term",
                Definition = "A term for testing",
                CreatedAt = DateTime.UtcNow,
                Status = TermStatus.DRAFT,
                CreatedBy = _user1
            };

            await _termRepository.AddTerm(term);

            var saved = await _context.Terms.FirstOrDefaultAsync(t => t.Id == 100);

            Assert.IsNotNull(saved);
            Assert.AreEqual("Test Term", saved.Name);
            Assert.AreEqual(_user1.Id, saved.CreatedBy.Id);
        }

        [TestMethod]
        public async Task DeleteTerm_ShouldRemoveTerm()
        {
            var term = new Term { Id = 200, Name = "Delete Me", Status = TermStatus.DRAFT, CreatedAt = DateTime.UtcNow, Definition = "test", CreatedBy = _user1 };
            _context.Terms.Add(term);
            await _context.SaveChangesAsync();

            await _termRepository.DeleteTerm(term);

            var exists = await _context.Terms.AnyAsync(t => t.Id == 200);
            Assert.IsFalse(exists);
        }

        [TestMethod]
        public async Task GetArchivedTerms_ShouldReturnOnlyArchived()
        {
            _context.Terms.AddRange(
                new Term { Id = 300, Name = "Archived A", Definition = "test", CreatedAt = DateTime.UtcNow, Status = TermStatus.ARCHIVED, CreatedBy = _user1 },
                new Term { Id = 310, Name = "Draft B", Definition = "test", CreatedAt = DateTime.UtcNow, Status = TermStatus.DRAFT, CreatedBy = _user2 },
                new Term { Id = 320, Name = "Archived C", Definition = "test", CreatedAt = DateTime.UtcNow, Status = TermStatus.ARCHIVED, CreatedBy = _user2 }
            );
            await _context.SaveChangesAsync();

            var result = await _termRepository.GetArchivedTerms();

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.All(t => t.Status == TermStatus.ARCHIVED));
        }


        [TestMethod]
        public async Task GetDraftTerms_ShouldReturnDraftsForSpecificUser()
        {
            _context.Terms.AddRange(
                new Term {Id = 400, Name = "Draft A", Definition = "test", CreatedAt = DateTime.UtcNow, Status = TermStatus.DRAFT, CreatedBy = _user1 },
                new Term {Id = 410, Name = "Draft B", Definition = "test", CreatedAt = DateTime.UtcNow, Status = TermStatus.DRAFT, CreatedBy = _user2 },
                new Term {Id = 420, Name = "Published", Definition = "test", CreatedAt = DateTime.UtcNow, Status = TermStatus.PUBLISHED, CreatedBy = _user1 }
            );
            await _context.SaveChangesAsync();

            var result = await _termRepository.GetDraftTerms(_user1.Id);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Draft A", result[0].Name);
        }

        [TestMethod]
        public async Task GetPublishedTerms_ShouldReturnOnlyPublished()
        {
            _context.Terms.AddRange(
                new Term {Id = 500, Name = "Pub A", Definition = "test", CreatedAt = DateTime.UtcNow, Status = TermStatus.PUBLISHED, CreatedBy = _user1 },
                new Term {Id = 510, Name = "Draft C", Definition = "test", CreatedAt = DateTime.UtcNow, Status = TermStatus.DRAFT, CreatedBy = _user2 }
            );
            await _context.SaveChangesAsync();

            var result = await _termRepository.GetPublishedTerms();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Pub A", result[0].Name);
        }

        [TestMethod]
        public async Task GetTermById_ShouldReturnTermWithCreatedBy()
        {
            var term = new Term { Id = 600, Name = "ById", Definition = "test", CreatedAt = DateTime.UtcNow, Status = TermStatus.DRAFT, CreatedBy = _user2 };
            _context.Terms.Add(term);
            await _context.SaveChangesAsync();

            var result = await _termRepository.GetTermById(600);

            Assert.IsNotNull(result);
            Assert.AreEqual("ById", result.Name);
            Assert.AreEqual(_user2.Id, result.CreatedBy.Id);
        }

        [TestMethod]
        public async Task UpdateTerm_ShouldModifyTerm()
        {
            var term = new Term {Id = 700, Name = "Old", Definition = "test", CreatedAt = DateTime.UtcNow, Status = TermStatus.DRAFT, CreatedBy = _user1 };
            _context.Terms.Add(term);
            await _context.SaveChangesAsync();

            term.Name = "New Updated";
            await _termRepository.UpdateTerm(term);

            var result = await _context.Terms.FirstOrDefaultAsync(t => t.Id == 700);

            Assert.AreEqual("New Updated", result.Name);
        }
    }
}
