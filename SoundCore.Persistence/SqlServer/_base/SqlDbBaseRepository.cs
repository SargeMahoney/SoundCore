using Microsoft.Extensions.Logging;
using SoundCore.Application.Configurations.DatabaseSettings;
using System.Data;
using System.Data.SqlClient;

namespace SoundCore.Persistence.SqlServer._base
{
    public class SqlDbBaseRepository
    {
        protected readonly ILogger<SqlDbBaseRepository> _logger;

        public SqlDbBaseRepository(ILogger<SqlDbBaseRepository> logger, IDatabaseSetting dbConfig)
        {
            this._logger = logger;
            this._connectionString = dbConfig.CurrentConnection;
        }

        protected string _connectionString { get; set; }



        public IDbConnection Connection => new SqlConnection(_connectionString);
    }
}
