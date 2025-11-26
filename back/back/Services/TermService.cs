using back.Repositories.Interfaces;
using back.Services.Interfaces;
using back.DTOs;
using back.Model;
using Microsoft.IdentityModel.Tokens;

namespace back.Services
{
    public class TermService : ITermService
    {
        private readonly ITermRepository _termRepository;
        private readonly IUserRepository _userRepository;

        public TermService(ITermRepository termRepository, IUserRepository userRepository)
        {
            _termRepository = termRepository;
            _userRepository = userRepository;
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

        public async Task CreateNewTerm(CreateTermDTO termDTO, int id)
        {
            User user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            Term newTerm = new Term
            {
                Name = termDTO.Name,
                Definition = termDTO.Definition,
                Status = TermStatus.DRAFT,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = user
            };
            await _termRepository.AddTerm(newTerm);
        }

        public async Task UpdateTerm(UpdateTermDTO updateTermDTO, int id)
        {
            User user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            Term term = await _termRepository.GetTermById(updateTermDTO.Id);
            if (term == null)
            {
                throw new Exception("Term not found.");
            }
            if (term.Status != TermStatus.DRAFT)
            {
                throw new Exception("Only draft terms can be updated.");
            }
            if (term.CreatedBy.Id != user.Id)
            {
                throw new Exception("You are not authorized to update this term.");
            }
            if (!string.IsNullOrWhiteSpace(updateTermDTO.Name))
            {
                term.Name = updateTermDTO.Name;
            }
            if (!string.IsNullOrWhiteSpace(updateTermDTO.Definition))
            {
                term.Definition = updateTermDTO.Definition;
            }
            await _termRepository.UpdateTerm(term);
        }
    }
}
