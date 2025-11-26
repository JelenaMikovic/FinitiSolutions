using Microsoft.EntityFrameworkCore;
using back.Repositories.Interfaces;

namespace back.Repositories
{
    public class ForbiddenWordsRepository : IForbiddenWordsRepository
    {
        private readonly DatabaseContext _context;

        public ForbiddenWordsRepository(DatabaseContext context)
        {
            _context = context;
        }

    }
}
