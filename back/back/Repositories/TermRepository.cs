using Microsoft.EntityFrameworkCore;
using back.Repositories.Interfaces;
using back.Model;

namespace back.Repositories
{
    public class TermRepository : ITermRepository
    {
        private readonly DatabaseContext _context;

        public TermRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddTerm(Term newTerm)
        {
            if (newTerm.CreatedBy != null)
            {
                _context.Users.Attach(newTerm.CreatedBy);
            }
            await _context.Terms.AddAsync(newTerm);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Term>> GetArchivedTerms()
        {
            return await _context.Terms.Include(t => t.CreatedBy).Where(t => t.Status == TermStatus.ARCHIVED).OrderBy(t => t.Name).ToListAsync();
        }

        public async Task<List<Term>> GetDraftTerms(int id)
        {
            return await _context.Terms.Include(t => t.CreatedBy).Where(t => t.Status == TermStatus.DRAFT && t.CreatedBy.Id == id).OrderBy(t => t.Name).ToListAsync();
        }

        public async Task<List<Term>> GetPublishedTerms()
        {
            return await _context.Terms.Include(t => t.CreatedBy).Where(t => t.Status == TermStatus.PUBLISHED).OrderBy(t => t.Name).ToListAsync();
        }
    }
}
