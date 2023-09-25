using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistence.Repositories
{
    public class AnalysisRepository : CLINICAL.Application.Interface.IAnalysisRepository
    {
        private readonly ApplicactionDbContext _context;

        public AnalysisRepository(ApplicactionDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Analysis>> ListAnalysis()
        {
            using var connection = _context.CreateConnection;
            var query = "uspAnalyisList";

            var analysis = await connection.QueryAsync<Analysis>(query, commandType: CommandType.StoredProcedure);

            return analysis;
        }
    }
}
