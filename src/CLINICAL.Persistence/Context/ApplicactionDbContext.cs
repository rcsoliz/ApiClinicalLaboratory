using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CLINICAL.Persistence.Context
{
    public class ApplicactionDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ApplicactionDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ClinicalConnection")!;
        }

        public IDbConnection CreateConnection => new SqlConnection(_connectionString);

    }
}
