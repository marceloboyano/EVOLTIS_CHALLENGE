using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public abstract class MasterRepository:Repository
    {
        protected List<SqlParameter> parameters;
        public MasterRepository()
        {
            parameters = new List<SqlParameter>();
        }
        protected int ExecuteNonQuery(string transacSql)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand()) 
                {
                    command.Connection = connection;
                    command.CommandText = transacSql;
                    command.CommandType = CommandType.Text;

                    foreach (var parameter in parameters) 
                    {
                       command.Parameters.Add(parameter);                    
                    }

                    int result = command.ExecuteNonQuery();
                    parameters.Clear();
                    return result;
                }
            }
        }

        protected DataTable ExecuteReader(string transacSql)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transacSql;
                    command.CommandType = CommandType.Text;

                   
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    
                    SqlDataReader reader = command.ExecuteReader();

                    using (var table = new DataTable())
                    {
                        table.Load(reader);
                        reader.Dispose();
                       
                        command.Parameters.Clear();
                      
                        return table;
                    }
                }
            }
        }          


    }
}
