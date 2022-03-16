using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess.DataBaseAccess
{
    public class DataBaseAccess : IDataBaseAccess
    {
        private readonly IConfiguration _config;

        public DataBaseAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> GetData<T, U>(
            string storedProcedure,
            U parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SetData<T>(
            string storedProcedure,
            T parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
