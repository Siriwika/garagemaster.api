using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace GarageMaster.API.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly string connectionString;
        public BaseRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //Method Connect to Sql Server
        private T WithConnection<T>(Func<IDbConnection, T> getData)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return getData(connection);
                }
            }
            catch (SqlException e)
            {

                throw e;
            }
        }

        //Method Stored procedure
        public int ExecuteStoreProcedure<T>(string spName, DynamicParameters dynamic)
        {
            return WithConnection(x => x.Execute(spName, dynamic, commandType: CommandType.StoredProcedure));
        }

        public IEnumerable<T> QueryStoreProcedure<T>(string spName, DynamicParameters dynamic)
        {
            return WithConnection(x => x.Query<T>(spName, dynamic, commandType: CommandType.StoredProcedure));
        }

        //Method Query string
        public int ExecuteString<T>(string sql)
        {
            return WithConnection(c => c.Execute(sql));
        }

        public IEnumerable<T> QueryString<T>(string sql)
        {
            return WithConnection(c => c.Query<T>(sql));
        }


    }
}
