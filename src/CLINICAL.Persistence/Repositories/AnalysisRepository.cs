using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using CLINICAL.Application.Interface;
using Dapper;
using System.Data;

namespace CLINICAL.Persistence.Repositories
{
    public class AnalysisRepository : IAnalysisRepository
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

        public async Task<Analysis> AnalysisById(int analysisId)
        {
            using var connection = _context.CreateConnection;
            var query = "uspAnalysisById";

            var parameters = new DynamicParameters();
            parameters.Add("AnalysisId", analysisId);

            var analysis = await connection
                .QuerySingleOrDefaultAsync<Analysis>(query, param: parameters, commandType: CommandType.StoredProcedure);
            
            return analysis;


        }
    }
}
