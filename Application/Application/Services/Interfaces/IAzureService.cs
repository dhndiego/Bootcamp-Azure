using Domain.Models;

namespace Application.Services.Interfaces
{
    public interface IAzureService
    {
        Task<bool> Create(Candidate candidate);
        
    }
}
