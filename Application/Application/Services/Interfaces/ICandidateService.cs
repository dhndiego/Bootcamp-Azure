using Domain.Dto;
using Domain.Models;
using Domain.Services;

namespace Application.Services.Interfaces
{
    public interface ICandidateService
    {
        Task<Guid> Create(Candidate candidate);
        Task<bool> CreateWithBus(Candidate candidate);
        Task<CandidateDto> CreateWithAI();
        Task<OpenAiResponse> ResponseWithAI(string question);
        Task<bool> Update(Candidate candidate);
        Task<bool> Delete(Guid Id);
        Task<IList<Candidate>> GetAll();
        Task<Candidate> GetById(Guid id);
    }
}
