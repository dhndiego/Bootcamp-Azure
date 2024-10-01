using Application.Services.Interfaces;
using Domain.Interfaces.Repository.Base;
using Domain.Models;

namespace Application.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IUnitOfWorkBootcamp _unitOfWorkBootcamp;

        public ExperienceService(IUnitOfWorkBootcamp unitOfWorkBootcamp)
        {
            _unitOfWorkBootcamp = unitOfWorkBootcamp;
        }

        public async Task<IList<Experience>> GetAll()
        {
            return await _unitOfWorkBootcamp.Experience.GetAll();            
        }

        public async Task<IList<Experience>> GetByCpf(string cpf)
        {
            return await _unitOfWorkBootcamp.Experience.GetByCpf(cpf);
        }
    }
}
