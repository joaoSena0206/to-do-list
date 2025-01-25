using BCrypt.Net;
using Microsoft.Data.SqlClient;
using To_do_List.Models;

namespace To_do_List.DataAccess
{
    public class UserDAL
    {
        private readonly Database _database;

        public UserDAL(string connectionString)
        {
            Database database = new Database(connectionString);
            _database = database;
        }

        public void CreateUser(User user)
        {
            // Efetua o hash da senha
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            // Insere no banco o usuário
            string comando = @"
            INSERT INTO usuario VALUES (
	            @Email,
	            @Password
            );";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Email", user.Email));
            parameters.Add(new SqlParameter("Password", user.Password));

            _database.ExecuteCommand(comando, parameters);
        }
    }
}
