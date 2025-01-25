using Microsoft.Data.SqlClient;
using System.Data;

namespace To_do_List.DataAccess
{
    public class Database
    {
        private string _connectionString;

        public Database(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ExecuteCommand(string commandString, List<SqlParameter>? parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(commandString, connection);

                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                    {
                        command.Parameters.Add(param);
                    }
                }

                command.ExecuteNonQuery();
            }
        }

        public SqlDataReader ExecuteQuery(string commandString, List<SqlParameter>? parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(commandString, connection);

                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                    {
                        command.Parameters.Add(param);
                    }
                }

                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
    }
}
