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

        public async Task DeleteTerm(Term term)
        {
            var entity = await _context.Terms.FirstOrDefaultAsync(t => t.Id == term.Id);
            if (entity != null)
            {
                _context.Terms.Remove(entity);
                await _context.SaveChangesAsync();
            }
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

        public async Task<Term> GetTermById(int id)
        {
            return await _context.Terms.Include(t => t.CreatedBy).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateTerm(Term term)
        {
            _context.Terms.Update(term);
            await _context.SaveChangesAsync();
        }
    }
}
