using System.Data;

namespace Domain.Interfaces.Repository.Base
{
    public interface IUnitOfWorkBootcamp : IUnitOfWork
    {
        ICandidateRepository Candidate { get; }
        IExperienceRepository Experience { get; }
    }
}
