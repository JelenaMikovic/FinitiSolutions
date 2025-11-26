using back.Repositories.Interfaces;
using back.Services.Interfaces;
using back.DTOs;

namespace back.Services
{
    public class TermService : ITermService
    {
        private readonly ITermRepository _termRepository;

        public TermService(ITermRepository termRepository)
        {
            this._termRepository = termRepository;

        }

    }
}
