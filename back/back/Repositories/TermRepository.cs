using Microsoft.EntityFrameworkCore;
using back.Repositories.Interfaces;

namespace back.Repositories
{
    public class TermRepository : ITermRepository
    {
        private readonly DatabaseContext _context;

        public TermRepository(DatabaseContext context)
        {
            _context = context;
        }

    }
}
