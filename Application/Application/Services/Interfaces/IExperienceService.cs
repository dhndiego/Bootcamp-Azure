using Domain.Models;

namespace Application.Services.Interfaces
{
    public interface IExperienceService
    {
        Task<IList<Experience>> GetAll();
        Task<IList<Experience>> GetByCpf(string cpf);
    }
}
