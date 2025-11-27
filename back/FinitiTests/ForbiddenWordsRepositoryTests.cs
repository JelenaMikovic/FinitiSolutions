using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using back.Repositories;
using back.Repositories.Interfaces;
using back;
using back.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinitiTests
{
    [TestClass]
    public sealed class ForbiddenWordsRepositoryTests
    {
        private DatabaseContext _context;
        private IForbiddenWordsRepository _forbiddenWordsRepository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new DatabaseContext(options);

            _context.ForbiddenWords.AddRange(
                new ForbiddenWord { Id = 1, Word = "badword1" },
                new ForbiddenWord { Id = 2, Word = "badword2" }
            );
            _context.SaveChanges();

            _forbiddenWordsRepository = new ForbiddenWordsRepository(_context);
        }

        [TestMethod]
        public async Task GetAllForbiddenWords_ShouldReturnAllForbiddenWords()
        {
            var result = await _forbiddenWordsRepository.GetAllForbiddenWords();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEquivalent(
                new List<string> { "badword1", "badword2" },
                result.ConvertAll(fw => fw.Word)
            );
        }

        [TestMethod]
        public async Task GetAllForbiddenWords_ShouldReturnEmptyList_WhenNoWordsExist()
        {
            _context.ForbiddenWords.RemoveRange(_context.ForbiddenWords);
            await _context.SaveChangesAsync();

            var result = await _forbiddenWordsRepository.GetAllForbiddenWords();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }
    }
}
