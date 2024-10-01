using Domain.Models;

namespace Domain.Interfaces.Repository
{
    public interface ICandidateRepository
    {
        Task<Guid> Insert(Candidate candidate);
        Task<bool> Update(Candidate candidate);
        Task<bool> Delete(Guid id);
        Task<IList<Candidate>> GetAll();
        Task<Candidate> GetById(Guid id);
    }
}
