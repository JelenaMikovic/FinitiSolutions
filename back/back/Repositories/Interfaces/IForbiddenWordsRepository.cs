using back.Model;

namespace back.Repositories.Interfaces
{
    public interface IForbiddenWordsRepository
    {
        Task<List<ForbiddenWord>> GetAllForbiddenWords();
    }
}
