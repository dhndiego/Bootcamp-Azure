using Domain.Interfaces.Repository;
using Domain.Interfaces.Repository.Base;
using Domain.Models;
using Dapper;
using System.Data;

namespace Repository.Bootcamp.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        #region [ ATTRIBUTES ]
        private readonly IUnitOfWorkBootcamp _unitOfWork;
        private IDbConnection Connection => _unitOfWork.Connection;
        private IDbTransaction Transaction => _unitOfWork.Transaction;
        #endregion [ ATTRIBUTES ]

        #region [ CONSTRUCTOR ]
        public CandidateRepository(IUnitOfWorkBootcamp unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion [ CONSTRUCTOR ]

        #region [ METHODS ]

        public async Task<Guid> Insert(Candidate candidate)
        {
            candidate.Id = Guid.NewGuid();

            string query = @"INSERT INTO Candidate
                               (Id
                               ,Name
                               ,Email
                               ,Cpf
                               ,BirthDate)
                            VALUES
                               (@id
                               ,@name
                               ,@email
                               ,@cpf
                               ,@birthDate)";

            var param = new {candidate.Id, candidate.Name, candidate.Email, candidate.Cpf, candidate.BirthDate};

            var result = await Connection.ExecuteAsync(query, param, Transaction);            

            return result > 0 ? candidate.Id : Guid.Empty;            
        }

        public async Task<IList<Candidate>> GetAll()
        {
            string query = @"SELECT c.Id	
	                            ,c.Name
	                            ,c.Email
	                            ,c.Cpf
	                            ,c.BirthDate
	                            ,c.Active
	                            ,c.Deleted
	                            ,c.CreatedAt
                            FROM Candidate c";

            return (await Connection.QueryAsync<Candidate>(query, Transaction)).ToList();

        }

        public async Task<Candidate> GetById(Guid id)
        {
            string query = @"SELECT c.Id	
	                            ,c.Name
	                            ,c.Email
	                            ,c.Cpf
	                            ,c.BirthDate
	                            ,c.Active
	                            ,c.Deleted
	                            ,c.CreatedAt
                            FROM Candidate c
                            WHERE Id = @id";

            return (await Connection.QueryFirstOrDefaultAsync<Candidate>(query, new { id }, Transaction));

        }

        public async Task<bool> Update(Candidate candidate)
        {
            string query = @"UPDATE Candidate
                               SET Name = @name
                                  ,Email = @email
                                  ,Cpf = @cpf
                                  ,BirthDate = @birthDate
                                  ,Active = @active
                                  ,Deleted = @deleted
                             WHERE Id = @id";

            var param = new { candidate.Id, candidate.Name, candidate.Email, candidate.Cpf, candidate.BirthDate, candidate.Active, candidate.Deleted };

            var result = await Connection.ExecuteAsync(query, param, Transaction);

            return result > 0 ? true : false;
        }

        public async Task<bool> Delete(Guid Id)
        {
            string query = @"DELETE FROM Candidate WHERE Id = @id";

            var param = new { Id };

            var result = await Connection.ExecuteAsync(query, param, Transaction);

            return result > 0 ? true : false;
        }

        #endregion [ METHODS ]
    }
}
