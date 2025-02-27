﻿using Microsoft.Data.SqlClient;
using To_do_List.Models;

namespace To_do_List.DataAccess
{
    public class UserDAL
    {
        private readonly Database _database;

        public UserDAL(Database database)
        {
            _database = database;
        }

        public void AddUser(User user)
        {
            try
            {
                string comando = @"INSERT INTO usuario VALUES
                (
	                @Email,
	                @Password
                )";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("Email", user.Email));
                parameters.Add(new SqlParameter("Password", user.Password));

                _database.ExecuteCommand(comando, parameters);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    throw new Exception("Usuário já cadastrado!");
                }
            }
        }

        public string GetPasswordHash(string email)
        {
            string command = @"SELECT nm_senha_usuario FROM usuario
            WHERE nm_email_usuario = @Email";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Email", email));

            string passwordHash = "";

            using (SqlDataReader reader = _database.ExecuteQuery(command, parameters))
            {
                if (reader.Read())
                {
                    passwordHash = reader.GetString(0);
                }
            }

            return passwordHash;
        }
    }
}