using Dapper;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Repository.Base;
using Domain.Models;
using System.Data;

namespace Repository.Bootcamp.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        #region [ ATTRIBUTES ]
        private readonly IUnitOfWorkBootcamp _unitOfWork;
        private IDbConnection Connection => _unitOfWork.Connection;
        private IDbTransaction Transaction => _unitOfWork.Transaction;
        #endregion [ ATTRIBUTES ]

        #region [ CONSTRUCTOR ]
        public ExperienceRepository(IUnitOfWorkBootcamp unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion [ CONSTRUCTOR ]

        #region [ METHODS ]

        public async Task<IList<Experience>> GetAll()
        {
            string query = @"SELECT e.Id
                                ,e.Ocupation
                                ,e.CompanyName
                                ,e.StartDate
                                ,e.EndDate
                                ,e.Deleted
                                ,e.CreatedAt
                            FROM Experience e";

            return (await Connection.QueryAsync<Experience>(query, transaction: _unitOfWork.Transaction)).ToList();

        }

        public async Task<IList<Experience>> GetByCpf(string cpf)
        {

            var query = @"select e.Id
                            ,e.Ocupation
                            ,e.CompanyName
                            ,e.StartDate
                            ,e.EndDate
                            ,e.Deleted
                            ,e.CreatedAt
                        from Candidate c
                        inner join CandidateExperience ce on c.Id = ce.CandidateId
                        inner join Experience e on e.Id = ce.ExperienceId
                        where c.Cpf = @cpf";

            return (await Connection.QueryAsync<Experience>(query, new { cpf }, _unitOfWork.Transaction)).ToList();

        }

        #endregion [ METHODS ]

    }
}
