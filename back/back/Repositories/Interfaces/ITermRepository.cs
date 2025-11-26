using back.Model;

namespace back.Repositories.Interfaces
{
    public interface ITermRepository
    {
        Task<List<Term>> GetArchivedTerms();
        Task<List<Term>> GetDraftTerms(int id);
        Task<List<Term>> GetPublishedTerms();
    }
}
