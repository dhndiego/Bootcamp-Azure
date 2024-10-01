using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IExperienceRepository
    {
        Task<IList<Experience>> GetAll();
        Task<IList<Experience>> GetByCpf(string cpf);

    }
}
