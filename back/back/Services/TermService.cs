using back.Repositories.Interfaces;
using back.Services.Interfaces;
using back.DTOs;
using back.Model;

namespace back.Services
{
    public class TermService : ITermService
    {
        private readonly ITermRepository _termRepository;

        public TermService(ITermRepository termRepository)
        {
            _termRepository = termRepository;
        }

        public async Task<List<TermDTO>> GetArchivedTerms()
        {
            var terms = await _termRepository.GetArchivedTerms();
            return MapToDTOs(terms);
        }

        public async Task<List<TermDTO>> GetDraftTerms(int id)
        {
            var terms = await _termRepository.GetDraftTerms(id);
            return MapToDTOs(terms);
        }

        public async Task<List<TermDTO>> GetPublishedTerms()
        {
            var terms = await _termRepository.GetPublishedTerms();
            return MapToDTOs(terms);
        }

        private static List<TermDTO> MapToDTOs(List<Term> terms)
        {
            return terms.Select(term => new TermDTO
            {
                Id = term.Id,
                Name = term.Name,
                Definition = term.Definition,
                Status = term.Status.ToString(),
                CreatedAt = term.CreatedAt,
                CreatedBy = term.CreatedBy.Email
            }).ToList();
        }
    }
}
