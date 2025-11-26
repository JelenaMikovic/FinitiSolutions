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
        private readonly IForbiddenWordsRepository _forbiddenWordsRepository;

        public TermService(ITermRepository termRepository, IUserRepository userRepository, IForbiddenWordsRepository forbiddenWordsRepository)
        {
            _termRepository = termRepository;
            _userRepository = userRepository;
            _forbiddenWordsRepository = forbiddenWordsRepository;
        }

        public async Task<List<TermDTO>> GetArchivedTerms()
        {
            var terms = await _termRepository.GetArchivedTerms();
            return MapToDTOs(terms);
        }

        public async Task<List<TermDTO>> GetDraftTerms(int userId)
        {
            var terms = await _termRepository.GetDraftTerms(userId);
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
                CreatedBy = term.CreatedBy.Name + " " + term.CreatedBy.Surname
            }).ToList();
        }

        public async Task CreateNewTerm(CreateTermDTO termDTO, int userId)
        {
            User user = await _userRepository.GetUserById(userId);
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

        public async Task UpdateTerm(UpdateTermDTO updateTermDTO, int userId)
        {
            User user = await _userRepository.GetUserById(userId);
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

        public async Task ArchiveTerm(int termId, int userId)
        {
            User user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            Term term = await _termRepository.GetTermById(termId);
            if (term == null)
            {
                throw new Exception("Term not found.");
            }
            if (term.Status != TermStatus.PUBLISHED)
            {
                throw new Exception("Only published terms can be archived.");
            }
            term.Status = TermStatus.ARCHIVED;
            await _termRepository.UpdateTerm(term);
        }

        public async Task DeleteDraft(int termId, int userId)
        {
            User user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            Term term = await _termRepository.GetTermById(termId);
            if (term == null)
            {
                throw new Exception("Term not found.");
            }
            if (term.Status != TermStatus.DRAFT)
            {
                throw new Exception("Only drafted terms can be deleted.");
            }
            if (term.CreatedBy.Id != user.Id)
            {
                throw new Exception("You are not authorized to update this term.");
            }
            await _termRepository.DeleteTerm(term);
        }

        public async Task PublishTerm(int termId, int userId)
        {
            User user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            Term term = await _termRepository.GetTermById(termId);
            if (term == null)
            {
                throw new Exception("Term not found.");
            }
            if (term.Status != TermStatus.DRAFT)
            {
                throw new Exception("Only draft terms can be published.");
            }
            if (term.CreatedBy.Id != user.Id)
            {
                throw new Exception("You are not authorized to publish this term.");
            }
            List<ForbiddenWord> forbiddenWords = await _forbiddenWordsRepository.GetAllForbiddenWords();
            foreach (var forbiddenWord in forbiddenWords)
            {
                if (term.Name.Contains(forbiddenWord.Word, StringComparison.OrdinalIgnoreCase) ||
                    term.Definition.Contains(forbiddenWord.Word, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("The term contains forbidden words and cannot be published.");
                }
            }
            term.Status = TermStatus.PUBLISHED;
            await _termRepository.UpdateTerm(term);
        }
    }
}
