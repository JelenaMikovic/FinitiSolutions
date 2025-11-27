using back.DTOs;

namespace back.Services.Interfaces
{
    public interface ITermService
    {
        Task ArchiveTerm(int termId, int userId);
        Task CreateNewTerm(CreateTermDTO termDTO, int userId);
        Task DeleteDraft(int termId, int userId);
        Task<List<TermDTO>> GetArchivedTerms();
        Task<List<TermDTO>> GetDraftTerms(int userId);
        Task<List<TermDTO>> GetPublishedTerms();
        Task PublishTerm(int termId, int userId);
        Task UpdateTerm(UpdateTermDTO updateTermDTO, int userId);
    }
}
