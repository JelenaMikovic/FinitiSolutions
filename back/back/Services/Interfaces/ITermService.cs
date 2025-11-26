using back.DTOs;

namespace back.Services.Interfaces
{
    public interface ITermService
    {
        Task<List<TermDTO>> GetArchivedTerms();
        Task<List<TermDTO>> GetDraftTerms(int id);
        Task<List<TermDTO>> GetPublishedTerms();
    }
}
